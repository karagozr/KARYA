using KARYA.CORE.Concrete.EntityFramework;
using SAHIZA.BUSINESS.Abstarct;
using SAHIZA.DATAACCESS.Abstract;
using SAHIZA.MODEL.Entities;

namespace SAHIZA.BUSINESS.Concrete
{
    public class CariManager : BaseManager<Cari>, ICariManager
    {
        ICariDal _cariDal;
        public CariManager(ICariDal cariDal) : base(cariDal) => _cariDal = cariDal;


    }
}
