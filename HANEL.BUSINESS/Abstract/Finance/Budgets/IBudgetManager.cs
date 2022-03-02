using HANEL.MODEL.Dtos.Finance.Budget;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Finance.Budgets
{
    public interface IBudgetManager
    {
        Task<IResult> AddBudget(IEnumerable<BudgetAddDto> budgets);
        Task<IResult> EditBudget(IEnumerable<BudgetEditDto> budgets);
        Task<IResult> EditBudgetDetail(IEnumerable<BudgetEditDto> budgets);
    }
}
