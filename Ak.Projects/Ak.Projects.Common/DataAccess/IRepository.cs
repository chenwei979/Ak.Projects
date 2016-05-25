using Ak.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ak.Entities
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class,IEntity
    {
        IDbContext DbContext { get; }

        void Save(TEntity entity);

        void Save(IList<TEntity> entities);

        void Delete(int id);

        void Delete(int[] ids);

        TEntity GetItemById(int id);

        TEntity GetItemByGuid(Guid guid);

        IList<TEntity> GetItems(Expression<Func<TEntity, bool>> filter);

        IList<TEntity> GetAllItems();

        IPagedList<TEntity> GetPagedItems(int pageIndex, int pageSize);

        IQueryable<TEntity> GetItems();
    }
}
