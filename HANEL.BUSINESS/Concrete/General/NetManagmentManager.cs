using Dapper;
using HANEL.BUSINESS.Abstract.General;
using HANEL.MODEL.Dto.General;
using KARYA.CORE.Concrete.Dapper;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Dtos.Erp;
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

        public async Task<IDataResult<IEnumerable<StockAccountDetailCodeDto>>> ListMuhDetailCodes()
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"select md.SUBE_KODU as BranchCode, dbo.TRK(br.UNVAN) as BranchName, MUH_DETAYKOD as Code, dbo.TRK(md.S_YEDEK1) as [Description] " +
                        $" from TBLSTMUHDETAY as md " +
                        $" inner join TBLSUBELER as br on md.SUBE_KODU=br.SUBE_KODU ";

                    var data = await connection.QueryAsync<StockAccountDetailCodeDto>(queryString);

                    return new SuccessDataResult<IEnumerable<StockAccountDetailCodeDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<StockAccountDetailCodeDto>>(ex.Message);
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

        public async Task<IDataResult<IEnumerable<StockCodeDto>>> ListStokCode1List()
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"select GRUP_KOD as Code, dbo.TRK(GRUP_ISIM) as [Description] from TBLSTOKKOD1";

                    var data = await connection.QueryAsync<StockCodeDto>(queryString);

                    return new SuccessDataResult<IEnumerable<StockCodeDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<StockCodeDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<StockCodeDto>>> ListStokGrupCode1List()
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"select GRUP_KOD as Code, dbo.TRK(GRUP_ISIM) as [Description] from TBLSTGRUP";

                    var data = await connection.QueryAsync<StockCodeDto>(queryString);

                    return new SuccessDataResult<IEnumerable<StockCodeDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<StockCodeDto>>(ex.Message);
            }
        }
    }
}
