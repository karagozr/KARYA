using HANEL.MODEL.Dtos.Finance.Budget;
using HANEL.MODEL.Filter.Finance;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Finance.Budgets
{
    public interface IBudgetExchangeRateManager
    {
        Task<IResult> Edit(IEnumerable<BudgetExchangeRateDto> budgetExchanges);
        Task<IDataResult<IEnumerable<BudgetExchangeRateDto>>> List(BudgetExchangeRateFilterModel filter);
        Task<IDataResult<IEnumerable<BudgetExchangeRateMonthlyDto>>> ListMonthly(BudgetExchangeRateFilterModel filter);
    }
}
