using KARYA.CORE.Abstarct;
using KARYA.CORE.Entities;

namespace KARYA.CORE.Abstract
{
    public interface IBaseDal<TEntity> : IRepository<TEntity> where TEntity:CoreEntity
    {
    }
}
