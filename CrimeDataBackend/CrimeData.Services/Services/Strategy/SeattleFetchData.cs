using CrimeData.Services.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CrimeData.Services.Services.Strategy
{
    public class SeattleDataProcesser : IDataProcessStrategy<List<SeattleCrimeDataResponse>>
    {
        private readonly ILogger<SeattleDataProcesser> _logger;
        private readonly HttpClient _httpClient;
        private readonly ICrimeService _crimeService;


        public SeattleDataProcesser(ILogger<SeattleDataProcesser> logger, HttpClient httpClient,
            ICrimeService crimeService)
        {
            _logger = logger;
            _httpClient = httpClient;
            _crimeService = crimeService;
        }

        public async Task<bool> FetchAndSaveData()
        {
            var url = "https://data.seattle.gov/resource/tazs-3rd5.json?$limit=1000&$offset={0}&$order=report_datetime%20ASC";
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            var currentTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);

            //if (currentTime.Hour == 0 && currentTime.Minute == 0)
            //{
            var latestCrime = await _crimeService.GetLatestCrimeDate();
            try
            {
                var continueFetch = true;
                int offset = 0;

                while (continueFetch)
                {
                    var requestUrl = string.Format(url, offset, latestCrime != null ? latestCrime.ReportDateTime : 0);
                    var response = await _httpClient.GetAsync(requestUrl);
                    var crimeDataList = new List<SeattleCrimeDataResponse>();
                    var requestTasks = new List<Task>();

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        var crimeData = JsonSerializer.Deserialize<List<SeattleCrimeDataResponse>>(content);
                        if (crimeData != null && crimeData.Count == 0)
                            break;
                        
                        _logger.LogInformation("Crime data fetched successfully. Inserting in database");
                        await _crimeService.InsertCrimes(this.Map(crimeData));
                        offset += 1000;
                    }
                    else
                    {
                        _logger.LogError($"Failed to fetch crime data. Status code: {response.StatusCode}");
                    }



                }
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching crime data.");
                return false;
            }

        }

        public List<InsertCrimeModel> Map(List<SeattleCrimeDataResponse> response)
        {

            var crineDataModal = response.Select(d => new InsertCrimeModel()
            {
                Beat = d.Beat,
                BlockAddress = d.BlockAddress,
                CrimeAgainstCategory = d.CrimeAgainstCategory,
                GroupAB = d.GroupAB,
                Latitude = d.Latitude,
                Longitude = d.Longitude,
                Mcpp = d.Mcpp,
                Offense = d.Offense,
                OffenseCode = d.OffenseCode,
                OffenseId = d.OffenseId,
                OffenseParentGroup = d.OffenseParentGroup,
                OffenseStartDateTime = d.OffenseStartDateTime,
                Precinct = d.Precinct,
                ReportDateTime = d.ReportDateTime,
                ReportNumber = d.ReportNumber,
                Sector = d.Sector
            }).ToList();

            return crineDataModal;
        }
    }
}
