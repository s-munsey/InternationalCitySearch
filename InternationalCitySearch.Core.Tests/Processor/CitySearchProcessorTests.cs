using CitySearch;
using InternationalCitySearch.Core.DataInterface;
using InternationalCitySearch.Core.Domain;
using Moq;

namespace InternationalCitySearch.Core.Processor
{
    public class CitySearchProcessorTests
    {
        private readonly CitySearchRequestProcessor _processor;
        private readonly Mock<ICitiesRepository> _citiesRepositoryMock;

        public CitySearchProcessorTests()
        {
            _citiesRepositoryMock = new Mock<ICitiesRepository>();
            _processor = new CitySearchRequestProcessor(_citiesRepositoryMock.Object);
        }

        [Fact]
        public void ShouldReturnICityResult()
        {
            // Arramge
            var request = "BANG";

            // Act
            ICityResult result = _processor.Search(request);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<ICityResult>(result);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.Search(null));

            Assert.Equal("searchString", exception.ParamName);
        }

        [Fact]
        public void ShouldReturnListOfCitiesAndNextLettersGivenValidSearchString()
        {
            // Arrange
            var expectedResult = new CityResult() { NextCities = new List<string>() { "BANGALORE", "BANGKOK", "BANGUI" }, NextLetters = new List<string>() { "A", "K", "U" } };
            _citiesRepositoryMock.Setup(r => r.GetCities("BANG")).Returns(new List<string>() { "BANGALORE", "BANGKOK", "BANGUI" });
            // Act
            var result = _processor.Search("BANG");
            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.NextCities, result.NextCities);
            Assert.Equal(expectedResult.NextLetters, result.NextLetters);
        }

        [Fact]
        public void ShouldReturnSpaceAsNextLetterGivenValidSearchString()
        {
            // Arrange
            var expectedResult = new CityResult() { NextCities = new List<string>() { "LA PAZ", "LA PLATA", "LAGOS" }, NextLetters = new List<string>() { " ", "G" } };
            _citiesRepositoryMock.Setup(r => r.GetCities("LA")).Returns(new List<string>() { "LA PAZ", "LA PLATA", "LAGOS" });
            // Act
            var result = _processor.Search("LA");
            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.NextCities, result.NextCities);
            Assert.Equal(expectedResult.NextLetters, result.NextLetters);
        }

        [Fact]
        public void ShouldReturnNoCitiesOrLettersGivenValidString()
        {
            // Arrange
            var expectedResult = new CityResult() { NextCities = new List<string>() { }, NextLetters = new List<string>() { } };
            _citiesRepositoryMock.Setup(r => r.GetCities("LA")).Returns(new List<string>() { "ZARIA", "ZUGHAI", "ZIBO" });
            // Act
            var result = _processor.Search("ZE");
            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.NextCities, result.NextCities);
            Assert.Equal(expectedResult.NextLetters, result.NextLetters);
        }
    }
}
