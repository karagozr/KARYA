using KARYA.CORE.Concrete.EntityFramework;
using KARYA.DATAACCESS.Abstract.App;
using KARYA.DATAACCESS.Concrete.EntityFramework.Context;
using KARYA.MODEL.Entities.Karya;

namespace KARYA.DATAACCESS.Concrete.EntityFramework.Authorize
{
    public class AppModuleDal : EfRepository<AppModule, KaryaContext>, IAppModuleDal
    {
    }
}
