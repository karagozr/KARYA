using KARYA.CORE.Concrete.EntityFramework;
using KARYA.DATAACCESS.Abstract.Hanel;
using KARYA.DATAACCESS.Abstract.Hanel.Finance;
using KARYA.DATAACCESS.Concrete.EntityFramework.Context;
using KARYA.MODEL.Dtos.Hanel.Finance.Budget;
using KARYA.MODEL.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.DATAACCESS.Concrete.EntityFramework.Hanel.Finance
{
    public class BudgetDal : EfRepository<Budget, HanelContext>, IBudgetDal
    {
        
    }
}
