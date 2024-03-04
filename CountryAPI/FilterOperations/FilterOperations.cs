using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountryAPI.Model;

namespace CountryAPI.FilterOperations
{
    public class FilterOperations : IFilterOperations
    {
        public List<CountryModel> FilterByCity(List<CountryModel> countryList, string cityName)
        {
            return countryList.Where(c => c.CityName == cityName).ToList();
        }
        //Filter with multiple city
        public List<CountryModel> FilterByCity(List<CountryModel> countryList, List<string> cityFilter)
        {
            List<CountryModel> filteredCities = new List<CountryModel>();
            foreach (var filterVal in cityFilter)
            {
                filteredCities.AddRange(countryList.Where(c => c.CityName == filterVal).ToList());
            }
            return filteredCities;
        }
        public List<CountryModel> FilterByDistrict(List<CountryModel> countryList, string districtName)
        {
            return countryList.Where(c => c.DistrictName == districtName).ToList();
        }
        //Filter with multiple city
        public List<CountryModel> FilterByDistrict(List<CountryModel> countryList, List<string> districtFilter)
        {
            List<CountryModel> filteredDistricts = new List<CountryModel>();
            foreach (var filterVal in districtFilter)
            {
                filteredDistricts.AddRange(countryList.Where(c => c.DistrictName == filterVal).ToList());
            }
            return filteredDistricts;
        }
        //Filter with Any Prop
        public List<CountryModel> FilterByProperty(List<CountryModel> countryList, string propertyName, string propertyValue)
        {
            var filteredList = countryList
                .Where(c => c.GetType().GetProperty(propertyName)?.GetValue(c, null)?.ToString() == propertyValue)
                .ToList();

            return filteredList;
        }
    }
}
