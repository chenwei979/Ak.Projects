using Ak.Projects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Ak.Projects.Common.DataAccess;

namespace Ak.Projects.DataAccess
{
    public class UserDataAccess : Repository<UserEntity>, IRepository<UserEntity>
    {
        public UserDataAccess(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        //public IList<UserEntity> GetItems()
        //{
        //    var items = GetAllItems();

        //    var updateItem = items.Where(item => item.Id == 3).FirstOrDefault();
        //    updateItem.Account = "bruce.chen1";
        //    Save(updateItem);

        //    var insertItem = new UserEntity()
        //    {
        //        Guid = Guid.NewGuid(),
        //        Account = "chenwei_9791",
        //        Password = "cw9791",
        //        DisplayName = "Bruce Chen"
        //    };
        //    Save(insertItem);

        //    UnitOfWork.SaveChanges();

        //    return items;
        //}
    }
}
