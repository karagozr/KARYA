using KARYA.CORE.Concrete.EntityFramework;
using SAHIZA.BUSINESS.Abstarct;
using SAHIZA.DATAACCESS.Abstract;
using SAHIZA.MODEL.Entities;

namespace SAHIZA.BUSINESS.Concrete
{
    public class DizaynDetayManager : BaseManager<DizaynDetay>, IDizaynDetayManager
    {
        IDizaynDetayDal _dizaynDetayDal;
        public DizaynDetayManager(IDizaynDetayDal dizaynDetayDal) : base(dizaynDetayDal) => _dizaynDetayDal = dizaynDetayDal;


    }
}
