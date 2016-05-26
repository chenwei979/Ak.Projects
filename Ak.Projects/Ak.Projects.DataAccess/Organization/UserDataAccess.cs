using Ak.Projects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Ak.Projects.Common.DataAccess;

namespace Ak.Projects.DataAccess
{
    public class UserDataAccess : Repository<UserEntity>, IRepository<UserEntity>
    {
        public IList<UserEntity> GetItems()
        {
            var items = GetAllItems();

            var updateItem = items.Where(item => item.Id == 3).FirstOrDefault();
            updateItem.UserName = "bruce.chen";
            Save(updateItem);

            var insertItem = new UserEntity()
            {
                Guid = Guid.NewGuid(),
                UserName = "chenwei_979",
                Password = "cw979",
                DisplayName = "Bruce Chen"
            };
            Save(insertItem);

            UnitOfWork.SaveChanges();

            return items;
        }
    }
}
