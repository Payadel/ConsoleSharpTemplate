using System.CommandLine;

namespace ConsoleSharpTemplate;

public static class CommandLine {
    public static Task<int> InvokeAsync(string[] args, AppSettings settings) {
        var delayOption = new Option<int>(
            ["-d", "--delay"],
            () => settings.Delay,
            "An example number input"
        );

        var rootCommand = new RootCommand("My C# Console App with Command-Line Parsing") {
            delayOption
        };

        rootCommand.SetHandler(delay => { settings.Delay = delay; }, delayOption);

        // Invoke the command
        return rootCommand.InvokeAsync(args);
    }
}