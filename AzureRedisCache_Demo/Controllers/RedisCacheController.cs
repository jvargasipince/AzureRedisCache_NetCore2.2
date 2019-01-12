using AzureRedisCache_Demo.Data;
using AzureRedisCache_Demo.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace AzureRedisCache_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  
    public class RedisCacheController : ControllerBase
    {
        private IDistributedCache _cache;
     
        public RedisCacheController(IDistributedCache cache)
        {
            this._cache = cache;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            string test = _cache.GetString("myData") ?? "";
            if (string.IsNullOrEmpty(test))
            {
                _cache.SetString("myData", "My data as Example");
                test = _cache.GetString("myData") ?? "";
            }

            return test;
        }

        [HttpGet]    
        [Route("getcountries")]
        public ActionResult<IEnumerable<CountryBE>> GetCountries()
        {

            var countriesFromCache = _cache.GetString("countries");

            IEnumerable<CountryBE> countries;

            if (countriesFromCache == null)
            {
                countries = DB.GetListCountries();
                _cache.SetString("countries", JsonConvert.SerializeObject(countries));
            }
            else
            {
                countries = JsonConvert.DeserializeObject<IEnumerable<CountryBE>>(countriesFromCache);
            }

            return countries.ToList();
        }

        [HttpGet]
        [Route("getuserinfo")]
        public ActionResult<UserInfo> GetUserInfo()
        {
            var userFromCache = _cache.GetString("userinfo");

            UserInfo userinfo;

            if (userFromCache == null)
            {
                userinfo = DB.GetUserInfo();
                _cache.SetString("userinfo", JsonConvert.SerializeObject(userinfo));
            }
            else
            {
                userinfo = JsonConvert.DeserializeObject<UserInfo>(userFromCache);
            }
            
            return userinfo;
        }


    }
}