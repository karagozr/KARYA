using Dapper;
using KARYA.BUSINESS.Abstract.InnovaApp;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Concrete.Dapper;
using KARYA.MODEL.Entities.InnovaApp.Mobilya;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.InnovaApp
{
    public class MobilyaReceteManager :DapperInnovaBaseDal, IReceteManager
    {
        public async Task<IDataResult<string>> ReceteOlustur(string stokKodu)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    string guidId = Guid.NewGuid().ToString();
                    int miktar = 1;

                    var queryString = $" EXEC URETIM17..[INN_PR_MOBILYA_URETIM_ACIKREC_DEKOR] '{stokKodu}', '{miktar}', '{guidId}'";

                    var resultData = await connection.QueryAsync(queryString);

                    return new SuccessDataResult<string>(guidId,"");
                }

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>("Hata : " + ex.Message);
            }
        }
        public async Task<IDataResult<IEnumerable<Recete>>> ReceteGetir(string guidId)
        {
            try
            {
                using (var connection = CreateConnection())
                {

                    var queryString = $"EXEC URETIM17..[INN_PR_MOBILYA_URETIM_ACIKREC_GETIR_DEKOR] '{guidId}', '0' ";

                    var resultData = await connection.QueryAsync<dynamic>(queryString);
                    var receteData = new List<Recete>();

                    foreach (var item in resultData)
                    {
                        #region ex_data
                        //TEMP_ID           = '1096480', 
                        //ID                = '1100437', 
                        //USTID             = '1100425', 
                        //GUIDID            = 'x8c1f0d56-c7cd-429e-89b6-0269bea26136', 
                        //ANASTOK_KODU      = '100 0001', 
                        //ANAMIKTAR         = '1.00000000',
                        //SEVIYE            = '3', 
                        //SIRA              = '26', 
                        //MAMUL_KODU        = '162 0002', 
                        //HAM_KODU          = '319 1090', 
                        //MIKTAR            = '0.64000000', 
                        //RECETEMIKTARI     = '0.32000000', 
                        //OPNO              = '3000', 
                        //OPBIL             = 'B', 
                        //AKTIF             = NULL, 
                        //ACIKLAMA          = NULL, 
                        //REC_SIRA          = NULL, 
                        //ESKI_HAM_KODU     = NULL, 
                        //STOK_ADI          = 'DESENLİ KUMAŞ', 
                        //MAMUL_ADI         = 'DENİZ KIRLENT 45x45 ELİT', 
                        //OZELLIK_ID        = '5', 
                        //OZELLIK_KODU      = 'KUMAS', 
                        //OZELLIK_ACIKLAMA  = 'KUMAÞ TÜRLERÝ', 
                        //DEGER_ID          = '10', 
                        //DEGER_KODU        = 'KUMAS001', 
                        //DEGER_ACIKLAMA    = 'DESENLI KUMASLAR', 
                        //STOK_KISA_ADI     = 'DESENLİ KUMAŞ', 
                        //MAMUL_KISA_ADI    = ' KIRLENT 45x45 ', 
                        //DEGISTI           = '0'
                        #endregion
                        receteData.Add(new Recete {
                            Id=item.ID,
                            GuidId=item.GUIDID,
                            TempId=item.TEMP_ID,
                            OzellikId=item.OZELLIK_ID,
                            Miktar=item.ANAMIKTAR,
                            AnaStokKodu=item.ANASTOK_KODU,
                            StokKodu=item.HAM_KODU,
                            StokAdi=item.STOK_ADI,
                            MamulKodu=item.MAMUL_KODU,
                            MamulAdi=item.MAMUL_ADI,
                            OzellikAciklama=item.OZELLIK_ACIKLAMA
                        });
                    }

                    return new SuccessDataResult<IEnumerable<Recete>>(receteData);
                }

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Recete>>("Hata : " + ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<ReceteStok>>> ReceteStokGetir(int ozellikId)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"select STOK_KODU as StokKodu, STOK_ADI as StokAdi, OZELLIK_ID as OzellikId, STOK_ACIKLAMA as StokAciklama " +
                        $"from  URETIM17..INN_VW_MOBILYA_OZELLIKLER  WHERE OZELLIK_ID = {ozellikId}";

                    var resultData = await connection.QueryAsync<ReceteStok>(queryString);

                    return new SuccessDataResult<IEnumerable<ReceteStok>>(resultData);
                }

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<ReceteStok>>("Hata : " + ex.Message);
            }
        }

        public async Task<IResult> ReceteStokUpdate(int id, string stokKodu)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $" UPDATE INNOVA.DBO.[TBLURETIM_MOBILYA_ACIKREC]		  SET HAM_KODU = '{stokKodu}' WHERE ID = '{id}' " +
                                      $" UPDATE INNOVA.DBO.[TBLURETIM_MOBILYA_ACIKREC_TEMP]   SET HAM_KODU = '{stokKodu}' WHERE ID = '{id}'";

                    var resultData = await connection.QueryAsync(queryString);

                    return new SuccessResult();
                }

            }
            catch (Exception ex)
            {
                return new ErrorResult("Hata : " + ex.Message);
            }
        }
    }
}
