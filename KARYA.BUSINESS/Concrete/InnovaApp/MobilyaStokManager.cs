using Dapper;
using KARYA.BUSINESS.Abstract.InnovaApp;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Concrete.Dapper;
using KARYA.MODEL.Entities.InnovaApp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.InnovaApp
{
    public class MobilyaStokManager : DapperInnovaBaseDal, IStokManager
    {
        public async Task<IDataResult<Stok>> GetFromStokKod(string stokKodu)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"select STOK_KODU as StokKodu, STOK_ADI as StokAdi, KOD_1 as Kod1, KOD_2 as Kod2, KOD_3 as Kod3, KOD_4 as Kod4 from  URETIM17..INN_VW_STOK_KART WHERE TUR IN ('M') and STOK_KODU like '{stokKodu}'";

                    var resultData = await connection.QueryFirstAsync<Stok>(queryString);

                    return new SuccessDataResult<Stok>(resultData);
                }

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Stok>("Hata : " + ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<Stok>>> List(string stokKodu = null, string stokAdi = null, string kod1 = null, string kod2 = null, string kod3 = null, string kod4 = null)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"select STOK_KODU as StokKodu, STOK_ADI as StokAdi, KOD_1 as Kod1, KOD_2 as Kod2, KOD_3 as Kod3, KOD_4 as Kod4 from  URETIM17..INN_VW_STOK_KART WHERE TUR IN ('M') ";

                    if (!string.IsNullOrEmpty(stokKodu)) queryString += $" and STOK_KODU like '%{stokKodu}%' ";
                    if (!string.IsNullOrEmpty(stokAdi)) queryString += $" and STOK_ADI like '%{stokAdi}%' ";
                    if (!string.IsNullOrEmpty(kod1)) queryString += $" and KOD_1 like '%{kod1}%' ";
                    if (!string.IsNullOrEmpty(kod2)) queryString += $" and KOD_2 like '%{kod2}%' ";
                    if (!string.IsNullOrEmpty(kod3)) queryString += $" and KOD_3 like '%{kod3}%' ";
                    if (!string.IsNullOrEmpty(kod4)) queryString += $" and KOD_4 like '%{kod4}%' ";

                    var resultData = await connection.QueryAsync<Stok>(queryString);

                    return new SuccessDataResult<IEnumerable<Stok>>(resultData);
                }

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Stok>>("Hata : " + ex.Message);
            }
        }
    }
}
