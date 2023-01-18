using Microsoft.EntityFrameworkCore;
using Serilog;
using WebLangCreator;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true,
                       reloadOnChange: true);
    config.AddEnvironmentVariables();
});

builder.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
});
//access builder configuration

builder.ConfigureServices((hostContext, services) =>
{
    var connectionString = hostContext.Configuration.GetConnectionString("MyDbConnection");
    services.AddDbContextFactory<SportifierDB>(options =>
                                                   options
                                                       .UseSqlServer(connectionString,
                                                                     sqlServerOptions =>
                                                                         sqlServerOptions
                                                                             .CommandTimeout(120)));
});
var app = builder.ConfigureServices(services => { services.AddHostedService<Worker>(); })
                 .Build();

app.Run();