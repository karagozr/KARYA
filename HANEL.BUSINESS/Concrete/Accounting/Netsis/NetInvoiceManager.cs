using Dapper;
using HANEL.BUSINESS.Abstract.Accounting;
using HANEL.BUSINESS.Concrete.Accounting.Netsis.NetOpenX;
using HANEL.MODEL.DataTransferModels.Accounting;
using HANEL.MODEL.Dtos.Muhasebe;
using KARYA.COMMON.Helpers;
using KARYA.CORE.Concrete.Dapper;
using KARYA.CORE.Entities.Enum;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.Netsis;
using Microsoft.Extensions.Configuration;
using NetOpenX.Rest.Client;
using NetOpenX.Rest.Client.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Accounting.Netsis
{
    public class NetInvoiceManager : DapperRepository, IErpInvoiceManager, IDisposable
    {
        
        ItemSlipsManager _manager;
        public oAuth2 AUTH;
        IConfiguration _configuration;
        IInvoiceManager _invoiceManager;
        private Login _netLogin; 
        public NetInvoiceManager(IConfiguration configuration, IInvoiceManager invoiceManager) : base("NETSISConnection"){
            _configuration = configuration;
            _invoiceManager = invoiceManager;
            _netLogin = new KARYA.MODEL.Entities.Netsis.Login
            {
                NetsisUser = _configuration["NetsisEnv:NetsisUser"],
                NetsisPassword = _configuration["NetsisEnv:NetsisPassword"],
                DbName = _configuration["NetsisEnv:DbName"],
                NetOpenXUrl = _configuration["NetsisEnv:NetOpenXUrl"],
                BranchCode = 0
            };
        }

        public NetInvoiceManager(Login login, IConfiguration configuration, IInvoiceManager invoiceManager) : base("NETSISConnection")
        {
            _configuration = configuration;
            _invoiceManager = invoiceManager;
            using (NetOpenXAuth auth =  new NetOpenXAuth())
            {
                var result = auth.Login(login).Result;
                if (result.Success) AUTH = auth.AUTH;
            }
            _manager = new ItemSlipsManager(AUTH);
        }
        public async Task<IDataResult<string>> SaveInvoice(FaturaDto invoice)
        {
            _netLogin.BranchCode = invoice.SubeKodu;

            using (var _service = new NetsisInvoiceService(_netLogin))
            {
                //servisten gelen faturayı al
                var serviceInvoice = await _invoiceManager.GetById(invoice.Guid);

                if (!serviceInvoice.Success)  return new ErrorDataResult<string>(null, serviceInvoice.Message);

                //kayıtlı fatura varmı kontrol et
                var checkInvoice = await CheckInvoice(invoice.Guid);
               
                if (!checkInvoice.Success)  return new ErrorDataResult<string>(null, checkInvoice.Message);


                //fatura dip tutar kontrolu yap
                var dipTutar = Math.Round(invoice.FaturaDetays.Sum(x => (x.Tutar)), 2);
                //fatura dip tutar tutmaz ve dip tutar kontrolu varsa
                if (Convert.ToInt32(serviceInvoice.Data.OdenecekTutar) != Convert.ToInt32(dipTutar) && !invoice.RetryTutar)
                {
                    return new ErrorDataResult<string>("",
                        ResultCode.ERROR_INVOICE_SUMMARY_NOT_CORRECT.Description(),
                        ResultCode.ERROR_INVOICE_SUMMARY_NOT_CORRECT);
                }

                //fatura kdv tutar kontrolu yap
                var kdvTutar = Math.Round(invoice.FaturaDetays.Sum(x => (x.Fiyat * (x.Kdv)) / 100),3);
                //fatura dip kdv tutmaz ve kdv tutar kontrolu varsa
                if (Math.Abs(Convert.ToDouble(serviceInvoice.Data.ToplamVergi) - Convert.ToDouble(kdvTutar))>0.01 && !invoice.RetryKdv)
                {
                    return new ErrorDataResult<string>("",
                        ResultCode.ERROR_INVOICE_TAX_SUM_NOT_CORRECT.Description(),
                        ResultCode.ERROR_INVOICE_TAX_SUM_NOT_CORRECT);
                }

                //kayıtlı fatura var ve fatura güncelleme izni yoksa hata yolla
                //güncelleme emri varsa eski faturayı sil ve yeni faturayı kaydet
                if (checkInvoice.Data != null && invoice.Guncelleme == false)
                {
                    return new ErrorDataResult<string>("",
                        ResultCode.ERROR_INVOICE_HAS_SAVED.Description(),
                        ResultCode.ERROR_INVOICE_HAS_SAVED);
                }
                else if (checkInvoice.Data != null && invoice.Guncelleme == true)
                {    
                    //faturayı sil
                    var resultDelete = await _service.DeleteInvoice(invoice.FaturaNo, invoice.CariKodu);

                    if (!resultDelete.Success) return new ErrorDataResult<string>(null, resultDelete.Message);

                    invoice.KayitTarihi = checkInvoice.Data.KayitTarihi != null ? checkInvoice.Data.KayitTarihi : DateTime.Now.ToLongTimeString();
                }
            
                var res =  await _service.SaveInvoice(invoice);

                return res;
            }
        }
       
        public async Task<IResult> DeleteInvoice(string faturaNo, string cariKodu, int subeKodu)
        {
            _netLogin.BranchCode = subeKodu;
            using (var _service = new NetsisInvoiceService(_netLogin))
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
                    
                    var query = $" select * from HNL_VW_FATURA_AKTARIM_LISTE where 1=1 ";

                    
                    if (invoiceFilterModel.FirstDate != null && invoiceFilterModel.LastDate != null)
                    {
                        query += $" and FaturaTarihi between '{invoiceFilterModel.FirstDate?.ToString("yyyy-MM-dd")} 00:00:00' and '{invoiceFilterModel.LastDate?.ToString("yyyy-MM-dd")} 23:59:59' ";
                    }
                    else if (invoiceFilterModel.IncomeFirstDate != null && invoiceFilterModel.IncomeLastDate != null)
                    {
                        query += $" and GelisTarihi between '{invoiceFilterModel.IncomeFirstDate?.ToString("yyyy-MM-dd")} 00:00:00' and '{invoiceFilterModel.IncomeLastDate?.ToString("yyyy-MM-dd")} 23:59:59' ";
                    }
                    if (!string.IsNullOrEmpty(invoiceFilterModel.SenderVkn) && invoiceFilterModel.SenderVkn.Length >= 10)
                    {
                        query += $" and GonderenVkn = '{invoiceFilterModel.SenderVkn}' ";
                    }
                    if (!string.IsNullOrEmpty(invoiceFilterModel.SenderName))
                    {
                        query += $" and GonderenUnvan like '%{invoiceFilterModel.SenderName}%' ";
                    }
                    if (!string.IsNullOrEmpty(invoiceFilterModel.CompanyVkn) && invoiceFilterModel.CompanyVkn.Length >= 10)
                    {
                        query += $" and Vkn = '{invoiceFilterModel.CompanyVkn}' ";
                    }
                    if (!string.IsNullOrEmpty(invoiceFilterModel.CompanyVkn) && invoiceFilterModel.CompanyVkn.Length >= 10)
                    {
                        query += $" and Vkn = '{invoiceFilterModel.CompanyVkn}' ";
                    }

                    query += " order by FaturaTarihi desc ";

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
                     $"  exec HNL_SP_FATURA_BASLIK '{guid}'   ";

                    var dataFaturaBaslik = await connection.QueryFirstOrDefaultAsync<FaturaDto>(faturaBaslikQuery);

                    var faturaKalemQuery = $" declare @id nvarchar(200); select @id=Id from HANEL_APP..Fatura Where [Guid]='{guid}' exec [HNL_SP_FATURA_KALEM]   @id";


                    var dataFaturaKalem = await connection.QueryAsync<FaturaDetayDto>(faturaKalemQuery);


                    dataFaturaBaslik.FaturaDetays = dataFaturaKalem.Where(x=>   !(x.HashKalem != null ? x.HashKalem : "").Contains("-015") && !(x.HashKalem != null ? x.HashKalem : "").Contains("-016"));

                    var yuvarlama = dataFaturaKalem.FirstOrDefault(x => (x.HashKalem != null ? x.HashKalem : "").Contains("-015") )!=null? dataFaturaKalem.FirstOrDefault(x => x.HashKalem.Contains("-015")).Tutar:0;
                    var otoAvaible = !dataFaturaKalem.Any(x => x.HashKalem == null);
                    dataFaturaBaslik.Yuvarlama = dataFaturaBaslik.Yuvarlama == 0 ? yuvarlama : dataFaturaBaslik.Yuvarlama;
                    dataFaturaBaslik.OtoAvaible = otoAvaible;
                    //dataFaturaBaslik.Mahsup = dataFaturaBaslik.Mahsup == 0 ? mahsup : dataFaturaBaslik.Mahsup;

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

                    if(data==null || data.Count()<1)
                        return new ErrorDataResult<YevmiyeFisInfo>("Yevmiya kaydı alınamadı. Fatura kaydı olamayabilir.");

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
