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
    public class DataMonkController : ControllerBase
    {
        public static List<DataMonk> MonkData = new List<DataMonk>
        {
             new DataMonk {MonkId = "1",Serial = "1234",TypeAmulet = "เหรียญ",NameAmulet = "พระรอทดสอบ1",
             ShapeAmulet = "พิมพ์ใหญ่",CompoundAmulet = "ทองแดง",NameMonk = "พระอาจารย์ทดสอบ1",
             DateConsecrate = "15/02/19",Temple = "วัดทดสอบระบบ",Province = "ขอนแก่น",NameHost = "คณะลูกศิษย์",
             firstId = "12",CountGenIdOfMonut = "1",AmountGenId = 5},

             new DataMonk {MonkId = "2",Serial = "123455",TypeAmulet = "ผง",NameAmulet = "พระรอทดสอบ2",
             ShapeAmulet = "พิมพ์เล็ก",CompoundAmulet = "ว่านไม้มงคล",NameMonk = "พระอาจารย์ทดสอบ2",
             DateConsecrate = "30/04/19",Temple = "วัดทดสอบระบบ2",Province = "นครพนม",NameHost = "คณะลูกศิษย์99",
             firstId = "13",CountGenIdOfMonut = "2",AmountGenId = 5},


        };
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<DataMonk>> GetMonkDataAll()
        {
            return MonkData.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<DataMonk> GetMonkDataById(string id)
        {
            return MonkData.FirstOrDefault(it => it.MonkId == id.ToString());
        }

        // POST api/values
        [HttpPost]
        public DataMonk AddMonkData([FromBody] DataMonk DataMonkz)
        {

            Random rnd = new Random();
            int NumberRandom = rnd.Next(0, 9);
            // string first = DataMonkz.firstId.ToString();
            // string count = DataMonkz.CountGenIdOfMonut.ToString();
            // string runId = DataMonkz.MonkId.ToString();

            // var id = first + count + "000" + runId + NumberRandom.ToString();

            var id = Guid.NewGuid().ToString();
            var serial = DataMonkz.firstId + DataMonkz.CountGenIdOfMonut + "000" + DataMonkz.MonkId + NumberRandom;
            var item = new DataMonk
            {
                MonkId = id,
                Serial = serial,
                TypeAmulet = DataMonkz.TypeAmulet,
                NameAmulet = DataMonkz.NameAmulet,
                ShapeAmulet = DataMonkz.ShapeAmulet,
                CompoundAmulet = DataMonkz.CompoundAmulet,
                NameMonk = DataMonkz.NameMonk,
                DateConsecrate = DataMonkz.DateConsecrate,
                Temple = DataMonkz.Temple,
                Province = DataMonkz.Province,
                NameHost = DataMonkz.NameHost,
                firstId = DataMonkz.firstId,
                CountGenIdOfMonut = DataMonkz.CountGenIdOfMonut,
                AmountGenId = DataMonkz.AmountGenId

            };
            MonkData.Add(item);

            return item;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public DataMonk EditMonkData(string id, [FromBody] DataMonk data)
        {
            var _id = MonkData.FirstOrDefault(it => it.MonkId == id.ToString());
            var item = new DataMonk
            {
                MonkId = id.ToString(),
                TypeAmulet = data.TypeAmulet,
                NameAmulet = data.NameAmulet,
                ShapeAmulet = data.ShapeAmulet,
                CompoundAmulet = data.CompoundAmulet,
                NameMonk = data.NameMonk,
                DateConsecrate = data.DateConsecrate,
                Temple = data.Temple,
                Province = data.Province,
                NameHost = data.NameHost,
                firstId = data.firstId,
                CountGenIdOfMonut = data.CountGenIdOfMonut,
                AmountGenId = data.AmountGenId
            };
            MonkData.Remove(_id);
            MonkData.Add(item);
            return data;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var delete = MonkData.FirstOrDefault(it => it.MonkId == id.ToString());
            MonkData.Remove(delete);
        }
    }
}
