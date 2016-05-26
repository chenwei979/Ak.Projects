using System.Data;

namespace Ak.Projects.Common.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IDbContext dbContext)
        {
            DbContext = dbContext;
            DbTransaction = DbContext.Database.BeginTransaction();
        }

        public IDbContext DbContext { get; set; }
        protected IDbTransaction DbTransaction { get; set; }

        public void SaveChanges()
        {
            try
            {
                DbTransaction.Commit();
            }
            catch
            {
                DbTransaction.Rollback();
            }
        }

        public void Dispose()
        {
            DbTransaction.Dispose();
            DbContext.Dispose();
        }
    }
}
