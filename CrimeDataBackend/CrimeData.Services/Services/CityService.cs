using CrimeData.Data;
using CrimeData.Entities;
using CrimeData.Services.Services.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace CrimeData.Services.Services
{
    public class CityService : ICityService
    {
        IAsyncRepository<City> _cityRepository;

        public CityService(IAsyncRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<City>> GetCities()
        {
            var cities = await _cityRepository.ListAllAsync();
            return cities.ToList();
        }

        public async Task<City?> GetCityByIdAsync(int cityId)
        {
            if (cityId == 0) throw new Exception("cityId cannot bu null");
            var query = await _cityRepository.GetByIdAsync(cityId);
            return query;
        }

        public async Task<City?> GetCityByNameAsync(string cityName)
        {
            var query = _cityRepository.Table;
            var city = await query.FirstOrDefaultAsync(x => x.Name == cityName);
            return city;
        }

        public async Task<List<FilterItemResponse>> GetCityItemResponses()
        {
            var cities = await this.GetCities();
            var citiesResponse = new List<FilterItemResponse>();
            foreach (var city in cities)
            {
                citiesResponse.Add(new FilterItemResponse { Id = city.Id, Text = city.Name });
            }
            return citiesResponse;
        }

        public async Task<City> InsertCityAsync(City city)
        {
            if (city == null) throw new Exception("city cannot bu null");

            city.CredatedAt = DateTime.Now;
            return await _cityRepository.AddAsync(city);
        }

    }
}
