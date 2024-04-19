using CrimeData.Data;
using CrimeData.Scheduler;
using CrimeData.Services.Services;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddHttpClient();
var databaseConnection = builder.Configuration.GetConnectionString("CrimeDataConnection");

builder.Services.AddDbContext<CrimeDataContext>(options =>
options.UseSqlServer(databaseConnection, b => b.MigrationsAssembly("CrimeData.Api")));


builder.Services.AddScoped<IDbContext, CrimeDataContext>();

builder.Services.AddScoped<ICrimeService, CrimeService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IParentGroupService, ParentGroupService>();
builder.Services.AddScoped<ICrimeAgainstCategoryService, CrimeAgainstCategoryService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));



var host = builder.Build();
host.Run();
