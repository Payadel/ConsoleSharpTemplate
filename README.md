# ConsoleSharpTemplate

ConsoleSharpTemplate is a C# .NET 9 console application template that demonstrates a clean, modular, and scalable approach for creating CLI applications. This project integrates Docker, Entity Framework for database handling, configuration management, and command-line parsing using `System.CommandLine`. Additionally, it includes scripts for building, packaging, and publishing NuGet packages, as well as CI/CD workflows with GitHub Actions.


## Project Structure

```
.
├── ConsoleSharp
│   ├── App.cs
│   ├── appsettings.json
│   ├── CommandLine.cs
│   ├── ConsoleSharp.csproj
│   ├── Data
│   │   └── AppDbContext.cs
│   ├── Helpers
│   │   └── TryHelpers.cs
│   ├── Program.cs
│   └── Settings
│   │   ├── AppSettings.cs
│   │   └── SecureConfigAttribute.cs
├── ConsoleSharp.sln
├── docker-compose.yml
├── Dockerfile
├── .dockerignore
├── .editorconfig
├── .github
│   ├── dependabot.yml
│   └── workflows
│       ├── codeql.yml
│       ├── dotnet.yml
│       ├── pr-coverage.yml
│       └── release-please.yml
├── .gitignore
├── scripts
│   ├── pack.sh
│   ├── publish.sh
│   └── run.sh
└── TestConsoleSharp
    ├── AppTests.cs
    ├── CommandLineTests.cs
    ├── Helpers
    │   └── TryHelpersTests.cs
    └── Settings
        └── AppSettingsTests.cs
```

## Features

- **Docker Support**: The project is Dockerized with a `Dockerfile` and a `docker-compose.yml` file for easy containerization.
- **Code Formatting**: An `.editorconfig` file is included to ensure consistent code formatting across the project.
- **Database Integration**: Uses Entity Framework Core with SQLite for data persistence.
- **Command-Line Parsing**: Utilizes `System.CommandLine` for flexible and robust CLI argument parsing.
- **CI/CD**: GitHub Actions workflows for continuous integration and deployment, including coverage reports, code analysis, and release automation.
- **NuGet Packaging**: Scripts for building and publishing the project as a NuGet package.
- **Testing**: Includes unit tests to ensure reliability.

## Prerequisites

To use and run this project, you'll need the following tools installed:

- .NET 9 SDK
- Docker (for containerization)
- Git (for version control)

## Getting Started

### Install with Nuget

```
dotnet new -i ConsoleSharp
```

### Clone the Repository

```bash
git clone https://github.com/Payadel/ConsoleSharpTemplate.git
cd ConsoleSharpTemplate
```

### Running the Project Locally

The project includes a script for running the application locally:

```bash
./scripts/run.sh
```

This will execute the project with the settings provided in `appsettings.json` and log output to the console.

### Building and Publishing the NuGet Package

To build and pack the application as a NuGet package, use the following script:

```bash
./scripts/pack.sh -h
```

To publish the NuGet package, use:

```bash
./scripts/publish.sh -h
```

### Customizing Configuration

The application settings are managed via `appsettings.json`. The relevant sections can be modified to customize the behavior of the application. For instance, you can update the delay, output paths, or file paths through this configuration file.

### Running Tests

The project includes unit tests, which can be run with the following command:

```bash
dotnet test TestConsoleSharp
```

This will execute the test suite to ensure everything is working as expected.

## GitHub Actions

The project is set up with GitHub Actions for CI/CD. The following workflows are defined:

- **CodeQL Analysis**: Static code analysis to identify vulnerabilities.
- **.NET Build and Test**: Automatically builds and tests the project on each push.
- **PR Coverage**: Generates code coverage reports for pull requests.
- **Release Automation**: Automatically handles versioning and package releases using `release-please`.

You can view the CI/CD process on the GitHub Actions tab of the repository.

## Code Structure

### `Program.cs`

The entry point of the application sets up dependency injection, configuration, logging, and database context. It also handles running the command-line parser and invoking the application logic.

### `CommandLine.cs`

This class is responsible for defining and parsing command-line arguments using `System.CommandLine`. It provides options for configuring delay, output paths, and file paths. Validators ensure the provided values are correct.

### `App.cs`

Contains the core logic for the application. It validates the input and simulates some work with a delay based on user settings.

### `AppSettings.cs`

Contains the configuration settings for the application, including delay, output path, and sample file path. It also handles secure configurations, such as the `SampleFile`.

### `TestConsoleSharp`

The test project for the console application. It includes unit tests for `App`, `CommandLine`, and other components.


## License

This project is licensed under the **GPLv3**.

See [LICENSE](LICENSE) for more information.