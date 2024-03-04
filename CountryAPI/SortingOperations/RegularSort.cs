using CountryAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryAPI.SortingOperations
{
    public class RegularSort : ISort
    {
        public void SortByCity(List<CountryModel> countryList, bool ascending = true)
        {
            countryList.Sort((x, y) => (ascending ? 1 : -1 )* x.CityName.CompareTo(y.CityName));
        }

        public void SortByDistrict(List<CountryModel> countryList, bool ascending = true)
        {
            countryList.Sort((x, y) => (ascending ? 1 : -1) * x.DistrictName.CompareTo(y.DistrictName));
        }
        public void SortByZipCode(List<CountryModel> countryList, bool ascending = true)
        {
            countryList.Sort((x, y) => (ascending ? 1 : -1) * x.ZipCode.CompareTo(y.ZipCode));
        }
    }
}
