using HANEL.DATAACCESS.Abstract;
using HANEL.DATAACCESS.Concrete.EntityFramework.Context;
using HANEL.MODEL.Entities;
using KARYA.CORE.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.DATAACCESS.Concrete.EntityFramework
{
    public class CompanyDal:EfRepository<Company,HanelContext>, ICompanyDal
    {
    }
}
