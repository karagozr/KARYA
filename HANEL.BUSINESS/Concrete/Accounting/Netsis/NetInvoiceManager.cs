using Dapper;
using HANEL.BUSINESS.Abstract.Accounting;
using HANEL.BUSINESS.Concrete.Accounting.Netsis.NetOpenX;
using HANEL.MODEL.DataTransferModels.Accounting;
using HANEL.MODEL.Dtos.Muhasebe;
using KARYA.CORE.Concrete.Dapper;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.Netsis;
using NetOpenX.Rest.Client;
using NetOpenX.Rest.Client.BLL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Accounting.Netsis
{
    public class NetInvoiceManager : DapperRepository, IErpInvoiceManager, IDisposable
    {
        ItemSlipsManager _manager;
        public oAuth2 AUTH;
        public NetInvoiceManager() : base("NETSISConnection"){ }

        public NetInvoiceManager(Login login) : base("NETSISConnection")
        {
            using(NetOpenXAuth auth =  new NetOpenXAuth())
            {
                var result = auth.Login(login).Result;
                if (result.Success) AUTH = auth.AUTH;
            }
            _manager = new ItemSlipsManager(AUTH);
        }
        public async Task<IDataResult<string>> SaveInvoice(FaturaDto invoice, Login login = null)
        {
            using (var _service = new NetsisInvoiceService(login))
            {
                return await _service.SaveInvoice(invoice);
            }
        }
        public async Task<IResult> DeleteInvoice(string faturaNo, string cariKodu, Login login = null)
        {
            using (var _service = new NetsisInvoiceService(login))
            {
                return await _service.DeleteInvoice(faturaNo, cariKodu);
            }

        }
        public async Task<IDataResult<IEnumerable<FaturaDto>>> ListInvoice(InvoiceFilterModel invoiceFilterModel)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    
                    var query = (
                         $" select f.Id,f.DefaultNote,f.UserNotes, case when NF.FATIRSNO is null then F.FaturaNo else NF.FATIRSNO end as FaturaNo, F.FaturaTarihi, NF.ACIKLAMA AS Aciklama, NF.CARI_KODU as CariKodu, " +
                         $" NF.CARI_ISIM as CariUnvan, F.GonderenUnvan,F.AlanUnvan, F.AlanVkn as Vkn, " +
                         $" case when F.GonderenVkn is null then GonderenTckn else F.GonderenVkn end as CariVkn," +
                         $" F.GonderenTckn as CariTckn, nf.ACIK1 as Aciklama1,NF.ACIK2 as Aciklama2," +
                         $" F.ToplamTutar,f.ToplamFiyat,F.ToplamVergi, " +
                         $" f.[Guid], case when NF.ACIK16 is not null then CAST(1 as bit) else CAST(0 as bit) end as Kayitli " +
                         $" from HANEL_APP..Fatura as f left join " +
                         $" (select case when F.GIB_FATIRS_NO is null then F.FATIRS_NO else F.GIB_FATIRS_NO end as FATIRS_NO,GIB_FATIRS_NO,FATIRS_NO as FATIRSNO, F.TARIH,F.ACIKLAMA," +
                         $" F.CARI_KODU,C.CARI_ISIM,C.VERGI_NUMARASI,E.ACIK1,E.ACIK2,E.ACIK16  from TBLFATUIRS as F " +
                         $" inner join TBLFATUEK as E on F.FATIRS_NO = E.FATIRSNO " +
                         $" inner join TBLCASABIT as C on F.CARI_KODU = C.CARI_KOD " +
                         $" where FTIRSIP=2 and E.FKOD='2') as NF on NF.ACIK16=f.[Guid] or NF.GIB_FATIRS_NO=f.FaturaNo where 1=1 ");

                    
                    if (invoiceFilterModel.FirstDate != null && invoiceFilterModel.LastDate != null)
                    {
                        query += $" and f.FaturaTarihi between '{invoiceFilterModel.FirstDate?.ToString("yyyy-MM-dd")} 00:00:00' and '{invoiceFilterModel.LastDate?.ToString("yyyy-MM-dd")} 23:59:59' ";
                    }
                    else if (invoiceFilterModel.IncomeFirstDate != null && invoiceFilterModel.IncomeLastDate != null)
                    {
                        query += $" and f.GelisTarihi between '{invoiceFilterModel.IncomeFirstDate?.ToString("yyyy-MM-dd")} 00:00:00' and '{invoiceFilterModel.IncomeLastDate?.ToString("yyyy-MM-dd")} 23:59:59' ";
                    }
                    if (!string.IsNullOrEmpty(invoiceFilterModel.SenderVkn) && invoiceFilterModel.SenderVkn.Length >= 10)
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

                    var data = await connection.QueryAsync<FaturaDto>(query);

                    return new SuccessDataResult<IEnumerable<FaturaDto>>(data);
                }
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
                using (var connection = CreateMsSqlConnection())
                {
                    var query = $"  select nf.FATIRS_NO as FaturaNo, nf.CARI_KODU as CariKodu, nf.KAYITTARIHI as KayitTarihi, ACIK15 as DuzenlemeTarihi from TBLFATUEK as nfe " +
                    $"inner join TBLFATUIRS as nf on nf.FATIRS_NO = nfe.FATIRSNO and FTIRSIP = 2 " +
                    $"where ACIK16 = '{guid}' and nfe.FKOD = '2' ";

                    
                    var data = await connection.QueryFirstOrDefaultAsync<FaturaDto>(query);

                    return new SuccessDataResult<FaturaDto>(data);
                }
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
                using (var connection = CreateMsSqlConnection())
                {
                    var faturaBaslikQuery =
                     $"  select top 1 case when nf.ACIK16 = f.[Guid] then CAST(1 as bit) else CAST(0 as bit) end as Kayitli, " +
                     $"  dbo.TRK(nf.ACIKLAMA) as Aciklama, dbo.TRK(nf.ACIK1)  as Aciklama1, dbo.TRK(nf.ACIK2)  as Aciklama2, " +
                     $" 	isnull(nf.SUBE_KODU,nsb.SUBE_KODU) as SubeKodu, " +
                     $" 	nf.PROJE_KODU as ProjeKodu, " +
                     $" 	f.Id,F.[Guid],f.AlanVkn as Vkn, " +
                     $" 	isnull(dbo.TRK(nf.GIB_FATIRS_NO),f.FaturaNo) as FaturaNo, " +
                     $" 	isnull(nf.TARIH,f.FaturaTarihi) as FaturaTarihi, " +
                     $" 	isnull(f.GonderenVkn,f.GonderenTckn) as CariVkn, " +
                     $" 	case when nc.CARI_KOD is not null then dbo.TRK(nc.CARI_KOD)  else (case when nc1.CARI_KOD is not null then dbo.TRK(nc1.CARI_KOD) else dbo.TRK(nc2.CARI_KOD) end) end as CariKodu,   " +
                     $" 	case when nc.CARI_KOD is not null then dbo.TRK(nc.CARI_ISIM) else (case when nc1.CARI_ISIM is not null then dbo.TRK(nc1.CARI_ISIM) else dbo.TRK(nc2.CARI_ISIM) end) end as CariUnvan , " +
                     $" 	f.ToplamTutar,f.ToplamFiyat,f.ToplamVergi " +
                     $"  from HANEL_APP..Fatura as f " +
                     $" 	left join (select t1.*,t2.ACIK16,t2.ACIK15,t2.ACIK1,t2.ACIK2,t2.FKOD from TBLFATUIRS as t1 inner join TBLFATUEK as t2 on t1.FATIRS_NO=t2.FATIRSNO ) as nf on (f.[Guid]=nf.ACIK16 or f.FaturaNo=nf.GIB_FATIRS_NO) and nf.FKOD='2'  " +
                     $" 	left join TBLCASABIT as nc on nf.CARI_KODU=nc.CARI_KOD " +
                     $" 	left join TBLCASABIT as nc1 on f.GonderenVkn=nc1.VERGI_NUMARASI " +
                     $"  left join (select c.CARI_KOD,CARI_ISIM,TCKIMLIKNO,CARI_TIP from TBLCASABIT as c inner join TBLCASABITEK as ce on c.CARI_KOD=ce.CARI_KOD) as nc2 on f.GonderenTckn=nc2.TCKIMLIKNO " +
                     $" 	left join (select * from TBLSUBELER where ISLETME_KODU!=SUBE_KODU) as nsb on f.AlanVkn=nsb.VNO  " +
                     $"  where [Guid] = '{guid}'   order by nc1.CARI_TIP desc";

                    var dataFaturaBaslik = await connection.QueryFirstOrDefaultAsync<FaturaDto>(faturaBaslikQuery);

                    var faturaKalemQuery =
                            $" select dbo.TRK(EKALAN) as KalemAciklama, " +
                            $" STHAR_GCMIK as Miktar, " +
                            $" STOK_KODU as StokKodu, " +
                            $" MUH_KODU as MuhasebeKodu, " +
                            $" k.PROJE_KODU as ProjeKodu, " +
                            $" k.S_YEDEK1 as ReferansKodu, " +
                            $" STHAR_DOVTIP, " +
                            $" STHAR_KDV as Kdv, " +
                            $" STHAR_NF as Fiyat, " +
                            $" (STHAR_GCMIK*STHAR_BF*(STHAR_KDV+100))/100 as Tutar " +
                            $" from HANEL_APP..Fatura as f " +
                            $" inner join (select t1.*,t2.ACIK16,t2.ACIK15,t2.ACIK1,t2.ACIK2,t2.FKOD from TBLFATUIRS as t1 inner join TBLFATUEK as t2 on t1.FATIRS_NO = t2.FATIRSNO ) as nf on f.[Guid]= nf.ACIK16 or f.FaturaNo = nf.GIB_FATIRS_NO " +
                            $" right join TBLSTHAR as k on nf.FATIRS_NO = k.FISNO " +
                            $" where f.[Guid] = '{guid}'  ";

                    var dataFaturaKalem = await connection.QueryAsync<FaturaDetayDto>(faturaKalemQuery);

                    dataFaturaBaslik.FaturaDetays = dataFaturaKalem;

                    return new SuccessDataResult<FaturaDto>(dataFaturaBaslik);
                }
                
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<FaturaDto>(ex.Message);
            }
        }
        public async Task<IDataResult<YevmiyeFisInfo>> GetYevmiyeFis(string faturaNo, short faturaIrsaliye, string cariKodu)
        {
            
            try
            {
                var ftrNo = faturaNo.Length > 15 ? faturaNo.Substring(0, 15) : faturaNo;
                var entegreKey = $"01{faturaIrsaliye}{ftrNo}{cariKodu}";

                using (var connection = CreateMsSqlConnection())
                {
                    var query = $" select ROW_NUMBER() OVER (ORDER BY GRUP_SIRA asc, HESAP_KODU asc) as Id," +
                    $" HESAP_KODU as HesapKodu, " +
                    $" HESAP_ADI as HesapAdi, " +
                    $" BORC_TUTAR as Borc," +
                    $" ALACAK_TUTAR as Alacak, " +
                    $" ProjeAdi, " +
                    $" REFERANS as ReferansAdi, " +
                    $" ACIKLAMA as Aciklama, " +
                    $" ACIKLAMA2 as Aciklama1, " +
                    $" ACIKLAMA3 as Aciklama2 from (select " +
                    $" case when BA=2 then '  '+mp.HESAP_KODU else mp.HESAP_KODU end as HESAP_KODU, dbo.TRK(mp.HS_ADI) as HESAP_ADI, dbo.TRK(ACIKLAMA) as ACIKLAMA," +
                    $" case when BA=1 then TUTAR else 0 end as BORC_TUTAR," +
                    $" case when BA=2 then TUTAR else 0 end as ALACAK_TUTAR," +
                    $" case when BA=1 then 1 when BA=2 then 2 else 3 end as GRUP_SIRA," +
                    $" dbo.TRK(p.PROJE_ACIKLAMA) as ProjeAdi, dbo.TRK(GRUP_ISIM) as REFERANS," +
                    $" dbo.TRK(ACIKLAMA2) as ACIKLAMA2,  dbo.TRK(HESAPISMI) as ACIKLAMA3 " +
                    $" from TBLMUHFIS as mf " +
                    $" inner join TBLMUPLAN as mp on mf.HES_KOD = mp.HESAP_KODU " +
                    $" inner join TBLPROJE as p on mf.PROJE_KODU = p.PROJE_KODU " +
                    $" inner join TBLMUHAREF as mr on mf.REF_KOD = mr.GRUP_KOD " +
                    $" inner join TBLMUPLAN as mp2 on SUBSTRING(mf.HES_KOD,1,3) =mp2.HESAP_KODU " +
                    $" where ENTEGREFKEY like '{entegreKey}'" +
                    $" union all " +
                    $" select " +
                    $" case when BA=2 then '  '+mp.HESAP_KODU else mp.HESAP_KODU end as HESAP_KODU," +
                    $" dbo.TRK(mp.HS_ADI) as HESAP_ADI," +
                    $" '' as ACIKLAMA," +
                    $" case when BA=1 then SUM(TUTAR) else 0 end as BORC_TUTAR," +
                    $" case when BA=2 then SUM(TUTAR) else 0 end as ALACAK_TUTAR," +
                    $" case when BA=1 then 1 when BA=2 then 2 else 3 end as GRUP_SIRA," +
                    $" '' as PREOJE, '' as REFERANS," +
                    $" '' as ACIKLAMA2, " +
                    $" '' as ACIKLAMA3  " +
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


                    var data = await connection.QueryAsync<YevmiyeFis>(query);


                    var fisInfoDataQuery = $" select " +
                    $" FISNO as FisNo, " +
                    $" s.SUBE_KODU as BranchCode, " +
                    $" dbo.TRK(s.UNVAN) as BranchName, " +
                    $" s1.SUBE_KODU as FirmCode, " +
                    $" dbo.TRK(s1.UNVAN) as FirmName " +
                    $" from TBLMUHFIS as f " +
                    $" inner join TBLSUBELER as s on f.SUBE_KODU=s.SUBE_KODU " +
                    $" inner join TBLSUBELER as s1 on s.ISLETME_KODU=s1.SUBE_KODU " +
                    $" where ENTEGREFKEY like '{entegreKey}' ";

                    var fisInfoData = await connection.QueryFirstOrDefaultAsync<YevmiyeFisInfo>(fisInfoDataQuery);
                    fisInfoData.YevmiyeFisList = data;



                    return new SuccessDataResult<YevmiyeFisInfo>(fisInfoData);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<YevmiyeFisInfo>(ex.Message);
            }
            
        }

        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }

    }
}
