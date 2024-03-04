using CountryAPI.FilterOperations;
using CountryAPI.Model;
using CountryAPI.SortingOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CountryAPITest
{
    public class ExpectedTests
    {
        string CSVInpfilePath;
        string XMLInpfilePath;
        string CSVOutFilePath;
        string XMLOutFilePath;


        [SetUp]
        public void Setup()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            CSVInpfilePath = Path.Combine(path, @"Datas\sample_data.csv");
            XMLInpfilePath = Path.Combine(path, @"Datas\sample_data.xml");
            CSVOutFilePath = Path.Combine(path, @"Datas\output.csv");
            XMLOutFilePath = Path.Combine(path, @"Datas\output.xml");
        }
        [Test]
        public void TestCase1()
        {
            // Arrange
            TestUtils testUtils = new TestUtils();
            IFilterOperations filterOperations = new FilterOperations();
            // Act
            List<CountryModel> result = testUtils.ReadCSV(CSVInpfilePath);
            result = filterOperations.FilterByCity(result, "Antalya");
            testUtils.WriteXML(result, XMLOutFilePath);
            // Assert
            result = testUtils.ReadXML(XMLOutFilePath);
            Assert.IsTrue(testUtils.ControlFiltredCity("Antalya", result));
        }
        [Test]
        public void TestCase2()
        {
            // Arrange
            TestUtils testUtils = new TestUtils();
            CustomSorting sortingOperations = new CustomSorting();
            // Act
            List<CountryModel> result = testUtils.ReadXML(XMLInpfilePath);
            sortingOperations.SortByCityAndDistrict(result);
            testUtils.WriteXML(result, XMLOutFilePath);
            // Assert
            result= testUtils.ReadXML(XMLOutFilePath);
            Assert.AreEqual(result[0].CityName, "Adana");
            Assert.AreEqual(result[0].DistrictName, "Aladað");
            Assert.IsTrue(new TestUtils().ControlSorting(result));
        }
        [Test]
        public void TestCase3()
        {
            // Arrange
            TestUtils testUtils = new TestUtils();
            IFilterOperations filterOperations = new FilterOperations();
            RegularSort sortingOperations = new RegularSort();
            // Act
            List<CountryModel> result = testUtils.ReadXML(XMLInpfilePath);
            result = filterOperations.FilterByCity(result, "Ankara");

            sortingOperations.SortByZipCode(result, true);

            testUtils.WriteCSV(result, CSVOutFilePath);

            result= testUtils.ReadCSV(CSVOutFilePath);

            // Assert
            Assert.AreEqual(result[0].CityName, "Ankara");
            Assert.AreEqual(result[0].ZipCode, 6010);
        }


    }
}
