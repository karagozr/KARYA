using Dapper;
using HANEL.BUSINESS.Abstract.Accounting;
using HANEL.BUSINESS.Concrete.Accounting.Netsis.NetOpenX;
using HANEL.MODEL.Dto.Muhasebe;
using HANEL.MODEL.Entities.Muhasebe.Erp;
using KARYA.CORE.Concrete.Dapper;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.Netsis;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Accounting.Netsis
{
    public class NetCariManager : DapperRepository, ICariManager
    {
        IConfiguration _configuration;
        public NetCariManager() : base("NETSISConnection")
        {
        }

        Login _login;
        public NetCariManager(IConfiguration configuration) : base("NETSISConnection")
        {
            _configuration = configuration;
        }

        public async Task<IDataResult<ErpCari>> AddUpdateCari(ErpCari cariDto)
        {
            var netLogin = new KARYA.MODEL.Entities.Netsis.Login
            {
                NetsisUser = _configuration["NetsisEnv:NetsisUser"],
                NetsisPassword = _configuration["NetsisEnv:NetsisPassword"],
                DbName = _configuration["NetsisEnv:DbName"],
                NetOpenXUrl = _configuration["NetsisEnv:NetOpenXUrl"],
                BranchCode = Convert.ToInt32( _configuration["NetsisEnv:BranchCode"]),
            };
            using (var _service = new NetsisCariService(netLogin))
            {
                var result = await _service.AddCari(cariDto);

                return result;
            }
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
