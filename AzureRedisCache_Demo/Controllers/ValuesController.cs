using AzureRedisCache_Demo.Data;
using AzureRedisCache_Demo.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AzureRedisCache_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "My data as Example";
        }

        [HttpGet]
        [Route("getcountries")]
        public ActionResult<IEnumerable<CountryBE>> GetCountries()
        {
            return DB.GetListCountries().ToList();
        }

        [HttpGet]
        [Route("getuserinfo")]
        public ActionResult<UserInfo> GetUserInfo()
        {
            return DB.GetUserInfo();
        }
    }
}
