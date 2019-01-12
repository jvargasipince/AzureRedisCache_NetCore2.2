using AzureRedisCache_Demo.Data.Entities;
using System.Collections.Generic;

namespace AzureRedisCache_Demo.Data
{
    public class DB
    {

        public static IList<CountryBE> GetListCountries()
        {
            List<CountryBE> countries = new List<CountryBE>();

            countries.AddRange(new List<CountryBE>() {
                        new CountryBE() { IdCountry = 1, Description = "Peru", IsoCode = "PE" },
                        new CountryBE() { IdCountry = 2, Description = "United States", IsoCode = "US" },
                        new CountryBE() { IdCountry = 3, Description = "Mexico", IsoCode = "MX" },
                        new CountryBE() { IdCountry = 4, Description = "Colombia", IsoCode = "CO" },
                        new CountryBE() { IdCountry = 5, Description = "Brazil", IsoCode = "BR" }
                        });

            return countries;
        }

        public static UserInfo GetUserInfo()
        {
            return new UserInfo
            {
                IdUser = 1989,
                FirstName = "Jorge",
                LastName = "Vargas",
                Email = "jvargas.ipince@outlook.com"
            };
        }

    }
}
