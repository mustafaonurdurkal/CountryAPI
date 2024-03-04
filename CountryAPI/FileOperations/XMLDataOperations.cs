using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CountryAPI.Model;

namespace CountryAPI.FileOperations
{
    public class XMLDataOperations : IFileType
    {
        public List<CountryModel> ReadData(string path)
        {
            XDocument xdoc = XDocument.Load(path);
            return xdoc.Root
               .Elements("City")
               .SelectMany(cityElement => cityElement
                   .Elements("District")
                   .SelectMany(districtElement => districtElement
                       .Elements("Zip")
                       .Select(zipElement => new CountryModel
                       {
                           CityName = cityElement.Attribute("name").Value,
                           CityCode = cityElement.Attribute("code").Value,
                           DistrictName = districtElement.Attribute("name").Value,
                           ZipCode = long.Parse(zipElement.Attribute("code").Value)
                       })))
               .ToList();
        }
        public void WriteData(string path, List<CountryModel> countryList)
        {
            XDocument xdoc = new XDocument(
                new XElement("AddressInfo",
                    countryList.GroupBy(c => new { c.CityName, c.CityCode })
                        .Select(cityGroup => new XElement("City",
                            new XAttribute("name", cityGroup.Key.CityName),
                            new XAttribute("code", cityGroup.Key.CityCode),
                            cityGroup.GroupBy(d => d.DistrictName)
                                .Select(districtGroup => new XElement("District",
                                    new XAttribute("name", districtGroup.Key),
                                    districtGroup.Select(country => new XElement("Zip",
                                        new XAttribute("code", country.ZipCode.ToString())
                                    ))
                                ))
                        ))
                )
            );
            xdoc.Save(path);
        }
    }
}
