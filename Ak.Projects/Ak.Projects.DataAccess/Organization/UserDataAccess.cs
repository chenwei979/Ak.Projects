using Ak.Projects.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ak.Projects.DataAccess
{
    public class UserDataAccess
    {
        public IList<UserEntity> GetItems()
        {
            using (SqlConnection connection = new SqlConnection("data source=aa6od2pqa9.database.chinacloudapi.cn;initial catalog=AKProject;user id=akmii@aa6od2pqa9;password=!QAZ2wsx;"))
            {
                connection.Open();
                return connection.Query<UserEntity>("SELECT * FROM [dbo].[User]").ToList();
            }
        }
    }
}
