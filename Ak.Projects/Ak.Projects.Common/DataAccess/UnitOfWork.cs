using System;
using System.Data;

namespace Ak.Projects.Common.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IDatabase database)
        {
            Database = database;
            Database.Open();
            Transaction = Database.BeginTransaction();
            IsolationLevel = Transaction.IsolationLevel;
            Connection = Transaction.Connection;
        }

        public IsolationLevel IsolationLevel { get; set; }
        public IDbConnection Connection { get; set; }
        public IDatabase Database { get; set; }
        protected IDbTransaction Transaction { get; set; }

        public void SaveChanges()
        {
            try
            {
                Commit();
            }
            catch
            {
                Rollback();
            }
        }

        public void Commit()
        {
            Transaction.Commit();
        }

        public void Rollback()
        {
            Transaction.Rollback();
        }

        public void Dispose()
        {
            Transaction.Dispose();
            Database.Dispose();
        }
    }
}
