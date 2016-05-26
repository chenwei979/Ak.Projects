using System;

namespace Ak.Projects.Common.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContext DbContext { get; set; }
        void SaveChanges();
    }
}
