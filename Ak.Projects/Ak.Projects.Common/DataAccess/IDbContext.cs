using System;
using System.Data;

namespace Ak.Projects.Common.DataAccess
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Database { get; set; }
    }
}
