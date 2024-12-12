using ConsoleSharp;
using ConsoleSharp.Settings;
using Microsoft.Extensions.Logging;
using Moq;

namespace TestConsoleSharp;

public class AppTests {
    [Fact]
    public async Task Run_LogsExpectedMessages() {
        // Arrange
        var mockLogger = new Mock<ILogger<App>>();
        var appSettings = new AppSettings {
            Delay = 0
        };

        var service = new App(mockLogger.Object, appSettings);

        // Act
        await service.RunAsync();

        // Assert
        mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString() == $"App is running. Delay: {appSettings.Delay}"),
                It.IsAny<Exception>(),
                ((Func<It.IsAnyType, Exception, string>)It.IsAny<object>())!),
            Times.Once);

        mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString() == "App completed."),
                It.IsAny<Exception>(),
                ((Func<It.IsAnyType, Exception, string>)It.IsAny<object>())!),
            Times.Once);
    }

    [Fact]
    public async Task Run_GiveInvalidInput_ThrowsArgumentException() {
        var mockLogger = new Mock<ILogger<App>>();
        var appSettings = new AppSettings {
            Delay = -10
        };
        var service = new App(mockLogger.Object, appSettings);

        await Assert.ThrowsAsync<ArgumentException>(() => service.RunAsync());
    }
}