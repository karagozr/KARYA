using KARYA.CORE.Abstarct;
using KARYA.CORE.Abstract;
using KARYA.CORE.Authorize;
using KARYA.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KARYA.CORE.Concrete.EntityFramework
{
    public abstract class EfRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : CoreEntity, new() where TContext : DbContext, new()
    {
        private HttpContextValues _httpContextValues;
        public EfRepository()
        {
            _httpContextValues = new HttpContextValues();
        }

        public int SCOPE_IDENTY_ID { get; set; }

        protected TEntity CreateLog(TEntity entity)
        {
            if (entity is IModificationEntity)
            {
                ((IModificationEntity)entity).CreatedTime = DateTime.Now;
                ((IModificationEntity)entity).CreatedUserId = _httpContextValues.UserId();
            }

            return entity;
        }
        protected TEntity UpdateLog(TEntity entity)
        {
            if (entity is IModificationEntity)
            {
                ((IModificationEntity)entity).UpdatedTime = DateTime.Now;
                ((IModificationEntity)entity).UpdatedUserId = _httpContextValues.UserId();
            }

            return entity;
        }
        public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
            }
        }
        public virtual async Task<IEnumerable<TEntity>> List(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await (filter == null ? context.Set<TEntity>().ToListAsync() : context.Set<TEntity>().Where(filter).ToListAsync());
            }
        }
        public virtual IQueryable<TEntity> Select()
        {
            var context = new TContext();
            return context.Set<TEntity>();
            
        }
        public virtual async Task Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity = CreateLog(entity);
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                SCOPE_IDENTY_ID = entity.Id;
            }
        }
        public virtual async Task Add(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                foreach (var item in entities)
                {
                    var itemEntity = CreateLog(item);
                    var addedEntity = context.Entry(itemEntity);
                    addedEntity.State = EntityState.Added;
                }

                await context.SaveChangesAsync();

            }
        }
        public virtual async Task AddComplex(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity = CreateLog(entity);
                var addedEntity = context.Set<TEntity>().Add(entity);
                await context.SaveChangesAsync();
                SCOPE_IDENTY_ID = entity.Id;
            }
        }
        public virtual async Task AddComplex(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                foreach (var item in entities)
                {
                    var entity = CreateLog(item);
                    var addedEntity = context.Set<TEntity>().Add(entity);
                    addedEntity.State = EntityState.Added;
                    SCOPE_IDENTY_ID = entity.Id;
                }
                
                await context.SaveChangesAsync();
                
            }
        }
        public virtual async Task Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity = UpdateLog(entity);
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                updatedEntity.Property("CreatedTime").IsModified = entity.Id == 0 ? true : false;
                updatedEntity.Property("CreatedUserId").IsModified = entity.Id == 0 ? true : false;
                await context.SaveChangesAsync();
                SCOPE_IDENTY_ID = entity.Id;

            }
        }
        public virtual async Task Update(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                foreach (var item in entities)
                {
                    var itemEntity = UpdateLog(item);
                    var updatedEntity = context.Entry(itemEntity);
                    updatedEntity.Property("CreatedTime").IsModified = item.Id == 0 ? true : false;
                    updatedEntity.Property("CreatedUserId").IsModified = item.Id == 0 ? true : false;
                    updatedEntity.State = EntityState.Modified;
                }
                await context.SaveChangesAsync();
            }
        }
        public virtual async Task Update(TEntity entity, IEnumerable<string> fields)
        {
            using (var context = new TContext())
            {
                entity = UpdateLog(entity);
                var updatedEntity = context.Entry(entity);
                if(entity.GetType().GetProperty("CreatedTime")!=null)
                    updatedEntity.Property("CreatedTime").IsModified = entity.Id == 0 ? true : false;
                if (entity.GetType().GetProperty("CreatedUserId") != null)
                    updatedEntity.Property("CreatedUserId").IsModified = entity.Id == 0 ? true : false;
                foreach (var field in fields)
                {
                    updatedEntity.Property(field).IsModified = true;
                }
                await context.SaveChangesAsync();
                SCOPE_IDENTY_ID = entity.Id;
            }
        }
        public virtual async Task UpdateComplex(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity = UpdateLog(entity);
                var updatedEntity = context.Set<TEntity>().Update(entity);
                updatedEntity.Property("CreatedTime").IsModified = entity.Id == 0 ? true : false;
                updatedEntity.Property("CreatedUserId").IsModified = entity.Id == 0 ? true : false;

                await context.SaveChangesAsync();
                SCOPE_IDENTY_ID = entity.Id;
            }
        }

        public async Task UpdateComplex(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                foreach (var item in entities)
                {
                    var entity = UpdateLog(item);
                    var updatedEntity = context.Set<TEntity>().Update(entity);
                    updatedEntity.State = EntityState.Modified;
                    SCOPE_IDENTY_ID = entity.Id;
                }

                await context.SaveChangesAsync();
            }
        }

        public virtual async Task AddUpdate(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);

                entity = entity.Id == 0 ? CreateLog(entity):UpdateLog(entity);
                addedEntity.State = entity.Id == 0 ? EntityState.Added : EntityState.Modified;
                addedEntity.Property("CreatedTime").IsModified = entity.Id == 0 ? true : false;
                addedEntity.Property("CreatedUserId").IsModified = entity.Id == 0 ? true : false;

                await context.SaveChangesAsync();
            }
        }
        public virtual async Task AddUpdate(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                if (entities.FirstOrDefault() is IModificationEntity)
                {
                    foreach (var item in entities)
                    {

                        var itemEntity = item.Id == 0 ? CreateLog(item) : UpdateLog(item);
                        var addedEntity = context.Entry(itemEntity);

                        addedEntity.State = EntityState.Detached;

                        addedEntity.Property("CreatedTime").IsModified = item.Id == 0 ? true : false;
                        addedEntity.Property("CreatedUserId").IsModified = item.Id == 0 ? true : false;
                        addedEntity.State = item.Id == 0 ? EntityState.Added : EntityState.Modified;
                    }
                }
                else
                {
                    foreach (var item in entities)
                    {
                        var addedEntity = context.Entry(item);
                        addedEntity.State = item.Id == 0 ? EntityState.Added : EntityState.Modified;
                    }
                }
                

                await context.SaveChangesAsync();

            }
        }
        public virtual async Task Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);

                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
                SCOPE_IDENTY_ID = entity.Id;
            }
        }
        public virtual async Task Delete(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                foreach (var item in entities)
                {
                    var deletedEntity = context.Entry(item);
                    deletedEntity.State = EntityState.Deleted;
                }

                await context.SaveChangesAsync();
            }
        }
        public virtual async Task<int> Count(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await (filter == null ? context.Set<TEntity>().CountAsync() : context.Set<TEntity>().CountAsync(filter));
            }
        }

        
    }
}
