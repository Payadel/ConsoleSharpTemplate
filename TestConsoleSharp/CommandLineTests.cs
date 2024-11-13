using ConsoleSharpTemplate;
using TestConsoleSharp.Mocks;

namespace TestConsoleSharp;

public class CommandLineTests {
    private readonly AppSettings _settings = new();
    private readonly MockFileService _fileSystem = new();

    [Fact]
    public async Task InvokeAsync_WithValidInputs_ReturnsSuccessCode() {
        // Arrange
        const int delay = 10;
        const string filePath = "exist-file.txt";
        var args = new[] { "-f", filePath, "-d", delay.ToString() };

        // Act
        var result = await CommandLine.InvokeAsync(args, _settings, _fileSystem);

        // Assert
        Assert.Equal(0, result); // Assuming success returns 0
        Assert.Equal(delay, _settings.Delay);
        Assert.Equal(filePath, _settings.SampleFile);
    }

    [Fact]
    public async Task InvokeAsync_MissingFile_ReturnsError() {
        // Arrange
        const int delay = 10;
        const string filePath = "";
        var args = new[] { "-f", filePath, "-d", delay.ToString() };

        // Act
        var result = await CommandLine.InvokeAsync(args, _settings, _fileSystem);

        // Assert
        Assert.NotEqual(0, result); // Assuming success returns 0
    }

    [Fact]
    public async Task InvokeAsync_InvalidFile_ReturnsError() {
        // Arrange
        const int delay = 10;
        const string filePath = "invalid-path";
        var args = new[] { "-f", filePath, "-d", delay.ToString() };

        // Act
        var result = await CommandLine.InvokeAsync(args, _settings, _fileSystem);

        // Assert
        Assert.NotEqual(0, result); // Assuming success returns 0
    }

    [Fact]
    public async Task InvokeAsync_InvalidDelay_ReturnsError() {
        // Arrange
        const int delay = -10;
        const string filePath = "exist-file.txt";
        var args = new[] { "-f", filePath, "-d", delay.ToString() };

        // Act
        var result = await CommandLine.InvokeAsync(args, _settings, _fileSystem);

        // Assert
        Assert.NotEqual(0, result); // Assuming success returns 0
    }
}