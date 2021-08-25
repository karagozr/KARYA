using KARYA.CORE.Concrete.EntityFramework;
using SAHIZA.BUSINESS.Abstarct;
using SAHIZA.DATAACCESS.Abstract;
using SAHIZA.MODEL.Entities;

namespace SAHIZA.BUSINESS.Concrete
{
    public class StokHaraketManager : BaseManager<StokHaraket>, IStokHaraketManager 
    { 
        IStokHaraketDal _stokHaraketDal;
        public StokHaraketManager(IStokHaraketDal stokHaraketDal) : base(stokHaraketDal) => _stokHaraketDal = stokHaraketDal;


    }
}
