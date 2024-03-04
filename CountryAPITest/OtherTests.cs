using CountryAPI.FileOperations;
using CountryAPI.Model;
using CountryAPI.SortingOperations;
using NUnit.Framework;
using System.Reflection;

namespace CountryAPITest
{
    public class OtherTests
    {
        string CSVInpfilePath;
        string XMLInpfilePath;
        [SetUp]
        public void Setup()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            CSVInpfilePath = Path.Combine(path, @"Datas\sample_data.csv");
            XMLInpfilePath = Path.Combine(path, @"Datas\sample_data.xml");
        }
        [Test]
        public void ReadCSVData()
        {
            List<CountryModel> result = new TestUtils().ReadCSV(CSVInpfilePath);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
        }
        [Test]
        public void ReadXMLData()
        {
            List<CountryModel> result = new TestUtils().ReadXML(XMLInpfilePath);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void SortByCity()
        {
            // Arrange
            IFileType dataOperations = new CSVDataOperations();
            List<CountryModel> result = dataOperations.ReadData(CSVInpfilePath);

            CustomSorting sortingOperations = new CustomSorting();
            sortingOperations.SortByCity(result, false);
            // Act

            // Assert
            Assert.That(string.Compare(result[0].CityName, result[400].CityName), Is.EqualTo(1));
        }

        [Test]
        public void SortByDistrict()
        {
            IFileType dataOperations = new CSVDataOperations();
            List<CountryModel> result = dataOperations.ReadData(CSVInpfilePath);

            CustomSorting sortingOperations = new CustomSorting();
            sortingOperations.SortByDistrict(result, false);

            Assert.That(string.Compare(result[0].DistrictName, result[400].DistrictName), Is.EqualTo(1));
        }

    }
}