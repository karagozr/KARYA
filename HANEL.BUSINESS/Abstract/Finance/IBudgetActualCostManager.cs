using HANEL.MODEL.Dtos.Finance.Budget;
using KARYA.CORE.Types.Return.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Finance
{
    public interface IBudgetActualCostManager
    {
        Task<IDataResult<IEnumerable<ProjectsBudgetListWithStatus>>> GetProjectsBudgetListWithStatus(short budgetYear);
        Task<IDataResult<IEnumerable<BudgetAndActualWithMonthsDto>>> GetActualBudgetCostWithMonths(string projectCode,short budgetYear, short actualYear, string actualCurrencyCode);

    }
}

