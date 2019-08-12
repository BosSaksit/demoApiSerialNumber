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
        public static List<User> UserData = new List<User>
        {
             new User {IdUser = "1",NameUser = "teset1",TelUser = "0841543232",AddressUser = "15/78 testewsf",IdcardUser = "1231654868"},
             new User {IdUser = "2",NameUser = "test2",TelUser = "0695557455",AddressUser = "15/78 testewsf",IdcardUser = "1231654868"},
        };
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUserAll()
        {
            return UserData.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> GetById(string id)
        {
            return UserData.FirstOrDefault(it =>it.IdUser == id.ToString());
        }

        // POST api/values
        [HttpPost]
        public User AddUser([FromBody] User Userx)
        {
            var id = Guid.NewGuid().ToString();
            var item = new User
            {
                IdUser = id.ToString(),
                NameUser = Userx.NameUser,
                TelUser = Userx.TelUser,
                AddressUser = Userx.AddressUser,
                IdcardUser = Userx.IdcardUser
            };
            UserData.Add(item);
            return item;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public User EditUser(string id, [FromBody] User Userx)
        {
            var _id = UserData.FirstOrDefault(it => it.IdUser == id.ToString());
             var item = new User
            {
                IdUser = id,
                NameUser = Userx.NameUser,
                TelUser = Userx.TelUser,
                AddressUser = Userx.AddressUser,
                IdcardUser = Userx.IdcardUser
            };
            UserData.Remove(_id);
            UserData.Add(item);
            return Userx;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteUser(string id)
        {
            var delete = UserData.FirstOrDefault(it => it.IdUser == id.ToString());
            UserData.Remove(delete);
        }
    }
}