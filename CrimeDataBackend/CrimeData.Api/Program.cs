using CrimeData.Data;
using CrimeData.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(options => {
    options.ReportApiVersions = true; 
    options.DefaultApiVersion = new ApiVersion(1, 0); 
    options.AssumeDefaultVersionWhenUnspecified = true; 
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});



var databaseConnection = builder.Configuration.GetConnectionString("CrimeDataConnection");

builder.Services.AddDbContext<CrimeDataContext>(options =>
options.UseSqlServer(databaseConnection, b=>b.MigrationsAssembly("CrimeData.Api")));


builder.Services.AddScoped<IDbContext, CrimeDataContext>();

builder.Services.AddScoped<ICrimeService, CrimeService>();
builder.Services.AddScoped<ICrimeAgainstCategoryService, CrimeAgainstCategoryService>();

builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IParentGroupService, ParentGroupService>();
builder.Services.AddScoped<ICrimeService, CrimeService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
         builder =>
         {
             builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
         });
});

// Configure the HTTP request pipeline.
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
