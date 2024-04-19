using CrimeData.Services.Services.Strategy;
using CrimeData.Services.Services;
using System.Collections.Generic;

namespace CrimeData.Scheduler;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly HttpClient _httpClient;
    private readonly ILogger<SeattleDataProcesser> _loggerSeattle;
    private readonly IServiceScopeFactory scopeFactory;

    public Worker(ILogger<Worker> logger, IHttpClientFactory httpClientFactory, ILogger<SeattleDataProcesser> loggerSeattle,
        IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient();
        _loggerSeattle = loggerSeattle;
        scopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
    
            var taskList=new List<Task>();
            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                ICrimeService crimeService =
    scope.ServiceProvider.GetRequiredService<ICrimeService>();

                IDataProcessStrategy<List<SeattleCrimeDataResponse>> seatleDataProcces = new SeattleDataProcesser(_loggerSeattle, _httpClient, crimeService);
                //IDataProcessStrategy london = new LondonDataProcesser
                await seatleDataProcces.FetchAndSaveData();
            }
         

            await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
        }
    }
}
