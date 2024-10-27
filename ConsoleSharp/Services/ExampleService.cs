using Microsoft.Extensions.Logging;

namespace ConsoleSharpTemplate.Services;

public class ExampleService(ILogger<ExampleService> logger) {
    public async Task Run() {
        logger.LogInformation("ExampleService is running.");
        await Task.Delay(1000); // Simulate some work
        logger.LogInformation("ExampleService completed.");
    }
}