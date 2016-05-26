using Ak.Projects.DataAccess;
using Ak.Projects.Entities;
using System.Collections.Generic;

namespace Ak.Projects.BusnissLogic
{
    public class UserBusnissLogic
    {
        public UserDataAccess DataAccess { get; set; }

        public UserBusnissLogic(UserDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        public IList<UserEntity> GetItems()
        {
            return DataAccess.GetItems();
        }
    }
}
