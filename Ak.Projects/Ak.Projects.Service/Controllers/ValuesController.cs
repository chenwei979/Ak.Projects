using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ak.Projects.BusnissLogic;
using Ak.Projects.Entities;

namespace Ak.Projects.Service.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public ValuesController()
        {
            BusnissLogic = new UserBusnissLogic();
        }

        protected UserBusnissLogic BusnissLogic { get; set; }

        // GET api/values
        [HttpGet]
        public IEnumerable<UserEntity> Get()
        {
            return BusnissLogic.GetItems();
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
