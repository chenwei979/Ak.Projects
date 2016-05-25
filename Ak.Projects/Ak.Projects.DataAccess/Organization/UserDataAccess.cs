using Ak.Projects.Entities;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
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
                var items = connection.Query<UserEntity>("SELECT * FROM [dbo].[User]").ToList();

                

                var updateItem = items.Where(item => item.Id == 3).FirstOrDefault();
                updateItem.UserName = "bruce.chen";
                connection.Update(updateItem);

                var insertItem = new UserEntity()
                {
                    //Id = 5,
                    Guid = Guid.NewGuid(),
                    UserName = "chenwei_979",
                    Password = "cw979",
                    DisplayName = "Bruce Chen"
                };
                connection.Insert(insertItem);

                return items;
            }
        }
    }
}
