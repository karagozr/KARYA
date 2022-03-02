using HANEL.DATAACCESS.Abstract.Finance;
using HANEL.DATAACCESS.Concrete.EntityFramework.Context;
using HANEL.MODEL.Entities.Finance;
using KARYA.CORE.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.DATAACCESS.Concrete.EntityFramework.Finance
{
    public class ReportCodeUserFilterDal : EfRepository<ReportCodeUserFilter, HanelContext>, IReportCodeUserFilterDal
    {
    }
}
