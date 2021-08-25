using KARYA.CORE.Entities.Concrete;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.Base
{
    public interface IBaseManager<TEntity> where TEntity:BaseEntity
    {
        int ScopeIdentity();
        Task<IDataResult<TEntity>> GetById(int id);
        Task<IDataResult<IEnumerable<TEntity>>> GetAll();
        Task<IResult> Add(TEntity entity);
        Task<IResult> Add(IEnumerable<TEntity> entities);
        Task<IResult> Update(TEntity entity);
        Task<IResult> Update(IEnumerable<TEntity> entities);
        Task<IResult> Delete(int id);
        Task<IResult> DeleteList(IEnumerable<int> ids);
        Task<IResult> DeleteList(IEnumerable<TEntity> entities);
        Task<IResult> AddUpdate(TEntity entity);
    }
}
