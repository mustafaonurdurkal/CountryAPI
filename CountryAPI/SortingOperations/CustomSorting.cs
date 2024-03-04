using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountryAPI.Model;

namespace CountryAPI.SortingOperations
{
    public class CustomSorting : ISort
    {
        public void SortByCity(List<CountryModel> countryList, bool ascending = true)
        {
            new QuickSort().QuickSortByCity(countryList, 0, countryList.Count - 1, ascending);
        }

        public void SortByDistrict(List<CountryModel> countryList, bool ascending = true)

        {
            new QuickSort().QuickSortByDistrict(countryList, 0, countryList.Count - 1, ascending);
        }

        public void SortByCityAndDistrict(List<CountryModel> countryList, bool ascending = true)
        {
            SortByCity(countryList);
            var resultGroup = countryList.GroupBy(e => e.CityName).ToList();
            countryList.Clear();
            foreach (var item in resultGroup)
            {
                List<CountryModel> sortedGroup = item.ToList();
                SortByDistrict(sortedGroup);
                countryList.AddRange(sortedGroup);
            }
        }

    }

}
