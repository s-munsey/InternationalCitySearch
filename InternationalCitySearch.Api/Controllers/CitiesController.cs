using CitySearch;
using InternationalCitySearch.Core.Processor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InternationalCitySearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICitySearchRequestProcessor _processor;
        private readonly IMemoryCache _memoryCache;

        public CitiesController(ICitySearchRequestProcessor processor, IMemoryCache memoryCache)
        {
            _processor = processor;
            _memoryCache = memoryCache; // or redis cache if shared
        }

        [HttpGet("{searchString}", Name = "Cities")]
        public ActionResult<ICityResult> CitySearch(string searchString)
        {
            // if(!_memoryCache.TryGetValue(searchString, out var result))...

            return Ok(_processor.Search(searchString));
        }
    }
}
