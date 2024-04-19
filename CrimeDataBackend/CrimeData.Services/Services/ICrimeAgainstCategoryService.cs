using CrimeData.Entities;
using CrimeData.Services.Services.Models.Response;

namespace CrimeData.Services.Services
{
    public interface ICityService
    {
        Task<City> InsertCityAsync(City city);
        Task<City?> GetCityByIdAsync(int cityId);
        Task<City?> GetCityByNameAsync(string cityName);
        Task<List<City>> GetCities();

        Task<List<FilterItemResponse>> GetCityItemResponses();
    }
}
