using System.IO.Abstractions;
using ConsoleSharp;
using ConsoleSharp.Data;
using ConsoleSharp.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

var services = new ServiceCollection();

// Add configuration
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
services.AddSingleton<IConfiguration>(configuration);

// Add logging using configuration
services.AddLogging(builder => {
    builder.AddConfiguration(configuration.GetSection("Logging")); // Bind to "Logging" section
    builder.AddConsole();
});

var appSettings = configuration.GetSection("App")
    .Get<AppSettings>() ?? throw new ArgumentException("Can not load app settings data.");
services.AddSingleton(appSettings);

services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("Default")));

// Parse inputs and update the appSettings
await CommandLine.InvokeAsync(args, appSettings, new FileSystem());

// Add application services
services.AddTransient<App>();

// -----------------------------------------------------------------
await using var serviceProvider = services.BuildServiceProvider();

var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application Starting...");

// Ensure the database is created
var db = serviceProvider.GetRequiredService<AppDbContext>();
await db.Database.EnsureCreatedAsync();

try {
    var exampleService = serviceProvider.GetRequiredService<App>();
    await exampleService.RunAsync();
}
catch (Exception ex) {
    logger.LogError(ex, "An error occurred.");
}