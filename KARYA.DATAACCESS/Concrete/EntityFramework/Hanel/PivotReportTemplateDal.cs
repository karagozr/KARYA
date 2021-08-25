using KARYA.CORE.Concrete.EntityFramework;
using KARYA.DATAACCESS.Abstract.Hanel;
using KARYA.DATAACCESS.Concrete.EntityFramework.Context;
using KARYA.MODEL.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.DATAACCESS.Concrete.EntityFramework.Hanel
{
    public class PivotReportTemplateDal : EfRepository<PivotReportTemplate, HanelContext>, IPivotReportTemplateDal
    {
    }
}
