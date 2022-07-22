using EFinansConnectorService;
using HANEL.MODEL.DataTransferModels.EServisEntegrator;
using HANEL.MODEL.Entities.Muhasebe;
using HANEL.SERVICE.EINVOICE.Abstract;
using HANEL.SERVICE.EINVOICE.Helpers;
using KARYA.COMMON.DirectoryAndFileHelpers;
using KARYA.COMMON.Helpers;
using KARYA.CORE.Helpers;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HANEL.SERVICE.EINVOICE.Concrete.EFinansService
{
    public class EFinansIncommingInvoiceUtility : IIncomingInvoiceUtility
    {
        ConnectorServiceClient _connectorService;
        
        public EFinansIncommingInvoiceUtility()
        {

            var time = new TimeSpan(0, 3, 0);

            _connectorService = new ConnectorServiceClient();

            _connectorService.Endpoint.Binding.CloseTimeout = time;
            _connectorService.Endpoint.Binding.OpenTimeout = time;
            _connectorService.Endpoint.Binding.ReceiveTimeout = time;
            _connectorService.Endpoint.Binding.SendTimeout = time;
            _connectorService.Endpoint.EndpointBehaviors.Add(CookieHelper.COOKIEBEHAVIOR);

        }

        public Task<IDataResult<Fatura>> GetInvoice(FaturaFiltreModel faturaFiltreModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<double>> GetInvoiceRoundingDetail(XDocument xml)
        {
            try
            {
               
                var yuvarlamas = AppsettingHelper.GetStringArrayValue("Yuvarlama");

                string yuvarlama = null;

                var findYuvarlama = xml.Descendants().Where(x => x.Name.LocalName == "Note" && yuvarlamas.Any(y => x.Value.Contains(y))).Select(s => s.Value).FirstOrDefault();

                foreach (var itemRand in yuvarlamas)
                {
                    if (findYuvarlama != null)
                    {
                        yuvarlama = findYuvarlama.Remove(findYuvarlama.IndexOf(itemRand), itemRand.Length);
                        yuvarlama = new string(yuvarlama.Where(p => char.IsDigit(p) || p == ',' || p == '.').ToArray());
                    }

                }

                var _yuvarlamaDouble = Convert.ToDouble(yuvarlama);

                return new SuccessDataResult<double>(_yuvarlamaDouble, "");

            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<double>(0, ex.Message);
            }
        }
        public async Task<IDataResult<string>> GetInvoiceSubscribeNo(XDocument xml)
        {
            try
            {
               
                var subscribeNums = AppsettingHelper.GetStringArrayValue("InvoiceSubscribeNums");
                var subscribe = AppsettingHelper.GetStringArrayValue("InvoiceSubscribeNums");
                var redundantTexts = AppsettingHelper.GetStringArrayValue("InvoiceSubscribeRedundantText");

                string subscribeNum = null;

                var hasOne = xml.Descendants().Any(x => x.Name.LocalName == "ID" && x.Attribute("schemeID") != null && subscribeNums.Contains(x.FirstAttribute.Value));


                if (hasOne)
                    subscribeNum = xml.Descendants().FirstOrDefault(x => x.Name.LocalName == "ID" && x.Attribute("schemeID") != null && subscribeNums.Contains(x.FirstAttribute.Value))?.Value;
                else
                {
                    var others = xml.Descendants().Where(x => x.Name.LocalName == "Note" && subscribeNums.Any(y => x.Value.Contains(y))).Select(s => s.Value).ToList();

                    foreach (var radnText in redundantTexts)
                    {
                        var hasRadnText = others.Any(w => w.Contains(radnText));

                        if (hasRadnText)
                            subscribeNum = others.FirstOrDefault(w => w.Contains(radnText)).Remove(others.FirstOrDefault(w => w.Contains(radnText)).IndexOf(radnText), radnText.Length);


                    }

                }

                return new SuccessDataResult<string>(subscribeNum,"");

            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<string>(null,ex.Message);
            }
        }
        public async Task<IDataResult<double>> GetInvoiceMahsupDetail(XDocument xml)
        {
            try
            {
                

                var mahsups = AppsettingHelper.GetStringArrayValue("Mahsup");

                string mahsup = "0";

                var findMahsup = xml.Descendants().Where(x => x.Name.LocalName == "Note" && mahsups.Any(y => x.Value.Contains(y))).Select(s => s.Value).FirstOrDefault();

                foreach (var itemRand in mahsups)
                {
                    if (findMahsup != null)
                    {
                        mahsup = findMahsup.Remove(findMahsup.IndexOf(itemRand), itemRand.Length);
                        mahsup = new string(mahsup.Where(p => char.IsDigit(p) || p == ',' || p == '.').ToArray());
                    }

                }




                double _mahsupDouble = Convert.ToDouble(mahsup);

                return new SuccessDataResult<double>(_mahsupDouble);

            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<double>(0, ex.Message);
            }
        }
        public async Task<IDataResult<XDocument>> GetInvoiceXML(string guid, string belgeTuru, string vergiTcKimlikNo)
        {
            try
            {
                string[] ett = { guid };
                var result = await _connectorService.gelenBelgeleriIndirExtAsync(new gelenBelgeParametreleri
                {
                    ettn = ett,
                    belgeTuru = belgeTuru,
                    belgeFormati = "UBL",
                    vergiTcKimlikNo = vergiTcKimlikNo
                });


                var file = result.@return.GetArchiveFromByteArr().GetEntriesInArchive().First();



                XDocument xml = null;

                foreach (var entry in file.Archive.Entries)
                {
                    using (var stream = entry.Open())
                    {
                       xml = System.Xml.Linq.XDocument.Load(stream);

                    }
                }

                return new SuccessDataResult<XDocument>(xml);

            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<XDocument>(null, ex.Message);
            }
        }

        public async Task<IDataResult<string>> GetInvoiceDocument(FaturaFiltreModel faturaFiltreModel)
        {
            try
            {
                var ett = new string[1];
                ett[0] = faturaFiltreModel.Guid;

                

                //var checkFile = DirectoryHelper.CheckLocalData(faturaFiltreModel.Guid + "." + faturaFiltreModel.BelgeFormati, "Invoices");

                //if(checkFile.Success) return new SuccessDataResult<string>(checkFile.Data, "");

                var result = await _connectorService.gelenBelgeleriIndirAsync(faturaFiltreModel.VergiNo, ett, faturaFiltreModel.BelgeTipi, faturaFiltreModel.BelgeFormati);

                var path = DirectoryHelper.GetLocalDataPath("Invoices") + faturaFiltreModel.Guid + "." + faturaFiltreModel.BelgeFormati;

                var saveResult = result.@return.GetArchiveFromByteArr().GetEntriesInArchive().First().ExtractFile(path);

                return new SuccessDataResult<string>(path, "");

            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<string>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<Fatura>>> ListInvoiceWithDetail(FaturaFiltreModel faturaFiltreModel)
        {
            try
            {

                var serviceResult = await _connectorService.gelenBelgeleriAlAsync(faturaFiltreModel.VergiNo, faturaFiltreModel.SonBelgeSiraNo.ToString(), faturaFiltreModel.BelgeTipi);

                var returnData = new List<Fatura>();

                if (serviceResult.@return == null) return new SuccessDataResult<IEnumerable<Fatura>>(returnData);

                int pp = 0;

                foreach (belge item in serviceResult.@return)
                {
                    var res = UblHelper.LoadAndValidateInvoice(item.belgeVerisi);

                    

                    string[] ett = { item.ettn };
                    var result = await _connectorService.gelenBelgeleriIndirExtAsync(new gelenBelgeParametreleri
                    {
                        ettn=ett,
                        belgeTuru = faturaFiltreModel.BelgeTipi,
                        belgeFormati = "UBL",
                        vergiTcKimlikNo=faturaFiltreModel.VergiNo
                    });

                    //if (pp == 5)
                    //    Console.WriteLine("STOP");

                    var path = DirectoryHelper.GetLocalDataPath("Invoices/xml") + item.gonderenVknTckn + (res.satici.unvan.Length >20 ?res.satici.unvan.Substring(0,20) : res.satici.unvan) + "-" +ett[0] + ".xml";

                    var file = result.@return.GetArchiveFromByteArr().GetEntriesInArchive().First();


                   

                    var subscribeNums = AppsettingHelper.GetStringArrayValue("InvoiceSubscribeNums");

                    string subscribeNum = null;

                    double yuvarlama = 0;

                    double mahsup = 0;

                    foreach (var entry in file.Archive.Entries)
                    {
                        using (var stream = entry.Open())
                        {
                            var xml = System.Xml.Linq.XDocument.Load(stream);

                            yuvarlama =  GetInvoiceRoundingDetail(xml).Result.Data;

                            mahsup = GetInvoiceMahsupDetail(xml).Result.Data;

                            var hasOne = xml.Descendants().Any(x => x.Name.LocalName == "ID" && x.Attribute("schemeID") != null && subscribeNums.Contains(x.FirstAttribute.Value));
                            
                            if(hasOne)
                                subscribeNum = xml.Descendants().FirstOrDefault(x => x.Name.LocalName == "ID" && x.Attribute("schemeID") != null && subscribeNums.Contains(x.FirstAttribute.Value) )?.Value;

                       
                        }
                    }


                    //var saveResult = result.@return.GetArchiveFromByteArr().GetEntriesInArchive().First().ExtractFile(path);


                    //bool dur = false;
                    //if (res.satici.vergiNo == "8770013406")
                    //{
                    //    string[] arrr = { "7e4b2ec1-9cba-4960-887a-03ee82b350ac" };
                    //    var serviceResult11 = await _connectorService.gelenBelgeleriIndirAsync(faturaFiltreModel.VergiNo, arrr, faturaFiltreModel.BelgeTipi, "UBL");
                    //}

                    Console.WriteLine("Gonderen : " + res.satici.unvan + " : " + res.satici.vergiNo +" - "+(pp++).ToString());

                    var fatura = new Fatura
                    {
                        Yuvarlama= Convert.ToDecimal(yuvarlama),
                        Mahsup= Convert.ToDecimal(mahsup),
                        AboneNo = subscribeNum,
                        GonderenTckn = item.gonderenVknTckn.Length == 11 ? item.gonderenVknTckn : null,
                        GonderenVkn = item.gonderenVknTckn.Length == 10 ? item.gonderenVknTckn : null,
                        GonderenPosta = item.gonderenEtiket,
                        Guid = item.ettn,
                        GonderenAdi = res.satici.adi,
                        GonderenSoyad = res.satici.soyadi,
                        GonderenUnvan = res.satici.unvan,
                        GonderenTel = res.satici.tel,
                        GonderenFax = res.satici.fax,
                        GonderenIl = res.satici.sehir,
                        GonderenIlce = res.satici.ilce,
                        GonderenAdres = res.satici.caddeSokak,
                        BelgeTipi = item.belgeTuru,
                        FaturaTarihi = res.faturaTarihi + " " + res.faturaZamani,
                        BelgeTarihi = new DateTime(
                            Convert.ToInt32(item.belgeTarihi.Substring(0, 4)),
                            Convert.ToInt32(item.belgeTarihi.Substring(4, 2)),
                            Convert.ToInt32(item.belgeTarihi.Substring(6, 2))
                            ),
                        AlanUnvan = res.alici.unvan,
                        AlanPosta = res.alici.etiket,
                        AlanVkn = faturaFiltreModel.VergiNo.Length == 10 ? faturaFiltreModel.VergiNo : null,
                        AlanTckn = faturaFiltreModel.VergiNo.Length == 11 ? faturaFiltreModel.VergiNo : null,
                        Sira = Convert.ToInt32(item.belgeSiraNo),
                        FaturaNo = item.belgeNo,
                        GelisTarihi = DateTime.Now,
                        ToplamFiyat = res.vergiHaricToplam.Value,
                        ToplamTutar = res.vergiDahilTutar.Value,
                        OdenecekTutar = res.odenecekTutar.Value,
                        ToplamVergi = 0,
                        TevkifatliFatura = res.tevkifatlar != null

                    };

                    var faturaKalems = new List<FaturaKalem>();

                    foreach (var kalem in res.faturaSatir)
                    {
                        faturaKalems.Add(new FaturaKalem
                        {
                            Ad = kalem.urunAdi[0],
                            Birim = string.IsNullOrEmpty(kalem.miktar.birimKodu) ? kalem.birimKodu : kalem.miktar.birimKodu,
                            Miktar = kalem.miktar.Value,
                            ParaBirimi = kalem.birimFiyat.paraBirimi,
                            Fiyat = kalem.birimFiyat.Value,
                            Sira = kalem.siraNo.Value,
                            Tutar = kalem.birimFiyat.Value * kalem.miktar.Value + (kalem.vergiler == null ? 0 : kalem.vergiler.toplamVergiTutari.Value),
                        });
                    }

                    var faturaVergiKalems = new List<FaturaVergiKalem>();

                    foreach (var vergiKalem in res.vergiler)
                    {
                        fatura.ToplamVergi = fatura.ToplamVergi + vergiKalem.toplamVergiTutari.Value;

                        foreach (var vergiItem in vergiKalem.vergi)
                        {
                            faturaVergiKalems.Add(new FaturaVergiKalem
                            {
                                Ad = vergiItem.ad,
                                Kod = vergiItem.kod,
                                Matrah = vergiItem.matrah == null ? 0 : vergiItem.matrah.Value,
                                Oran = vergiItem.oran,
                                VergiTutari = vergiItem.vergiTutari.Value
                            });
                        }

                    }

                    fatura.FaturaKalems = faturaKalems;
                    fatura.FaturaVergiKalems = faturaVergiKalems;

                    returnData.Add(fatura);
                }


                return new SuccessDataResult<IEnumerable<Fatura>>(returnData);

            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Fatura>>(ex.Message);
            }
        }
        public void Dispose()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        
    }
}





