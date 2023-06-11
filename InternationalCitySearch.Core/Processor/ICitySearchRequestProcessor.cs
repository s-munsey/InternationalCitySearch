using CitySearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalCitySearch.Core.Processor
{
    public interface ICitySearchRequestProcessor
    {
        ICityResult Search(string searchString);
    }
}
