using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountryAPI.Model;

namespace CountryAPI.FileOperations
{
    public abstract class JSONDataOperations : IFileType
    {
        public abstract List<CountryModel> ReadData(string path);

        public abstract void WriteData(string path, List<CountryModel> countryList);
    }
}
