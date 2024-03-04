using CountryAPI.FileOperations;
using CountryAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryAPITest
{
    internal class TestUtils
    {

        IFileType? operation;
        internal List<CountryModel> ReadCSV(string Path)
        {
            operation = new CSVDataOperations();
            List<CountryModel> result = operation.ReadData(Path);
            return result;
        }
        internal List<CountryModel> ReadXML(string Path)
        {
            operation = new XMLDataOperations();
            List<CountryModel> result = operation.ReadData(Path);
            return result;
        }
        internal void WriteCSV(List<CountryModel> countries, string Path)
        {
            operation = new CSVDataOperations();
            operation.WriteData(Path, countries);
        }
        internal void WriteXML(List<CountryModel> countries, string Path)
        {
            operation = new XMLDataOperations();
            operation.WriteData(Path, countries);
        }
        internal bool ControlSorting(List<CountryModel> result)
        {
            string preCityName = "";
            string preDistrictName = "";
            bool testResult = true;
            foreach (var item in result)
            {
                if (preCityName != "")
                {
                    int returnVal = string.Compare(item.CityName, preCityName);
                    if (returnVal == -1)
                    {
                        testResult = false;
                        break;
                    }
                    else if (returnVal == 0)
                    {
                        returnVal = string.Compare(item.DistrictName, preDistrictName);
                        if (returnVal == -1)
                        {
                            testResult = false;
                            break;
                        }
                    }
                }
                preCityName = item.CityName;
                preDistrictName = item.DistrictName;
            }
            return testResult;
        }
        internal bool ControlFiltredCity(string cityName, List<CountryModel> filteredList)
        {
            bool controlVal = true;
            foreach (CountryModel model in filteredList)
            {

                if (model.CityName != cityName)
                {
                    controlVal = false;
                    break;
                }
            }
            return controlVal;

        }
    }
}
