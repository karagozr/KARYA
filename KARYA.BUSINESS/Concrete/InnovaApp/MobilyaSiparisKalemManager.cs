using Dapper;
using KARYA.BUSINESS.Abstract.InnovaApp;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Concrete.Dapper;
using KARYA.MODEL.Entities.InnovaApp;
using KARYA.MODEL.Entities.InnovaApp.Mobilya;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.InnovaApp
{
    public class MobilyaSiparisKalemManager : DapperInnovaBaseDal, ISiparisKalemManager
    {
        public async Task<IResult> AddSiparisKalem(IEnumerable<SiparisKalem> siparisKalems)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"INSERT INTO INNOVA.DBO.[TBLBELGE_KAYIT] (DBNAME, SUBE_KODU  , [WORKFLOW_KODU], [GUIDID], BELGE_NO, TARIH, TESLIM_TARIHI  , CARI_KODU  , FTIRSIP, SIRA  , [STOK_KODU], MIKTAR, FIYAT  , KALEM_ACIKLAMA1, KALEM_ACIKLAMA2, KALEM_ACIKLAMA3, KALEM_ACIKLAMA4  , [UST_ACIKLAMA1], UST_ACIKLAMA2, UST_ACIKLAMA3, [UST_ACIKLAMA4], UST_ACIKLAMA5, UST_ACIKLAMA6  , SIPARIS_REF, SIPARIS_NO  , [VERSIYON], [KAYIT_KULLANICI_ID], [KAYIT_KULLANICI], [KAYIT_TARIHI]  , TIP, TIP_ACIKLAMA  ) VALUES ";
                    var siparisGuid = "";
                    foreach (var item in siparisKalems)
                    {
                        siparisGuid = item.SiparisGuidId;
                        queryString += $"('DB','0','{item.SiparisGuidId}', '{item.KalemGuidId}', '{item.BelgeNo}', getdate() ,  getdate() , '{item.CariKodu}', '{item.FtirSip}', {item.Sira}, '{item.StokKodu}', {item.Miktar}, {item.Fiyat}, '{item.KalemAciklama1}', '{item.KalemAciklama2}', '{item.KalemAciklama3}', '{item.KalemAciklama4}', '{item.UstAciklama1}', '{item.UstAciklama2}', '{item.UstAciklama3}', '{item.UstAciklama4}', '{item.UstAciklama5}', '{item.UstAciklama6}', '{item.SiparisRef}', '{item.SiparisNo}', '{item.Versiyon}', '{item.CreateUser}', '{item.CreateUserName}',  getdate(), '{item.Tip}', '{item.TipAciklama}'),";
                    }
                    queryString = queryString.Remove(queryString.Length - 1);

                    queryString += $" EXEC URETIM17..[INN_PR_MOBILYA_SIPARIS_KAYIT_DEKOR] '{siparisGuid}', '0'";

                    var resultData = await connection.QueryAsync(queryString);

                    return new SuccessResult();
                }

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Stok>("Hata : " + ex.Message);
            }
        }


        
    }
}
