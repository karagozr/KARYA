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
    public interface IBudgetReportManager
    {
        Task<IDataResult<IEnumerable<BudgetProjectListDto>>> GetProjectBudgetListWithStatus(BudgetReportFilterModel filter);
        Task<IDataResult<IEnumerable<BudgetReportWithLastDto>>> GetProjectBudgetReport(BudgetReportFilterModel filter);
        Task<IDataResult<IEnumerable<BudgetReportDto>>> GetBudgetDetail(BudgetReportFilterModel filter);
        Task<IDataResult<IEnumerable<BudgetReportDto>>> GetBudgetDetailOfProject(BudgetReportFilterModel filter);
    }
}
