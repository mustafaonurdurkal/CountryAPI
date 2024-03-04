using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountryAPI.Model;

namespace CountryAPI.CommonOperations
{
    public class CommonOperations
    {
        public void PrintCountryDatas(List<CountryModel> countryList)
        {
            foreach (var country in countryList)
            {
                Console.WriteLine($"CityName: {country.CityName}, CityCode: {country.CityCode}, DistrictName: {country.DistrictName}," +
                                   $"ZipCode: {country.ZipCode}");
            }
        }
    }
}
