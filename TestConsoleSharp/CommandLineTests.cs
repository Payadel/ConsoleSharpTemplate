using System.IO.Abstractions.TestingHelpers;
using ConsoleSharp;
using ConsoleSharp.Settings;

namespace TestConsoleSharp;

public class CommandLineTests {
    private readonly AppSettings _settings = new();
    private readonly MockFileSystem _fileSystem = new();
    private const string ExistFileName = "file.txt";
    private const string ExistDirectory = "outputs";

    public CommandLineTests() {
        _fileSystem.AddFile(ExistFileName, string.Empty);
        _fileSystem.AddDirectory(ExistDirectory);
    }

    [Theory]
    [InlineData("-f", "-o", "-d", 10)]
    [InlineData("--file", "--output", "--delay", 10)]
    public async Task InvokeAsync_WithValidInputs_ReturnsSuccessCode(string fileFlag, string outputFlag,
        string delayFlag, int delay) {
        // Arrange
        var args = new[] { fileFlag, ExistFileName, outputFlag, ExistDirectory, delayFlag, delay.ToString() };

        // Act
        var result = await CommandLine.InvokeAsync(args, _settings, _fileSystem);

        // Assert
        Assert.Equal(0, result); // Assuming success returns 0
        Assert.Equal(delay, _settings.Delay);
        Assert.Equal(ExistFileName, _settings.SampleFile);
    }

    [Fact]
    public async Task InvokeAsync_MissingFile_ReturnsError() {
        // Arrange
        const int delay = 10;
        var args = new[] { "-f", string.Empty, "-d", delay.ToString() };

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

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    public async Task InvokeAsync_InvalidOutputPath_ReturnsError(string output) {
        // Arrange
        const int delay = 10;
        var args = new[] { "-f", ExistFileName, "-o", output, "-d", delay.ToString() };

        // Act
        var result = await CommandLine.InvokeAsync(args, _settings, _fileSystem);

        // Assert
        Assert.NotEqual(0, result); // Non-zero for error
    }

    [Fact]
    public async Task InvokeAsync_OutputPathAlreadyExistsAsFile_ReturnsError() {
        // Arrange
        const int delay = 10;
        var args = new[] { "-f", ExistFileName, "-o", ExistFileName, "-d", delay.ToString() };

        // Act
        var result = await CommandLine.InvokeAsync(args, _settings, _fileSystem);

        // Assert
        Assert.NotEqual(0, result); // Non-zero for error
    }
}