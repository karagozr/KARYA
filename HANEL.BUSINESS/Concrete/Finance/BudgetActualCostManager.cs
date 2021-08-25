using Dapper;
using HANEL.BUSINESS.Abstract.Finance;
using HANEL.MODEL.Dtos.Finance.Budget;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Concrete.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Finance
{
    public class BudgetActualCostManager : DapperBaseDal, IBudgetActualCostManager
    {

        public async Task<IDataResult<IEnumerable<BudgetAndActualWithMonthsDto>>> GetActualBudgetCostWithMonths(string projectCode, short budgetYear, short actualYear, string actualCurrencyCode)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"select * from TFunc_GetBudgetAndActualOfProjectWithMonthly('{projectCode}',{budgetYear},{actualYear},'{actualCurrencyCode}') order by BudgetSubGroup, BudgetSubCode";

                    var data = await connection.QueryAsync<BudgetAndActualWithMonthsDto>(queryString);
                   
                    return new SuccessDataResult<IEnumerable<BudgetAndActualWithMonthsDto>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<BudgetAndActualWithMonthsDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<ProjectsBudgetListWithStatus>>> GetProjectsBudgetListWithStatus(short budgetYear)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"select * from TFunc_GetListOfProjectsWithBudgetStatus({budgetYear})";

                    var data = await connection.QueryAsync<ProjectsBudgetListWithStatus>(queryString);

                    return new SuccessDataResult<IEnumerable<ProjectsBudgetListWithStatus>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<ProjectsBudgetListWithStatus>>(ex.Message);
            }
        }
    }
}
