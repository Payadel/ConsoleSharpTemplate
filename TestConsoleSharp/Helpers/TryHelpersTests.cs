using ConsoleSharp.Helpers;

namespace TestConsoleSharp.Helpers;

public class TryHelpersTests {
    [Fact]
    public void Try_WithNoException_ReturnsNull() {
        // Arrange
        Action noExceptionAction = () => {
            /* no exception */
        };

        // Act
        var result = noExceptionAction.Try();

        // Assert
        Assert.Null(result); // Should return null if no exception occurs.
    }

    [Fact]
    public void Try_WithException_ReturnsExceptionString() {
        // Arrange
        Action exceptionAction = () => throw new InvalidOperationException("Test exception");

        // Act
        var result = exceptionAction.Try();

        // Assert
        Assert.NotNull(result); // Result should not be null since an exception occurs.
        Assert.Contains("Test exception", result); // Exception message should be part of the result.
    }

    [Fact]
    public void Try_WithNullAction_ThrowsArgumentNullException() {
        // Arrange
        Action? nullAction = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => nullAction!.Try()); // Should throw ArgumentNullException.
    }
}