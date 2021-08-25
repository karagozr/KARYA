using KARYA.CORE.Abstract;
using KARYA.CORE.Entities;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.CORE.Concrete.EntityFramework
{
    public abstract class BaseManager<TEntity> : IBaseManager<TEntity> where TEntity : CoreEntity
    {
        protected int _identityId = 0;
        readonly IBaseDal<TEntity> _baseDal;

        public BaseManager(IBaseDal<TEntity> baseDal)
        {
            _baseDal = baseDal;
        }

        public int ScopeIdentity()
        {
            return _identityId;
        }

        public virtual async Task<IDataResult<TEntity>> GetById(int id)
        {
            IDataResult<TEntity> result;
            try
            {
                var entity = await _baseDal.Get(x => x.Id == id);
                result = new SuccessDataResult<TEntity>(entity);
            }
            catch (Exception ex)
            {
                result = new SuccessDataResult<TEntity>(ex.Message);
            }

            return result;
        }

        public virtual async Task<IDataResult<IEnumerable<TEntity>>> GetAll()
        {
            try
            {
                var entities = await _baseDal.List(null);
                return new SuccessDataResult<IEnumerable<TEntity>>(entities);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<TEntity>>(ex.Message);
            }
        }

        public virtual async Task<IResult> Add(TEntity entity)
        {
            IResult result;
            try
            {
                await _baseDal.Add(entity);
                _identityId = _baseDal.SCOPE_IDENTY_ID;
                result = new SuccessResult("Adding was succesed");
            }
            catch (Exception ex)
            {
                result = new ErrorResult(ex.Message);
            }

            return result;
        }

        public virtual async Task<IResult> Add(IEnumerable<TEntity> entities)
        {
            IResult result;
            try
            {
                await _baseDal.Add(entities);
                result = new SuccessResult("List Adding was succesed");
            }
            catch (Exception ex)
            {
                result = new ErrorResult(ex.Message);
            }

            return result;
        }

        public virtual async Task<IResult> AddComplex(IEnumerable<TEntity> entities)
        {
            try
            {
                await _baseDal.AddComplex(entities);
                return new SuccessResult("List Adding was succesed");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

        }

        public virtual async Task<IResult> Delete(int id)
        {
            IResult result;
            try
            {
                var entity = await _baseDal.Get(x => x.Id == id);
                await _baseDal.Delete(entity);
                result = new SuccessResult("Deleting was succesed");
                _identityId = _baseDal.SCOPE_IDENTY_ID;
            }
            catch (Exception ex)
            {
                result = new ErrorResult(ex.Message);
            }

            return result;
        }

        public virtual async Task<IResult> DeleteList(IEnumerable<int> ids)
        {
            IResult result;
            try
            {
                var entities = await _baseDal.List(x => ids.Contains(x.Id));
                await _baseDal.Delete(entities);
                result = new SuccessResult("Deleting was succesed");
                _identityId = _baseDal.SCOPE_IDENTY_ID;
            }
            catch (Exception ex)
            {
                result = new ErrorResult(ex.Message);
            }

            return result;
        }

        public virtual async Task<IResult> DeleteList(IEnumerable<TEntity> entities)
        {
            IResult result;
            try
            {
                await _baseDal.Delete(entities);
                result = new SuccessResult("Deleting was succesed");
                _identityId = _baseDal.SCOPE_IDENTY_ID;
            }
            catch (Exception ex)
            {
                result = new ErrorResult(ex.Message);
            }

            return result;
        }

        public virtual async Task<IResult> Update(TEntity entity)
        {
            IResult result;
            try
            {
                await _baseDal.Update(entity);
                result = new SuccessResult("Update was succesed");
                _identityId = _baseDal.SCOPE_IDENTY_ID;
            }
            catch (Exception ex)
            {
                result = new ErrorResult(ex.Message);
            }

            return result;
        }

        public virtual async Task<IResult> Update(IEnumerable<TEntity> entities)
        {
            IResult result;
            try
            {
                await _baseDal.Update(entities);
                result = new SuccessResult("List Update was succesed");
            }
            catch (Exception ex)
            {
                result = new ErrorResult(ex.Message);
            }

            return result;
        }

        public virtual async Task<IResult> AddUpdate(TEntity entity)
        {
            try
            {
                await _baseDal.AddUpdate(entity);
                _identityId = _baseDal.SCOPE_IDENTY_ID;
                return new SuccessResult("Edit was succesed");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

        }

        
    }
}
