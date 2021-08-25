using Dapper;
using HANEL.BUSINESS.Abstract.Accounting;
using HANEL.MODEL.Dto.Muhasebe;
using KARYA.CORE.Concrete.Dapper;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Accounting.Netsis
{
    public class NetCariManager : DapperRepository, ICariManager
    {
        public NetCariManager() : base("NETSISConnection")
        {
        }

      

        public async Task<IDataResult<CariDto>> GetById(string cariKodu)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"select " +
                        $"C.CARI_KOD            as CariKodu     , " +
                        $"dbo.TRK(CARI_ISIM)    as CariUnvan    , " +
                        $"VERGI_NUMARASI        as VergiDairesi , " +
                        $"VERGI_NUMARASI        as Vkn          , " +
                        $"Ce.TCKIMLIKNO         as Tckn           " +
                        $"from TBLCASABIT   as C  " +
                        $"left join TBLCASABITEK as CE on C.CARI_KOD = CE.CARI_KOD " +
                        $"where C.CARI_KOD like '{cariKodu}' ";
                       
                    var data = await connection.QueryFirstOrDefaultAsync<CariDto>(queryString);

                    return new SuccessDataResult<CariDto>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<CariDto>(ex.Message);
            }
        }

        public async Task<IDataResult<CariDto>> GetFromVkn(string vkn)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"select " +
                        $"C.CARI_KOD            as CariKodu     , " +
                        $"dbo.TRK(CARI_ISIM)    as CariUnvan    , " +
                        $"VERGI_NUMARASI        as VergiDairesi , " +
                        $"VERGI_NUMARASI        as Vkn          , " +
                        $"Ce.TCKIMLIKNO         as Tckn           " +
                        $"from TBLCASABIT   as C  " +
                        $"left join TBLCASABITEK as CE on C.CARI_KOD = CE.CARI_KOD " +
                        $"where C.VERGI_NUMARASI like '{vkn} ";

                    

                    var data = await connection.QueryFirstOrDefaultAsync<CariDto>(queryString);

                    return new SuccessDataResult<CariDto>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<CariDto>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<CariDto>>> List(string cariKodu = null)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"select " +
                        $"C.CARI_KOD            as CariKodu     , " +
                        $"dbo.TRK(CARI_ISIM)    as CariUnvan    , " +
                        $"VERGI_NUMARASI        as VergiDairesi , " +
                        $"VERGI_NUMARASI        as Vkn          , " +
                        $"Ce.TCKIMLIKNO         as Tckn           " +
                        $"from TBLCASABIT   as C  " +
                        $"left join TBLCASABITEK as CE on C.CARI_KOD = CE.CARI_KOD " +
                        $"where 1=1  ";

                    if (string.IsNullOrEmpty(cariKodu))
                        queryString += $" and c.CARI_KOD like '%{cariKodu}%'";

                    var data = await connection.QueryAsync<CariDto>(queryString);

                    return new SuccessDataResult<IEnumerable<CariDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<CariDto>>(ex.Message);
            }
        }
    }
}
