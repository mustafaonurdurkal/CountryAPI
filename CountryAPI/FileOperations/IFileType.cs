using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountryAPI.Model;

namespace CountryAPI.FileOperations
{
    public interface IFileType
    {
        public List<CountryModel> ReadData(string path);
        public void WriteData(string path, List<CountryModel> countryList);
    }
}