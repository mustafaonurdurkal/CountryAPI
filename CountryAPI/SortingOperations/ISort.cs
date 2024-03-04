using CountryAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryAPI.SortingOperations
{
    internal interface ISort
    {

        public void SortByCity(List<CountryModel> countryList, bool ascending = true);
        public void SortByDistrict(List<CountryModel> countryList, bool ascending = true);
    }
}
