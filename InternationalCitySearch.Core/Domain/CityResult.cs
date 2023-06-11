using CitySearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalCitySearch.Core.Domain
{
    public class CityResult : ICityResult
    {
        public required ICollection<string> NextLetters { get; set; }
        public required ICollection<string> NextCities { get; set; }
    }
}
