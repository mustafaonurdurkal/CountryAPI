using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountryAPI.Model;

namespace CountryAPI.FilterOperations
{
    public interface IFilterOperations
    {

        public List<CountryModel> FilterByCity(List<CountryModel> countryList, string cityName);
        public List<CountryModel> FilterByCity(List<CountryModel> countryList, List<string> cityFilter);
        public List<CountryModel> FilterByDistrict(List<CountryModel> countryList, string districtName);
        public List<CountryModel> FilterByDistrict(List<CountryModel> countryList, List<string> districtFilter);
        public List<CountryModel> FilterByProperty(List<CountryModel> countryList, string propertyName, string propertyValue);

    }
}
