using CountryAPI.Model;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryAPI.FileOperations
{
    public class CSVDataOperations : IFileType
    {
        public List<CountryModel> ReadData(string path)
        {
            List<CountryModel> countryList = new List<CountryModel>();
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                countryList = csv.GetRecords<CountryModel>().ToList();
            }
            return countryList;
        }
        public void WriteData(string path, List<CountryModel> countryList)
        {
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(countryList);
            }
        }
    }
}
