using HANEL.MODEL.Dtos.Finance.Budget;
using HANEL.MODEL.Entities.Finance;
using KARYA.CORE.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HANEL.DATAACCESS.Abstract.Finance
{
    public interface IBudgetSubDetailDal : IBaseDal<BudgetSubDetail>
    {
        Task<IEnumerable<BudgetSubDetailDto>> ListWithSubCode(Expression<Func<BudgetSubDetail, bool>> filter);
    }
}
