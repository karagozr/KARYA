using HANEL.MODEL.Dtos.Finance.Budget;
using KARYA.CORE.Types.Return.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Finance
{
    public interface IActualCostManager
    {
        Task<IDataResult<IEnumerable<ActualCostWithMonths>>> GetActualCostWithMonths(string projectCode,short year, string currency);

    }
}

