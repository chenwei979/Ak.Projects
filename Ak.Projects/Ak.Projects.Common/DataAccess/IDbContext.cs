using Dapper;
using System;
using System.Data;

namespace Ak.Projects.Common.DataAccess
{
    public interface IDbContext : IDisposable,Data
    {
        IDbConnection Database { get; set; }

        bool SaveChanges();
    }

    
}
