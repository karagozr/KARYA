using HANEL.BUSINESS.Abstract;
using HANEL.DATAACCESS.Abstract;
using HANEL.MODEL.Entities;
using KARYA.CORE.Concrete.EntityFramework;

namespace HANEL.BUSINESS.Concrete
{
    public class CompanyManager : BaseManager<Company>, ICompanyManager
    {

        ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal) : base(companyDal)
        {
            _companyDal = companyDal;
        }

       
    }
}
