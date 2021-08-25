using Dapper;
using HANEL.BUSINESS.Abstract.General;
using HANEL.MODEL.Dto.General;
using KARYA.CORE.Concrete.Dapper;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.General
{
    public class NetManagmentManager : DapperRepository, IManagmentManager
    {
        public NetManagmentManager() : base("NETSISConnection")
        {
        }

        public async Task<IDataResult<IEnumerable<SubeDto>>> ListBranch(string vkn = null)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"select " +
                        $"dbo.TRK(SUBE_KODU)         as SubeKodu         , " +
                        $"dbo.TRK(ISLETME_KODU)      as IsletmeKodu      , " +
                        $"dbo.TRK(UNVAN)             as Unvan            , " +
                        $"dbo.TRK(VNO)               as Vkn                " +
                        $"from TBLSUBELER where SUBE_KODU!= ISLETME_KODU ";

                    if (!string.IsNullOrEmpty(vkn))
                        queryString += $" and VNO like '%{vkn}%'";

                    var data = await connection.QueryAsync<SubeDto>(queryString);

                    return new SuccessDataResult<IEnumerable<SubeDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<SubeDto>>(ex.Message);
            }
        }
        public async Task<IDataResult<IEnumerable<SubeDto>>> ListCompany(string vkn = null)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"select " +
                        $"dbo.TRK(SUBE_KODU)         as SubeKodu         , " +
                        $"dbo.TRK(ISLETME_KODU)      as IsletmeKodu      , " +
                        $"dbo.TRK(UNVAN)             as Unvan            , " +
                        $"dbo.TRK(VNO)               as Vkn                " +
                        $"from TBLSUBELER where SUBE_KODU = ISLETME_KODU ";

                    if (!string.IsNullOrEmpty(vkn))
                        queryString += $" and VNO like '%{vkn}%'";

                    var data = await connection.QueryAsync<SubeDto>(queryString);

                    return new SuccessDataResult<IEnumerable<SubeDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<SubeDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<ProjeDto>>> ListProjects(string projectCode = null)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"select " +
                        $"dbo.TRK(PROJE_KODU)            as ProjeKodu    , " +
                        $"dbo.TRK(PROJE_ACIKLAMA)        as ProjeAdi     , " +
                        $"dbo.TRK(RAPOR_KOD1)            as RaporKod1    , " +
                        $"dbo.TRK(RAPOR_KOD2)            as RaporKod2      " +
                        $"from TBLPROJE where 1=1 ";

                    if (string.IsNullOrEmpty(projectCode))
                        queryString += $" and PROJE_KODU like '%{projectCode}%'";

                    queryString += $" order by PROJE_KODU";

                    var data = await connection.QueryAsync<ProjeDto>(queryString);

                    return new SuccessDataResult<IEnumerable<ProjeDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<ProjeDto>>(ex.Message);
            }
        }
    }
}
