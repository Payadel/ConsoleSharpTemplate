using ConsoleSharp.Settings;

namespace TestConsoleSharp.Settings;

using Xunit;

public class AppSettingsTests {
    [Fact]
    public void ToString_ShouldIncludePublicProperties_WithoutSecureConfig() {
        // Arrange
        var appSettings = new AppSettings {
            Delay = 10,
            SampleFile = "/path/to/secure-file"
        };

        // Act
        var result = appSettings.ToString();

        // Assert
        Assert.Contains($"Delay: {appSettings.Delay}", result);

        // Ensure the SecureConfig property is excluded
        Assert.DoesNotContain($"SampleFile: {appSettings.SampleFile}", result);
    }
}