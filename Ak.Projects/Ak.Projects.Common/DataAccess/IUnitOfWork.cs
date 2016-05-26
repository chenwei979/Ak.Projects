using System;
using System.Data;

namespace Ak.Projects.Common.DataAccess
{
    public interface IUnitOfWork : IDbTransaction, IDisposable
    {
        IDatabase Database { get; set; }
        void SaveChanges();
    }
}
