using ConsoleSharpTemplate.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace TestConsoleSharp;

public class TestExampleService {
    [Fact]
    public async Task Run_LogsExpectedMessages() {
        // Arrange
        var mockLogger = new Mock<ILogger<ExampleService>>();

        var service = new ExampleService(mockLogger.Object);

        // Act
        await service.Run();

        // Assert
        mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString() == "ExampleService is running."),
                It.IsAny<Exception>(),
                ((Func<It.IsAnyType, Exception, string>)It.IsAny<object>())!),
            Times.Once);

        mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString() == "ExampleService completed."),
                It.IsAny<Exception>(),
                ((Func<It.IsAnyType, Exception, string>)It.IsAny<object>())!),
            Times.Once);
    }
}