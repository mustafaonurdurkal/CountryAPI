using CountryAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryAPI.SortingOperations
{
    internal class QuickSort
    {
        internal void QuickSortByCity(List<CountryModel> countryList, int low, int high, bool ascending)
        {
            if (low < high)
            {
                int pivotIndex = PartitionByCity(countryList, low, high, ascending);

                QuickSortByCity(countryList, low, pivotIndex - 1, ascending);
                QuickSortByCity(countryList, pivotIndex + 1, high, ascending);
            }
        }
        internal void QuickSortByDistrict(List<CountryModel> countryList, int low, int high, bool ascending)
        {
            if (low < high)
            {
                int pivotIndex = PartitionByDistrict(countryList, low, high, ascending);

                QuickSortByDistrict(countryList, low, pivotIndex - 1, ascending);
                QuickSortByDistrict(countryList, pivotIndex + 1, high, ascending);
            }
        }
        private int PartitionByCity(List<CountryModel> countryList, int low, int high, bool ascending)
        {
            string pivot = countryList[high].CityName;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                int comparisonResult = string.Compare(countryList[j].CityName, pivot);
                bool shouldSwap = ascending ? comparisonResult < 0 : comparisonResult > 0;

                if (shouldSwap)
                {
                    i++;
                    SwapCountryModels(countryList, i, j);
                }
            }

            SwapCountryModels(countryList, i + 1, high);
            return i + 1;
        }
        private int PartitionByDistrict(List<CountryModel> countryList, int low, int high, bool ascending)
        {
            string pivot = countryList[high].DistrictName;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                int comparisonResult = string.Compare(countryList[j].DistrictName, pivot);
                bool shouldSwap = ascending ? comparisonResult < 0 : comparisonResult > 0;

                if (shouldSwap)
                {
                    i++;
                    SwapCountryModels(countryList, i, j);
                }
            }

            SwapCountryModels(countryList, i + 1, high);
            return i + 1;
        }

        private void SwapCountryModels(List<CountryModel> countryList, int a, int b)
        {
            CountryModel temp = countryList[a];
            countryList[a] = countryList[b];
            countryList[b] = temp;
        }
    }
}
