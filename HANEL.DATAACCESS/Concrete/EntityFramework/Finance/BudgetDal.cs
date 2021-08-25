using HANEL.DATAACCESS.Abstract.Finance;
using HANEL.MODEL.Entities.Finance;
using KARYA.CORE.Concrete.EntityFramework;
using HANEL.DATAACCESS.Concrete.EntityFramework.Context;

namespace HANEL.DATAACCESS.Concrete.EntityFramework.Finance
{
    public class BudgetDal : EfRepository<Budget, HanelContext>, IBudgetDal
    {
        
    }
}
