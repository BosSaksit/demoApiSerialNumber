using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoApiSerialNumber.Models;
using Microsoft.AspNetCore.Mvc;

namespace demoApiSerialNumber.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> data = new List<User>
        {
             new User {UserId = "1",Name = "teset1",Tel = "0841543232",Address = "15/78 testewsf",Idcard = "1231654868"},
             new User {UserId = "2",Name = "test2",Tel = "0695557455",Address = "15/78 testewsf",Idcard = "1231654868"},
        };
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUserAll()
        {
            return data.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> GetById(string id)
        {
            return data.FirstOrDefault(it =>it.UserId == id.ToString());
        }

        // POST api/values
        [HttpPost]
        public User AddUser([FromBody] User Userx)
        {
            var id = Guid.NewGuid().ToString();
            var item = new User
            {
                UserId = id,
                Name = Userx.Name,
                Tel = Userx.Tel,
                Address = Userx.Address,
                Idcard = Userx.UserId
            };
            data.Add(item);
            return Userx;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public User EditUser(string id, [FromBody] User Userx)
        {
            var _id = data.FirstOrDefault(it => it.UserId == id.ToString());
             var item = new User
            {
                UserId = id,
                Name = Userx.Name,
                Tel = Userx.Tel,
                Address = Userx.Address,
                Idcard = Userx.Idcard
            };
            data.Remove(_id);
            data.Add(item);
            return Userx;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteUser(string id)
        {
            var delete = data.FirstOrDefault(it => it.UserId == id.ToString());
            data.Remove(delete);
        }
    }
}