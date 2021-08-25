using HANEL.MODEL.Dtos.Finance.Budget;
using HANEL.MODEL.Entities.Finance;
using KARYA.CORE.Abstract;
using KARYA.CORE.Types.Return.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Finance
{
    public interface IBudgetDetailManager : IBaseManager<BudgetDetail>
    {
        Task<IDataResult<IEnumerable<BudgetAndActualWithMonthsDto>>> ListOfBudgetAndActualWithMonths(string projectCode, short budgetYear, short actualYear, string currencyCode);
    }
}
