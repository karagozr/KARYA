using Dapper;
using HANEL.BUSINESS.Abstract.Finance.Budgets;
using HANEL.MODEL.Dtos.Finance.Budget;
using HANEL.MODEL.Filter.Finance;
using KARYA.CORE.Concrete.Dapper;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Finance.Budgets
{
    public class BudgetReportManager : DapperRepository, IBudgetReportManager
    {
        public BudgetReportManager():base("HANELConnection")
        {

        }

        public async Task<IDataResult<IEnumerable<BudgetProjectListDto>>> GetProjectBudgetListWithStatus(BudgetReportFilterModel filter)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"exec HNL_PR_BUDGET_PROJECT_LIST {filter.Year} ";

                    var data = await connection.QueryAsync<BudgetProjectListDto>(queryString);

                    return new SuccessDataResult<IEnumerable<BudgetProjectListDto>>(data.ToList());
                }


            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<BudgetProjectListDto>>(ex.Message);
            }
        }


        public async Task<IDataResult<IEnumerable<BudgetReportWithLastDto>>> GetProjectBudgetReport(BudgetReportFilterModel filter)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"exec HNL_PR_BUDGET_PROJECT_REPORT '{filter.CurrencyCode}', {filter.Year}, {_httpContextValues.UserId()} ,'{filter.ProjectCode}'";

                    var data = await connection.QueryAsync<BudgetReportWithLastDto>(queryString);

                    return new SuccessDataResult<IEnumerable<BudgetReportWithLastDto>>(data.ToList());
                }

               
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<BudgetReportWithLastDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<BudgetReportDto>>> GetBudgetDetail(BudgetReportFilterModel filter)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"exec HNL_PR_BUDGET_DETAIL {_httpContextValues.UserId()}, {filter.BudgetId}, '{filter.CurrencyCode}'";

                    var data = await connection.QueryAsync<BudgetReportDto>(queryString);

                    return new SuccessDataResult<IEnumerable<BudgetReportDto>>(data.ToList());
                }

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<BudgetReportDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<BudgetReportDto>>> GetBudgetDetailOfProject(BudgetReportFilterModel filter)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"exec HNL_PR_BUDGET_DETAIL_OF_PROJECT  '{filter.ProjectCode}',{_httpContextValues.UserId()}, {filter.Year},'{filter.CurrencyCode}'";

                    var data = await connection.QueryAsync<BudgetReportDto>(queryString);

                    return new SuccessDataResult<IEnumerable<BudgetReportDto>>(data.ToList());
                }

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<BudgetReportDto>>(ex.Message);
            }
        }
    }
}
