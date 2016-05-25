using Ak.Projects.DataAccess;
using Ak.Projects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ak.Projects.BusnissLogic
{
    public class UserBusnissLogic
    {
        public UserBusnissLogic()
        {
            DataAccess = new UserDataAccess();
        }

        protected UserDataAccess DataAccess { get; set; }

        public IList<UserEntity> GetItems()
        {
            return DataAccess.GetItems();
        }
    }
}
