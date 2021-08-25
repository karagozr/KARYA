using EFinansConnectorService;
using HANEL.COM.INVOICE_SERVICE.Helpers;
using HANEL.MODEL.DataTransferModels.EServisEntegrator;
using HANEL.MODEL.Entities.Muhasebe;
using KARYA.COMMON.DirectoryAndFileHelpers;
using KARYA.COMMON.Helpers;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.COM.INVOICE_SERVICE.Utilities
{
    public class GelenFaturaUtility : IDisposable
    {
        ConnectorServiceClient connectorService;
        public GelenFaturaUtility()
        {
            var time = new TimeSpan(0, 3, 0);
            
            connectorService = new ConnectorServiceClient();

            connectorService.Endpoint.Binding.CloseTimeout = time;
            connectorService.Endpoint.Binding.OpenTimeout = time;
            connectorService.Endpoint.Binding.ReceiveTimeout = time;
            connectorService.Endpoint.Binding.SendTimeout = time;
            connectorService.Endpoint.EndpointBehaviors.Add(CookieHelper.COOKIEBEHAVIOR);
        }

        public async Task<IDataResult<string>> FaturaBelgeGetir(FaturaFiltreModel faturaFiltreModel)
        {

            try
            {
                var ett = new string[1];
                ett[0] = faturaFiltreModel.Guid;

                //var checkFile = DirectoryHelper.CheckLocalData(faturaFiltreModel.Guid + "." + faturaFiltreModel.BelgeFormati, "Invoices");

                //if(checkFile.Success) return new SuccessDataResult<string>(checkFile.Data, "");

                var result = await connectorService.gelenBelgeleriIndirAsync(faturaFiltreModel.VergiNo, ett, faturaFiltreModel.BelgeTipi, faturaFiltreModel.BelgeFormati);

                var path = DirectoryHelper.GetLocalDataPath("Invoices")+faturaFiltreModel.Guid + "." + faturaFiltreModel.BelgeFormati;

                var saveResult = result.@return.GetArchiveFromByteArr().GetEntriesInArchive().First().ExtractFile(path);

                return new SuccessDataResult<string>(path, "");

            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<string>(ex.Message);
            }
        }

        public async Task<IDataResult<Fatura>> FaturaGetir(FaturaFiltreModel faturaFiltreModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<IEnumerable<Fatura>>> FaturaDetayliListele(FaturaFiltreModel faturaFiltreModel)
        {
            try
            {
                //var time = new TimeSpan(0, 3, 0);
                //connectorService.Endpoint.Binding.CloseTimeout = time;
                //connectorService.Endpoint.Binding.OpenTimeout = time;
                //connectorService.Endpoint.Binding.ReceiveTimeout = time;
                //connectorService.Endpoint.Binding.SendTimeout = time;
                //connectorService.Endpoint.EndpointBehaviors.Add(CookieHelper.COOKIEBEHAVIOR);
                gelenBelgeleriAlResponse serviceResult = await connectorService.gelenBelgeleriAlAsync(faturaFiltreModel.VergiNo, faturaFiltreModel.SonBelgeSiraNo.ToString(), faturaFiltreModel.BelgeTipi);
                
                var returnData = new List<Fatura>();

                if (serviceResult.@return == null) return new SuccessDataResult<IEnumerable<Fatura>>(returnData);

                foreach (belge item in serviceResult.@return)
                {
                    var res = UblHelper.LoadAndValidateInvoice(item.belgeVerisi);
                   
                    var fatura = new Fatura
                    {
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
                Console.WriteLine($"SERVICE ERROR :: ({faturaFiltreModel.VergiNo}) {ex.Message}");
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
