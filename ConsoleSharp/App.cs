using Microsoft.Extensions.Logging;

namespace ConsoleSharpTemplate;

public class App(ILogger<App> logger, AppSettings settings) {
    public async Task Run() {
        logger.LogInformation("App is running. Delay: {delay}", settings.Delay);

        // Simulate some work
        await Task.Delay(settings.Delay);

        logger.LogInformation("App completed.");
    }
}