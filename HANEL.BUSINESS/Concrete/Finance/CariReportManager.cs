using Dapper;
using HANEL.BUSINESS.Abstract.Finance;
using HANEL.MODEL.Common.Finance;
using HANEL.MODEL.Dtos.CariReport;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Concrete.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Finance
{
    public class CariReportManager : DapperBaseDal, ICariReportManager 
    {
        public async Task<IDataResult<IEnumerable<CariReportSubGroup>>> GetCariReportSubGroup(CariReportFilterModel cariReportFilterModel)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var data = await connection.QueryAsync<CariReportSubGroup>("Pr_CariRaporAltGrup", new { cariReportFilterModel.CariKod }, commandType: CommandType.StoredProcedure);

                    return new SuccessDataResult<IEnumerable<CariReportSubGroup>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<CariReportSubGroup>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<CariReportSubGroupDetail>>> GetCariReportSubGroupDetail(CariReportFilterModel cariReportFilterModel)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var data = await connection.QueryAsync<CariReportSubGroupDetail>("Pr_CariRaporAltGrupDetay", new { cariReportFilterModel.CariKod,cariReportFilterModel.ProjeKod,cariReportFilterModel.RaporHesapKod }, commandType: CommandType.StoredProcedure);

                    return new SuccessDataResult<IEnumerable<CariReportSubGroupDetail>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<CariReportSubGroupDetail>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<CariReportSubGroupDetail>>> GetCariReportSubGroupDetailFromFisNo(CariReportFilterModel cariReportFilterModel)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var data = await connection.QueryAsync<CariReportSubGroupDetail>("Pr_CariRaporAltGrupDetayFisNo", new { cariReportFilterModel.FisNo, cariReportFilterModel.SubeKod}, commandType: CommandType.StoredProcedure);

                    return new SuccessDataResult<IEnumerable<CariReportSubGroupDetail>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<CariReportSubGroupDetail>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<CariReportTitle>>> GetCariReportTitles()
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"SELECT * FROM [Vw_RaporBasliklar]";

                    var resultData = await connection.QueryAsync<CariReportTitle>(queryString);

                    return new SuccessDataResult<IEnumerable<CariReportTitle>>(resultData.ToList());
                }
               
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<CariReportTitle>>(ex.Message);
            }
        }


    }
}
