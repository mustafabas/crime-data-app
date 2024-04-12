using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


new WebHostBuilder()
          .UseKestrel()
          .UseContentRoot(Directory.GetCurrentDirectory())
          .ConfigureAppConfiguration((hostingContext, config) =>
          {
              config
                  .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                  .AddJsonFile("appsettings.json", true, true)
                  .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                  .AddJsonFile("ocelot.json")
                  .AddEnvironmentVariables();
          })
          .ConfigureServices(s =>
          {
              s.AddOcelot();
              s.AddCors(options =>
              {
                  options.AddPolicy("AllowOrigin",
                       builder =>
                       {
                           builder.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader();
                       });
              });
          })
          .ConfigureLogging((hostingContext, logging) =>
          {
              logging.ClearProviders();
              logging.SetMinimumLevel(LogLevel.Information);
              logging.AddConsole(); // MS Console for Development and/or Testing environments only
          })
          .UseIISIntegration()
          .Configure(app =>
          {
              app.UseOcelot().Wait();
              app.UseCors("AllowOrigin");
          })
          .Build()
          .Run();


