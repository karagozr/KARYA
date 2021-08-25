using HANEL.MODEL.DataTransferModels.Accounting;
using HANEL.MODEL.Dtos.Muhasebe;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.Netsis;
using NetOpenX.Rest.Client.BLL;
using NetOpenX.Rest.Client.Model;
using NetOpenX.Rest.Client.Model.Custom;
using NetOpenX.Rest.Client.Model.Enums;
using NetOpenX.Rest.Client.Model.NetOpenX;
using NETSIS.NETOPENX.REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETSIS.NETOPENX.REST.Services
{
    public class NetsisInvoiceService:NetsisBaseService
    {
        ItemSlipsManager _manager;
        public NetsisInvoiceService(Login login) : base(login)
        {
            _manager = new ItemSlipsManager(AUTH);
        }
        public async Task<IDataResult<string>> SaveInvoice(FaturaDto invoice)
        {
            try
            {

                ItemSlips fatura = new ItemSlips();
                ItemSlipsHeader FatUst = new ItemSlipsHeader();
                //KOSULTARIHI
                //FIYATTARIHI
                //fatura.SeriliHesapla = false;
                
                FatUst.Sube_Kodu = invoice.SubeKodu;
                FatUst.Tip = JTFaturaTip.ftAFat;
                FatUst.EXGUMTARIH = Convert.ToDateTime(invoice.FaturaTarihi);
                FatUst.SIPARIS_TEST = Convert.ToDateTime(invoice.FaturaTarihi);
                FatUst.FIYATTARIHI = Convert.ToDateTime(invoice.FaturaTarihi);
                FatUst.EXFIILITARIH = Convert.ToDateTime(invoice.FaturaTarihi);
                FatUst.ODEMETARIHI = Convert.ToDateTime(invoice.FaturaTarihi);
                FatUst.ENTEGRE_TRH = Convert.ToDateTime(invoice.FaturaTarihi);
                FatUst.GIB_FATIRS_NO = invoice.FaturaNo;
                FatUst.Tarih = Convert.ToDateTime(invoice.FaturaTarihi);
                FatUst.FiiliTarih = Convert.ToDateTime(invoice.FaturaTarihi);
                FatUst.EKACK1 = invoice.Aciklama;
                FatUst.EKACK2 = invoice.Aciklama2;
                FatUst.EKACK15 = invoice.KayitTarihi==null?"": invoice.KayitTarihi.ToString();
                //FatUst.KDV_DAHILMI = false;
                FatUst.Aciklama = invoice.Aciklama;
                FatUst.Proje_Kodu = invoice.ProjeKodu;
                FatUst.CariKod = invoice.CariKodu;
                FatUst.TIPI = JTFaturaTipi.ft_Acik;
                FatUst.FATIRS_NO = invoice.FaturaNo;
                FatUst.EKACK16 = invoice.Guid;
                fatura.KayitliNumaraOtomatikGuncellensin = true;
                fatura.FatUst = FatUst;
                fatura.Kalems = new List<ItemSlipLines>();

                foreach (var item in invoice.FaturaDetays)
                {
                    fatura.Kalems.Add(new ItemSlipLines
                    {
                        STra_GCMIK = Convert.ToDouble(item.Miktar),
                        StokKodu = item.StokKodu,
                        STra_DOVTIP = 0,
                        MuhasebeKodu = item.MuhasebeKodu,
                        ReferansKodu = item.ReferansKodu,
                        STra_KDV = Convert.ToDouble(item.Kdv),
                        //AlisKDVOran = Convert.ToDouble(10),
                        STra_BF = Convert.ToDouble(item.Fiyat),
                        STra_NF = Convert.ToDouble(item.Fiyat),
                        ProjeKodu = item.ProjeKodu,
                        Ekalan = item.KalemAciklama,
                        D_YEDEK10 = Convert.ToDateTime(invoice.FaturaTarihi),
                        Stra_FiiliTar = Convert.ToDateTime(invoice.FaturaTarihi),
                        STra_TAR = Convert.ToDateTime(invoice.FaturaTarihi),
                        STra_testar = Convert.ToDateTime(invoice.FaturaTarihi)


                    });
                }

                var result =  await _manager.PostInternalAsync(fatura);

                if (!result.IsSuccessful)
                {
                    return new ErrorDataResult<string>("NetopenX hata : " + result.ErrorDesc);
                }

                return new SuccessDataResult<string>(result.Data.FatUst.FATIRS_NO,"");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>(ex.Message);
            }
            


        }
        public async Task<IResult> DeleteInvoice(string faturaNo, string cariKodu)
        {
            try
            {
                var result = await _manager.DeleteInternalByIdAsync($"{JTFaturaTip.ftAFat};{faturaNo};{cariKodu}");  

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

        }
        public async Task<IDataResult<IEnumerable<FaturaDto>>> ListInvoice(InvoiceFilterModel invoiceFilterModel)
        {
            try
            {
                var _queryManager = new QueryManager(AUTH);


                var query = (
                        $" select F.FaturaNo, F.FaturaTarihi, NF.ACIKLAMA AS Aciklama, NF.CARI_KODU as CariKodu, " +
                        $" NF.CARI_ISIM as CariUnvan, F.GonderenUnvan,F.AlanUnvan, F.AlanVkn, " +
                        $" case when F.GonderenVkn is null then GonderenTckn else F.GonderenVkn end as GonderenVkn," +
                        $" F.GonderenTckn, nf.ACIK1 as Aciklama1,NF.ACIK2 as Aciklama2," +
                        $" F.ToplamTutar,f.ToplamFiyat,F.ToplamVergi, " +
                        $" f.[Guid], case when NF.ACIK16 is not null then CAST(1 as bit) else CAST(0 as bit) end as IsSaved " +
                        $" from HANEL_APP..Fatura as f left join " +
                        $" (select case when F.GIB_FATIRS_NO is null then F.FATIRS_NO else F.GIB_FATIRS_NO end as FATIRS_NO, F.TARIH,F.ACIKLAMA," +
                        $" F.CARI_KODU,C.CARI_ISIM,C.VERGI_NUMARASI,E.ACIK1,E.ACIK2,E.ACIK16  from TBLFATUIRS as F " +
                        $" inner join TBLFATUEK as E on F.FATIRS_NO = E.FATIRSNO " +
                        $" inner join TBLCASABIT as C on F.CARI_KODU = C.CARI_KOD " +
                        $" where FTIRSIP=2 and E.FKOD=2) as NF on NF.ACIK16=f.[Guid]  where 1=1 ");
                        

                if(invoiceFilterModel.FirstDate!=null && invoiceFilterModel.LastDate != null)
                {
                    query+=$" and f.FaturaTarihi between '{invoiceFilterModel.FirstDate.ToString("yyyy-MM-dd")}' and '{invoiceFilterModel.LastDate.ToString("yyyy-MM-dd")}' ";
                }
                if(!string.IsNullOrEmpty(invoiceFilterModel.SenderVkn) && invoiceFilterModel.SenderVkn.Length>=10)
                {
                    query += $" and f.GonderenVkn = '{invoiceFilterModel.SenderVkn}' ";
                }
                if (!string.IsNullOrEmpty(invoiceFilterModel.SenderName))
                {
                    query += $" and f.GonderenUnvan like '%{invoiceFilterModel.SenderName}%' ";
                }
                if (!string.IsNullOrEmpty(invoiceFilterModel.CompanyVkn) && invoiceFilterModel.CompanyVkn.Length >= 10)
                {
                    query += $" and f.AlanVkn = '{invoiceFilterModel.CompanyVkn}' ";
                }
                if (!string.IsNullOrEmpty(invoiceFilterModel.CompanyVkn) && invoiceFilterModel.CompanyVkn.Length >= 10)
                {
                    query += $" and f.AlanVkn = '{invoiceFilterModel.CompanyVkn}' ";
                }

                query += " order by F.FaturaTarihi desc ";

                var result = await _queryManager.GetInternalAsync(query);

                if (!result.IsSuccessful)
                {
                    return new ErrorDataResult<IEnumerable<FaturaDto>>("NetopenX hata : " + result.ErrorDesc);
                }

                var resultList = result.Data.Select(x => new FaturaDto {
                    Guid            = x.GetValue("Guid").ToString(),
                    Kayitli         = Convert.ToBoolean(x.GetValue("IsSaved")),
                    FaturaNo        = x.GetValue("FaturaNo").ToString(),
                    Aciklama        = x.GetValue("Aciklama").ToString(),
                    Aciklama1       = x.GetValue("Aciklama1").ToString(),
                    Aciklama2       = x.GetValue("Aciklama2").ToString(),
                    GonderenUnvan   = x.GetValue("GonderenUnvan").ToString(),
                    AlanUnvan       = x.GetValue("AlanUnvan").ToString(),
                    FaturaTarihi    = Convert.ToDateTime(x.GetValue("FaturaTarihi").ToString()),
                    CariKodu        = x.GetValue("CariKodu").ToString(),
                    CariUnvan       = x.GetValue("CariUnvan").ToString(),
                    CariVkn         = x.GetValue("GonderenVkn").ToString(),
                    CariTckn        = x.GetValue("GonderenTckn").ToString(),
                    ToplamFiyat     = Convert.ToDecimal(x.GetValue("ToplamFiyat")),
                    ToplamVergi     = Convert.ToDecimal(x.GetValue("ToplamVergi")),
                    ToplamTutar     = Convert.ToDecimal(x.GetValue("ToplamTutar"))
                });

                return new SuccessDataResult<IEnumerable<FaturaDto>>(resultList);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<FaturaDto>>(ex.Message);
            }

        }
        public async Task<IDataResult<FaturaDto>> CheckInvoice(string guid)
        {
            try
            {
                var _queryManager = new QueryManager(AUTH);

                var query =  $"  select nf.FATIRS_NO, nf.CARI_KODU, nf.KAYITTARIHI,ACIK15 from TBLFATUEK as nfe " +
                    $"inner join TBLFATUIRS as nf on nf.FATIRS_NO = nfe.FATIRSNO and FTIRSIP = 2 " +
                    $"where ACIK16 = '{guid}' and nfe.FKOD = 2 ";

                var resultFaturaBaslik = await _queryManager.GetInternalAsync(query);

                if (!resultFaturaBaslik.IsSuccessful) return new ErrorDataResult<FaturaDto>("NetopenX hata : " + resultFaturaBaslik.ErrorDesc);

                if (resultFaturaBaslik.Data.Count == 0) return new SuccessDataResult<FaturaDto>(null, "Kayıt bulunamadı");

                var baslik = resultFaturaBaslik.Data.FirstOrDefault();

                var faturaDto = new FaturaDto
                {
                    FaturaNo = baslik.GetValue("FATIRS_NO").ToString(),
                    CariKodu = baslik.GetValue("CARI_KODU").ToString(),
                    KayitTarihi = baslik.GetValue("KAYITTARIHI") !=null ?baslik.GetValue("KAYITTARIHI").ToString():null,
                    DuzenlemeTarihi = baslik.GetValue("ACIK15") != null ?baslik.GetValue("ACIK15").ToString():null
                };
            
                return new SuccessDataResult<FaturaDto>(faturaDto);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<FaturaDto>(ex.Message);
            }
        }
        public async Task<IDataResult<FaturaDto>> GetInvoice(string guid)
        {
            try
            {
                var _queryManager = new QueryManager(AUTH);


                var faturaBaslikQuery =
                    $"  select top 1 case when nfe.ACIK16 = f.[Guid] then CAST(1 as bit) else CAST(0 as bit) end as Kayitli, " +
                    $"  nf.ACIKLAMA as Aciklama, nfe.ACIK1  as Aciklama1, nfe.ACIK2  as Aciklama2, " +
                    $" 	isnull(nf.SUBE_KODU,nsb.SUBE_KODU) as SubeKodu, " +
                    $" 	nf.PROJE_KODU as ProjeKodu, " +
                    $" 	f.Id,F.[Guid],f.AlanVkn, " +
                    $" 	isnull(nf.GIB_FATIRS_NO,f.FaturaNo) as FaturaNo, " +
                    $" 	isnull(nf.TARIH,f.FaturaTarihi) as FaturaTarihi, " +
                    $" 	isnull(f.GonderenVkn,f.GonderenTckn) as GonderenVkn, " +
                    $" 	case when nc.CARI_KOD is not null then nc.CARI_KOD  else (case when nc1.CARI_KOD is not null then nc1.CARI_KOD else nc2.CARI_KOD end) end as CariKodu,   " +
                    $" 	case when nc.CARI_KOD is not null then nc.CARI_ISIM else (case when nc1.CARI_ISIM is not null then nc1.CARI_ISIM else nc2.CARI_ISIM end) end as CariAdi, " +
                    $" 	f.ToplamTutar,f.ToplamFiyat,f.ToplamVergi " +
                    $"  from HANEL_APP..Fatura as f " +
                    $" 	left join TBLFATUEK as nfe on f.[Guid]=nfe.ACIK16 and nfe.FKOD=2  " +
                    $" 	left join TBLFATUIRS as nf on nf.FATIRS_NO=nfe.FATIRSNO and FTIRSIP=2 " +
                    $" 	left join TBLCASABIT as nc on nf.CARI_KODU=nc.CARI_KOD " +
                    $" 	left join TBLCASABIT as nc1 on f.GonderenVkn=nc1.VERGI_NUMARASI " +
                    $"  left join (select c.CARI_KOD,CARI_ISIM,TCKIMLIKNO,CARI_TIP from TBLCASABIT as c inner join TBLCASABITEK as ce on c.CARI_KOD=ce.CARI_KOD) as nc2 on f.GonderenTckn=nc2.TCKIMLIKNO " +
                    $" 	left join (select * from TBLSUBELER where ISLETME_KODU!=SUBE_KODU) as nsb on f.AlanVkn=nsb.VNO  " +
                    $"  where [Guid] = '{guid}'   order by nc1.CARI_TIP desc";

                var resultFaturaBaslik = await _queryManager.GetInternalAsync(faturaBaslikQuery);

                if (!resultFaturaBaslik.IsSuccessful) return new ErrorDataResult<FaturaDto>("NetopenX hata : " + resultFaturaBaslik.ErrorDesc);

                var faturaKalemQuery =
                        $" select EKALAN,STHAR_GCMIK,STOK_KODU,MUH_KODU,PROJE_KODU,k.S_YEDEK1,STHAR_DOVTIP,STHAR_KDV,STHAR_NF,STHAR_BF " +
                        $" from TBLSTHAR as k inner join TBLFATUEK as e on e.FATIRSNO = k.FISNO and e.FKOD=2 and STHAR_GCKOD='G' " +
                        $" where e.ACIK16 = '{guid}'  ";

                var resultFaturaKalem = await _queryManager.GetInternalAsync(faturaKalemQuery);
                if (!resultFaturaKalem.IsSuccessful) return new ErrorDataResult<FaturaDto>("NetopenX hata : " + resultFaturaKalem.ErrorDesc);

                var baslik = resultFaturaBaslik.Data.FirstOrDefault();
                var faturaDto = new FaturaDto
                {
                    Id = Convert.ToInt32(baslik.GetValue("Id")),
                    Guid = baslik.GetValue("Guid").ToString(),
                    Kayitli = Convert.ToBoolean(baslik.GetValue("Kayitli")),
                    FaturaNo = baslik.GetValue("FaturaNo").ToString(),
                    Aciklama = baslik.GetValue("Aciklama").ToString(),
                    Aciklama1 = baslik.GetValue("Aciklama1").ToString(),
                    Aciklama2 = baslik.GetValue("Aciklama2").ToString(),
                    Vkn = baslik.GetValue("AlanVkn").ToString(),
                    FaturaTarihi = Convert.ToDateTime(baslik.GetValue("FaturaTarihi").ToString()),
                    CariKodu = baslik.GetValue("CariKodu").ToString(),
                    CariUnvan = baslik.GetValue("CariAdi").ToString(),
                    CariVkn = baslik.GetValue("GonderenVkn").ToString(),
                    ToplamFiyat = Convert.ToDecimal(baslik.GetValue("ToplamFiyat")),
                    ToplamVergi = Convert.ToDecimal(baslik.GetValue("ToplamVergi")),
                    ToplamTutar = Convert.ToDecimal(baslik.GetValue("ToplamTutar")),
                    SubeKodu = Convert.ToInt32(baslik.GetValue("SubeKodu")),
                    ProjeKodu = baslik.GetValue("ProjeKodu").ToString()
                };

                var faturaDetay = resultFaturaKalem.Data.Select(x => new FaturaDetayDto
                {
                    Fiyat = Convert.ToDecimal(x.GetValue("STHAR_NF")),
                    Tutar = Convert.ToDecimal(x.GetValue("STHAR_NF"))*(Convert.ToDecimal(x.GetValue("STHAR_KDV"))+100)/100,
                    Kdv = Convert.ToDecimal(x.GetValue("STHAR_KDV")),
                    StokKodu = x.GetValue("STOK_KODU").ToString(),
                    MuhasebeKodu = x.GetValue("MUH_KODU").ToString(),
                    KalemAciklama = x.GetValue("EKALAN").ToString(),
                    ProjeKodu = x.GetValue("PROJE_KODU").ToString(),
                    ReferansKodu = x.GetValue("S_YEDEK1").ToString(),
                    Miktar = Convert.ToDecimal(x.GetValue("STHAR_GCMIK")),
                });;

                faturaDto.FaturaDetays = faturaDetay;

                return new SuccessDataResult<FaturaDto>(faturaDto);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<FaturaDto>(ex.Message);
            }
        }
        public async Task<IDataResult<IEnumerable<YevmiyeFis>>> GetYevmiyeFis(string faturaNo, short faturaIrsaliye, string cariKodu)
        {
            var ftrNo = faturaNo.Length > 15 ? faturaNo.Substring(0, 15) : faturaNo;
            var entegreKey = $"01{faturaIrsaliye}{ftrNo}{cariKodu}";
            try
            {
                var _queryManager = new QueryManager(AUTH);


                var query = $" select ROW_NUMBER() OVER (ORDER BY GRUP_SIRA asc, HESAP_KODU asc) as ID,* from (select " +
                            $" case when BA=2 then '  '+mp.HESAP_KODU else mp.HESAP_KODU end as HESAP_KODU, dbo.TRK(mp.HS_ADI) as HESAP_ADI, dbo.TRK(ACIKLAMA) as ACIKLAMA," +
                            $" case when BA=1 then TUTAR else 0 end as BORC_TUTAR," +
                            $" case when BA=2 then TUTAR else 0 end as ALACAK_TUTAR," +
                            $" case when BA=1 then 1 when BA=2 then 2 else 3 end as GRUP_SIRA," +
                            $" dbo.TRK(p.PROJE_ACIKLAMA) as PREOJE, dbo.TRK(GRUP_ISIM) as REFERANS," +
                            $" dbo.TRK(ACIKLAMA2) as ACIKLAMA2,  dbo.TRK(HESAPISMI) as ACIKLAMA3 " +
                            $" from TBLMUHFIS as mf " +
                            $" inner join TBLMUPLAN as mp on mf.HES_KOD = mp.HESAP_KODU " +
                            $" inner join TBLPROJE as p on mf.PROJE_KODU = p.PROJE_KODU " +
                            $" inner join TBLMUHAREF as mr on mf.REF_KOD = mr.GRUP_KOD " +
                            $" inner join TBLMUPLAN as mp2 on SUBSTRING(mf.HES_KOD,1,3) =mp2.HESAP_KODU " +
                            $" where ENTEGREFKEY like '{entegreKey}'" +
                            $" union all " +
                            $" select " +
                            $"	case when BA=2 then '  '+mp.HESAP_KODU else mp.HESAP_KODU end as HESAP_KODU," +
                            $"	dbo.TRK(mp.HS_ADI) as HESAP_ADI," +
                            $"	'' as ACIKLAMA," +
                            $"	case when BA=1 then SUM(TUTAR) else 0 end as BORC_TUTAR," +
                            $"	case when BA=2 then SUM(TUTAR) else 0 end as ALACAK_TUTAR," +
                            $"	case when BA=1 then 1 when BA=2 then 2 else 3 end as GRUP_SIRA," +
                            $"	'' as PREOJE, '' as REFERANS," +
                            $"	'' as ACIKLAMA2, " +
                            $"	'' as ACIKLAMA3  " +
                            $" from TBLMUHFIS as mf " +
                            $" inner join TBLMUPLAN as mp on SUBSTRING(mf.HES_KOD,1,3) =mp.HESAP_KODU " +
                            $" where ENTEGREFKEY like '{entegreKey}' " +
                            $" group by mp.HESAP_KODU,mp.HS_ADI,BA " +
                            $" union all " +
                            $" select HESAP_KODU, HESAP_ADI,ACIKLAMA, SUM(BORC_TUTAR) as BORC_TUTAR ,SUM(ALACAK_TUTAR) as ALACAK_TUTAR,3 as GRUP_SIRA, " +
                            $"  PREOJE,REFERANS, ACIKLAMA2, ACIKLAMA3 from " +
                            $"  (select " +
                            $" '' as HESAP_KODU," +
                            $" 'TOPLAM' as HESAP_ADI," +
                            $" '' as ACIKLAMA," +
                            $" case when BA=1 then SUM(TUTAR) else 0 end as BORC_TUTAR," +
                            $" case when BA=2 then SUM(TUTAR) else 0 end as ALACAK_TUTAR," +
                            $" '' as PREOJE, '' as REFERANS," +
                            $" '' as ACIKLAMA2, " +
                            $" '' as ACIKLAMA3 " +
                            $" from TBLMUHFIS as mf " +
                            $" where ENTEGREFKEY like '{entegreKey}' " +
                            $" group by BA) as t1 " +
                            $" group by HESAP_KODU, HESAP_ADI,ACIKLAMA,PREOJE,REFERANS, ACIKLAMA2, ACIKLAMA3 " +
                            $" ) as T ";

                var result = await _queryManager.GetInternalAsync(query);

                var resultList = new List<YevmiyeFis>();

                foreach (var item in result.Data)
                {
                    resultList.Add(new YevmiyeFis
                    {
                        HesapKodu = item.GetValue("HESAP_KODU").ToString(),
                        HesapAdi = item.GetValue("HESAP_ADI").ToString(),
                        Borc = Convert.ToDouble(item.GetValue("BORC_TUTAR")),
                        Alacak = Convert.ToDouble(item.GetValue("ALACAK_TUTAR")),
                        ProjeAdi = item.GetValue("PREOJE").ToString(),
                        ReferansAdi = item.GetValue("REFERANS").ToString(),
                        Aciklama = item.GetValue("ACIKLAMA").ToString(),
                        Aciklama2 = item.GetValue("ACIKLAMA2").ToString(),
                        Aciklama3 = item.GetValue("ACIKLAMA3").ToString()

                    });
                }

                return new SuccessDataResult<IEnumerable<YevmiyeFis>>(resultList);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<IEnumerable<YevmiyeFis>>(null, ex.Message);
            }
        }
    }
}


