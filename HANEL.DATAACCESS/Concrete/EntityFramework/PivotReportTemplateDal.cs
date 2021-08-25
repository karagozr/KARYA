using HANEL.DATAACCESS.Abstract;
using HANEL.MODEL.Entities.Finance;
using KARYA.CORE.Concrete.EntityFramework;
using HANEL.DATAACCESS.Concrete.EntityFramework.Context;

namespace HANEL.DATAACCESS.Concrete.EntityFramework
{
    public class PivotReportTemplateDal : EfRepository<PivotReportTemplate, HanelContext>, IPivotReportTemplateDal
    {
    }
}
