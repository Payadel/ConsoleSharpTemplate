using System.CommandLine;
using System.IO.Abstractions;
using ConsoleSharp.Helpers;
using ConsoleSharp.Settings;

namespace ConsoleSharp;

public static class CommandLine {
    public static Task<int> InvokeAsync(string[] args, AppSettings settings, IFileSystem fileSystem) {
        var delayOption = new Option<int>(
            ["-d", "--delay"],
            () => settings.Delay,
            "An example number input"
        );
        delayOption.AddValidator(result => {
            if (result.GetValueOrDefault<int>() < 0)
                result.ErrorMessage = "The delay value can not less than 0";
        });

        var outputOption = new Option<string>(
            ["-o", "--output"],
            () => settings.Output,
            "Output Path"
        );
        outputOption.AddValidator(result => {
            var value = result.GetValueOrDefault<string>();
            if (string.IsNullOrWhiteSpace(value))
                result.ErrorMessage = "The output value is required.";
            else if (File.Exists(value))
                result.ErrorMessage = "Output value is not valid.";
            else if (!fileSystem.Directory.Exists(value)) {
                var error = TryHelpers.Try(() => fileSystem.Directory.CreateDirectory(value));
                if (!string.IsNullOrWhiteSpace(error))
                    result.ErrorMessage = error;
            }
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
            else if (!fileSystem.File.Exists(value))
                result.ErrorMessage = "The file is not valid.";
        });

        var rootCommand = new RootCommand("My C# Console App with Command-Line Parsing") {
            delayOption,
            outputOption,
            fileOption
        };

        rootCommand.SetHandler((delay, output, file) => {
            settings.Delay = delay;
            settings.Output = output;
            settings.SampleFile = file;
        }, delayOption, outputOption, fileOption);

        // Invoke the command
        return rootCommand.InvokeAsync(args);
    }
}