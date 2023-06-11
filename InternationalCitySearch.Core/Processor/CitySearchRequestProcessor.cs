using CitySearch;
using InternationalCitySearch.Core.DataInterface;
using InternationalCitySearch.Core.Domain;

namespace InternationalCitySearch.Core.Processor
{
    public class CitySearchRequestProcessor : ICityFinder, ICitySearchRequestProcessor
    {
        private readonly ICitiesRepository _cityRepository;
        public CitySearchRequestProcessor(ICitiesRepository repository)
        {
            _cityRepository = repository;
        }

        public ICityResult Search(string searchString)
        {
            if (searchString == null)
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            var result = new CityResult() { NextCities = new List<string>(), NextLetters = new List<string>() };

            var cities = _cityRepository.GetCities(searchString);

            if(cities == null)
            {
                return result;
            }

            result.NextCities = cities;

            foreach ( var c in cities)
            {
                var nextLetter = GetNextLetter(c, searchString);
                if (nextLetter != string.Empty)
                {
                    if (!result.NextLetters.Contains(nextLetter))
                    {
                        result.NextLetters.Add(nextLetter);
                    }
                }
            }

            return result;
        }

        internal string GetNextLetter(string city, string searchString)
        {
            // Get the index of the last character in the partial input
            int lastIndex = searchString.Length - 1;

            // Find the next non-space character after the last character in the partial input
            int index = lastIndex + 1;

            if (index >= city.Length)
            {
                return string.Empty;
            }

            // Get the next letter
            char nextLetter = char.ToUpper(city[index]);

            return nextLetter.ToString();
        }
    }
}