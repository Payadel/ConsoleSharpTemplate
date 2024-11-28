namespace ConsoleSharpTemplate.Helpers;

public static class TryHelpers {
    /// <summary>
    /// Executes the specified action and returns any exception as a string, or <c>null</c> if no exception occurs.
    /// </summary>
    /// <param name="action">The action to execute.</param>
    /// <returns>A string representation of the exception if an error occurs, or <c>null</c> if the action executes successfully.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="action"/> parameter is <c>null</c>.</exception>
    public static string? Try(this Action action) {
        ArgumentNullException.ThrowIfNull(action); // Ensure action is not null.

        try {
            action(); // Execute the action.
            return null; // Return null if the action succeeds.
        }
        catch (Exception e) {
            return e.ToString(); // Return the exception as a string if an error occurs.
        }
    }
}