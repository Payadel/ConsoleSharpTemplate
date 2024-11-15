using ConsoleSharpTemplate.Settings;
using Microsoft.Extensions.Logging;

namespace ConsoleSharpTemplate;

public class App(ILogger<App> logger, AppSettings settings) {
    public async Task RunAsync() {
        EnsureInputsAreValid();
        logger.LogDebug("{SettingData}", settings.ToString());

        logger.LogInformation("App is running. Delay: {delay}", settings.Delay);

        // Simulate some work
        await Task.Delay(settings.Delay);

        logger.LogInformation("App completed.");
    }

    private void EnsureInputsAreValid() {
        if (settings.Delay < 0)
            throw new ArgumentException($"{nameof(settings.Delay)} can not less that 0.");
    }
}