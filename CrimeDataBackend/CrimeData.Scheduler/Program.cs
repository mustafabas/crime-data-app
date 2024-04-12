using CrimeData.Data;
using CrimeData.Scheduler;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
var databaseConnection = builder.Configuration.GetConnectionString("CrimeDataConnection");

builder.Services.AddDbContext<CrimeDataContext>(options =>
options.UseSqlServer(databaseConnection));


builder.Services.AddScoped<IDbContext, CrimeDataContext>();
//builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

var host = builder.Build();
host.Run();
