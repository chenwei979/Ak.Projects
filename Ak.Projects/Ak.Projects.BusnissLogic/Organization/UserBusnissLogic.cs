using Ak.Projects.DataAccess;
using Ak.Projects.Entities;
using System;
using System.Collections.Generic;

namespace Ak.Projects.BusnissLogic
{
    public class UserBusnissLogic : IDisposable
    {
        public UserDataAccess DataAccess { get; set; }

        public UserBusnissLogic(UserDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        public void Save(params UserEntity[] entities)
        {
            DataAccess.Save(entities);
        }

        public void GetItemById(long id)
        {
            DataAccess.GetItemById(id);
        }

        public IList<UserEntity> GetAllItems()
        {
            return DataAccess.GetAllItems();
        }

        public void Dispose()
        {
            DataAccess.Dispose();
        }
    }
}
