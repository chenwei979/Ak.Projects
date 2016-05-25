using Ak.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak.Entities
{
    public class EfUnitOfWork : IUnitOfWork
    {
        public EfUnitOfWork(IDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IDbContext DbContext { get; set; }

        public bool SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
