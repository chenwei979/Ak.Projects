using System.Data;

namespace Ak.Projects.Common.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IDatabase database)
        {
            Database = database;
            Transaction = Database.BeginTransaction();
        }

        public IDatabase Database { get; set; }
        protected IDbTransaction Transaction { get; set; }

        public void SaveChanges()
        {
            try
            {
                Transaction.Commit();
            }
            catch
            {
                Transaction.Rollback();
            }
        }

        public void Dispose()
        {
            Transaction.Dispose();
            Database.Dispose();
        }
    }
}
