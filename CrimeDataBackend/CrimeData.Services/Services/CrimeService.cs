
using CrimeData.Data;
using CrimeData.Entities;
using CrimeData.Entities.Tables;
using CrimeData.Services.Models;
using CrimeData.Services.Services.Models;
using CrimeData.Services.Services.Strategy;
using System.Linq.Expressions;
using System;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CrimeData.Services.Services
{
    public class CrimeService : ICrimeService
    {
        private readonly IAsyncRepository<Crime> _repository;
        private readonly ICityService _cityService;
        private readonly IParentGroupService _parentGroupService;
        private readonly ICrimeAgainstCategoryService _crimeAgainstCategoryService;

        public CrimeService(IAsyncRepository<Crime> repository, ICityService cityService, IParentGroupService parentGroupService,
           ICrimeAgainstCategoryService crimeAgainstCategoryService)
        {
            _repository = repository;
            _cityService = cityService;
            _parentGroupService = parentGroupService;
            _crimeAgainstCategoryService = crimeAgainstCategoryService;
        }

        public CrimeResponse GetAllCrimes()
        {
            var crimeData = new List<CrimeItemResponse>();
            crimeData.Add(new CrimeItemResponse("USA", "Theft", "PROPERTY", 122.21313f, 1.23131f));
            crimeData.Add(new CrimeItemResponse("USA", "Crisis", "PROPERTY", 122.21313f, 1.23131f));
            crimeData.Add(new CrimeItemResponse("USA", "abv", "PROPERTY", 122.21313f, 1.23131f));
            crimeData.Add(new CrimeItemResponse("USA", "asdad", "PROPERTY", 122.21313f, 1.23131f));
            var crimeResponse = new CrimeResponse(crimeData);
            return crimeResponse;
        }

        public async Task<Crime?> GetLatestCrimeDate()
        {
            var query = _repository.Table;
            var crime = await query.OrderBy(x => x.Id).LastOrDefaultAsync();
            return crime;
        }

        public async Task<List<Crime>> InsertCrimes(List<InsertCrimeModel> seattleCrimes)
        {
            var cities = await _cityService.GetCities();
            var parentGroups = await _parentGroupService.GetAllParentGroupsAsync();
            var crimeAgainsts = await _crimeAgainstCategoryService.GetCrimeAgainstCategoriesAsync();
            var crimeEntityList = new List<Crime>();
            foreach (var item in seattleCrimes)
            {
                var city = cities.FirstOrDefault(x => x.Name == item.Mcpp);
                if (city == null)
                {
                    var cityNew = new City();
                    cityNew.Name = item.Mcpp;
                    cityNew.ApiSourceId = 1;
                    await _cityService.InsertCityAsync(cityNew);
                    city = cityNew;
                    cities.Add(city);
                }
                var parentGroup = parentGroups.FirstOrDefault(x=>x.Name==item.OffenseParentGroup);
                if (parentGroup == null)
                {
                    var parentGroupNew = new ParentGroup();
                    parentGroupNew.Name = item.OffenseParentGroup;
                    parentGroupNew.ApiSourceId = 1;
                    parentGroupNew.Code = item.OffenseCode;
                    await _parentGroupService.InsertParentGroupAsync(parentGroupNew);
                    parentGroup = parentGroupNew;
                }


                var crimeAgainst = crimeAgainsts.FirstOrDefault(x=>x.Name==item.CrimeAgainstCategory);
                if (crimeAgainst == null)
                {
                    var crimeAgainstNew = new CrimeAgainstCategory();
                    crimeAgainstNew.Name = item.CrimeAgainstCategory;
                    crimeAgainstNew.ApiSourceId = 1;
                    await _crimeAgainstCategoryService.InsertCrimeAgainstCategoryAsync(crimeAgainstNew);
                    crimeAgainst = crimeAgainstNew;
                    crimeAgainsts.Add(crimeAgainst);
                }

                var crime = new Crime();
                crime.CityId = city.Id;
                crime.ParentGroupId = parentGroup.Id;
                crime.Address = item.BlockAddress;
                crime.CrimeAgainstCategoryId = crimeAgainst.Id;
                crime.ApiSourceId = 1;
                crime.ReportNumber = item.ReportNumber;
                crime.OffenseStartDatetime = item.OffenseStartDateTime;
                crime.ReportDateTime = item.ReportDateTime;
                crime.CredatedAt = DateTime.Now;
                crime.Longtitde = float.Parse(item.Longitude, CultureInfo.InvariantCulture.NumberFormat);
                crime.Latitude = float.Parse(item.Latitude, CultureInfo.InvariantCulture.NumberFormat);
                crime.Offense = item.Offense;
                crimeEntityList.Add(crime);
            }


       
            return await _repository.AddRangeAsync(crimeEntityList);
        }
    }
}
