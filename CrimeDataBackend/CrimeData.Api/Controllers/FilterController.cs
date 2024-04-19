using CrimeData.Services.Services;
using CrimeData.Services.Services.Models.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrimeData.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly ICityService _cityService;

        public FilterController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<FilterResponse> Get()
        {
            var cityItems = await _cityService.GetCityItemResponses();
            FilterResponse response = new FilterResponse();

            foreach (var cityItem in cityItems) {
                response.Cities.Add(cityItem);
            }

            return response;
        }
    }
}
