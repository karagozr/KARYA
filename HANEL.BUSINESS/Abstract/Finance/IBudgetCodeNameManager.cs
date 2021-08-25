using HANEL.MODEL.Dtos.Finance.Budget;
using KARYA.CORE.Types.Return.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Finance
{
    public interface IBudgetCodeNameManager
    {
        Task<IDataResult<IEnumerable<BudgetCodeName>>> List();
    }
}
