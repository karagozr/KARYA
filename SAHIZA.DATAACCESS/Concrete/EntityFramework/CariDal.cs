using KARYA.CORE.Concrete.EntityFramework;
using SAHIZA.DATAACCESS.Abstract;
using SAHIZA.MODEL.Entities;

namespace SAHIZA.DATAACCESS.Concrete.EntityFramework
{
    public class CariDal : EfRepository<Cari, SahizaWorldContext>, ICariDal
    {
    }
}
