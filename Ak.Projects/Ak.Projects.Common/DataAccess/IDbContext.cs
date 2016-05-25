using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak.Entities
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class, IEntity;

        bool SaveChanges();
    }

    public class AkDbContext : DbContext, IDbContext
    {
        public AkDbContext()
            : base("name=Entities")
        {
            this.Database.Log = sqlCommond => Debug.WriteLine(sqlCommond);
        }

        DbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return Set<TEntity>();
        }

        DbEntityEntry<TEntity> IDbContext.Entry<TEntity>(TEntity entity)
        {
            return Entry(entity);
        }

        bool IDbContext.SaveChanges()
        {
            return SaveChanges() > 0;
        }
    }
}
