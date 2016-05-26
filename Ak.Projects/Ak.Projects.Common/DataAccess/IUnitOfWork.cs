using System;

namespace Ak.Projects.Common.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IDatabase Database { get; set; }
        void SaveChanges();
    }
}
