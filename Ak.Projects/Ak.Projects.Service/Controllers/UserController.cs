using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ak.Projects.BusnissLogic;
using Ak.Projects.Entities;

namespace Ak.Projects.Service.Controllers
{
    public class UserController : Controller
    {
        public UserBusnissLogic BusnissLogic { get; set; }

        [HttpPost]
        public void Post([FromBody]UserEntity user)
        {
            BusnissLogic.Save(user);
        }
    }
}
