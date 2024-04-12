using CrimeData.Services.Models;
using CrimeData.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrimeData.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CrimeController : ControllerBase
    {
        private readonly ICrimeService _crimeService;

        public CrimeController(ICrimeService crimeService)
        {
            _crimeService = crimeService;
        }

        [HttpGet(Name = "GetCrimes")]
        public CrimeResponse Get()
        {
            return _crimeService.GetAllCrimes();
        }
    }
}
