using HANEL.BUSINESS.Abstract.Finance;
using HANEL.DATAACCESS.Abstract.Finance;
using HANEL.MODEL.Entities.Finance;
using KARYA.CORE.Concrete.EntityFramework;

namespace HANEL.BUSINESS.Concrete.Finance
{
    public class BudgetManager : BaseManager<Budget>, IBudgetManager
    {
        IBudgetDal _budgetDal;

        public BudgetManager(IBudgetDal budgetDal) : base(budgetDal)
        {
            _budgetDal = budgetDal;
        }

    }

}
