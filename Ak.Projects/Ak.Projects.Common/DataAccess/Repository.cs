using Ak.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Ak.Entities
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class,IEntity
    {
        private DbSet<TEntity> _entitySet;
        private IQueryable<TEntity> _entityQuery;

        public IDbContext DbContext { get; private set; }

        public EfRepository(IDbContext dbContext)
        {
            DbContext = dbContext;
            _entitySet = DbContext.Set<TEntity>();
            _entityQuery = dbContext.Set<TEntity>().AsNoTracking();
        }

        #region Save

        public virtual void Insert(TEntity entity)
        {
            entity.Guid = Guid.NewGuid();
            var now = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("China Standard Time"));
            entity.CreateDate = now;
            entity.UpdateDate = now;

            _entitySet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var orgEntity = GetItemById(entity.Id);
            entity.Id = orgEntity.Id;
            entity.Guid = orgEntity.Guid;
            entity.CreatorName = orgEntity.CreatorName;
            entity.CreatorGUID = orgEntity.CreatorGUID;
            entity.CreateDate = orgEntity.CreateDate;
            entity.UpdateDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("China Standard Time"));

            DbContext.Entry(orgEntity).CurrentValues.SetValues(entity);
        }

        public virtual void Save(TEntity entity)
        {
            if (entity.Id > 0) Update(entity);
            else Insert(entity);
        }

        public virtual void Save(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.Id > 0) Update(entity);
                else Insert(entity);
            }
        }

        #endregion

        #region Delete

        public virtual void Delete(int id)
        {
            var entity = GetItemById(id);
            if (entity == null) throw new Exception(string.Format("Delete failed, cannot find this item which Id is {0}.", id));
            _entitySet.Remove(entity);
        }

        public virtual void Delete(int[] ids)
        {
            foreach (var id in ids)
            {
                var entity = GetItemById(id);
                _entitySet.Remove(entity);
            }
        }

        #endregion

        #region Get

        public virtual TEntity GetItemById(int id)
        {
            return _entitySet.Where(item => item.Id == id).FirstOrDefault();

        }

        public virtual TEntity GetItemByGuid(Guid guid)
        {
            return _entitySet.Where(item => item.Guid == guid).FirstOrDefault();
        }

        public virtual IList<TEntity> GetItems(Expression<Func<TEntity, bool>> filter)
        {
            return _entityQuery.Where(filter).ToList();
        }

        public virtual IList<TEntity> GetAllItems()
        {
            return _entityQuery.ToList();
        }

        public IPagedList<TEntity> GetPagedItems(int pageIndex, int pageSize)
        {
            return _entityQuery.OrderByDescending(item => item.Id).ToPagedList(pageIndex, pageSize);
        }

        public virtual IQueryable<TEntity> GetItems()
        {
            return _entityQuery;
        }

        #endregion

        public virtual void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
