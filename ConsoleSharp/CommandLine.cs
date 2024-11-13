using System.CommandLine;
using ConsoleSharpTemplate.Helpers.FileService;

namespace ConsoleSharpTemplate;

public static class CommandLine {
    public static Task<int> InvokeAsync(string[] args, AppSettings settings, IFileService fileService) {
        var delayOption = new Option<int>(
            ["-d", "--delay"],
            () => settings.Delay,
            "An example number input"
        );
        delayOption.AddValidator(result => {
            if (result.GetValueOrDefault<int>() < 0)
                result.ErrorMessage = "The delay value can not less than 0";
        });

        var fileOption = new Option<string>(
            ["-f", "--file"],
            () => settings.SampleFile,
            "File path"
        );
        fileOption.AddValidator(result => {
            var value = result.GetValueOrDefault<string>();
            if (string.IsNullOrWhiteSpace(value))
                result.ErrorMessage = "The file is required.";
            else if (!fileService.Exists(value))
                result.ErrorMessage = "The file is not valid.";
        });

        var rootCommand = new RootCommand("My C# Console App with Command-Line Parsing") {
            delayOption,
            fileOption
        };

        rootCommand.SetHandler((delay, file) => {
            settings.Delay = delay;
            settings.SampleFile = file;
        }, delayOption, fileOption);

        // Invoke the command
        return rootCommand.InvokeAsync(args);
    }
}