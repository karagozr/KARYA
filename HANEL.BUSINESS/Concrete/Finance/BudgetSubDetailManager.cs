using HANEL.BUSINESS.Abstract.Finance;
using HANEL.DATAACCESS.Abstract.Finance;
using HANEL.MODEL.Dtos.Finance.Budget;
using HANEL.MODEL.Entities.Finance;
using KARYA.CORE.Concrete.EntityFramework;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Finance
{
    public class BudgetSubDetailManager : BaseManager<BudgetSubDetail>, IBudgetSubDetailManager
    {
        IBudgetSubDetailDal _budgetSubDetailDal;

        public BudgetSubDetailManager(IBudgetSubDetailDal budgetSubDetailDal) : base(budgetSubDetailDal)
        {
            _budgetSubDetailDal = budgetSubDetailDal;
        }

        public async Task<IDataResult<IEnumerable<BudgetSubDetailDto>>> Select(IEnumerable<int> budgetIds)
        {
            try
            {
                var result = await _budgetSubDetailDal.ListWithSubCode(x => budgetIds.Contains(x.BudgetId));

                return new SuccessDataResult<IEnumerable<BudgetSubDetailDto>>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<BudgetSubDetailDto>>(null,ex.Message);
            }
            
        }
    }

}
