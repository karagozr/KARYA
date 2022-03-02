using Dapper;
using HANEL.BUSINESS.Abstract.Construction.Report;
using HANEL.MODEL.Dtos.Construction.Report;
using HANEL.MODEL.Filter.Construction;
using KARYA.CORE.Concrete.Dapper;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Concrete.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Construction.Report
{
    public class ConstructionActivityReportManager : DapperRepository, IConstructionActivityReport
    {
        public ConstructionActivityReportManager() : base("NETSISConnection")
        {
        }
        public async Task<IDataResult<IEnumerable<ActivityReportDto>>> GetActivityReport(ActivityReportFilterModel filter)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var query = $"exec HNL_SP_INSAAT_GERCEKLESEN_BUTCE '{filter.BudgetPlanCode}', '{filter.CurrencyCode}'";
                    var data = await connection.QueryAsync<ActivityReportDto>(query);

                    return new SuccessDataResult<IEnumerable<ActivityReportDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<ActivityReportDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<ActivityReportDetailDto>>> GetActivityReportDetail(ActivityReportDetailFilterModel filter)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {

                    var query = $"exec HNL_SP_INSAAT_GERCEKLESEN_BUTCE_DETAY '{filter.BudgetPlanCode}', '{filter.Id}', '{filter.CurrencyCode}'";

                    var data = await connection.QueryAsync<ActivityReportDetailDto>(query);

                    return new SuccessDataResult<IEnumerable<ActivityReportDetailDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<ActivityReportDetailDto>>(ex.Message);
            }
        }

    }


}
