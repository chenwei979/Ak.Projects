using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak.Projects.Common.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContext DbContext { get; set; }
        bool SaveChanges();
    }
}
