using ConsoleSharpTemplate;
using ConsoleSharpTemplate.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

var services = new ServiceCollection();

// Add logging
services.AddLogging(builder => builder.AddConsole());

// Add configuration
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
services.AddSingleton<IConfiguration>(configuration);

var appSettings = configuration.GetSection("App").Get<AppSettings>() ?? throw new ArgumentException("Can not load app settings data.");
services.AddSingleton(appSettings);

// Add application services
services.AddTransient<ExampleService>();

// -----------------------------------------------------------------
await using var serviceProvider = services.BuildServiceProvider();

var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application Starting...");

try {
    var exampleService = serviceProvider.GetRequiredService<ExampleService>();
    await exampleService.Run();
}
catch (Exception ex) {
    logger.LogError(ex, "An error occurred.");
}