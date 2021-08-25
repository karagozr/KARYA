using KARYA.CORE.Concrete.EntityFramework;
using KARYA.DATAACCESS.Abstract.Authorize;
using KARYA.DATAACCESS.Concrete.EntityFramework.Context;
using KARYA.MODEL.Entities.Karya;

namespace KARYA.DATAACCESS.Concrete.EntityFramework.Authorize
{
    public class FieldGroupDal : EfRepository<FieldGroup, KaryaContext>, IFieldGroupDal
    {
        
    }
}
