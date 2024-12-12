#!/bin/bash

# Exit immediately if a command exits with a non-zero status.
set -e

# Function to show usage
usage() {
  echo "Usage: $(basename "$0") [-p <project_path>] [-o <output_path>] [-c <configuration>] [-v <version>]"
  echo "  -p, --project       Path to the .NET CLI project (csproj file or project directory) (default: current directory)"
  echo "  -o, --output        Path to the output directory for the packed NuGet package (default: .NET default)"
  echo "  -c, --configuration Build configuration (default: Release)"
  echo "  -v, --version       Set the version for the package"
  exit 1
}

# Default values
PROJECT_PATH="$(pwd)"
CONFIGURATION="Release"
OUTPUT_PATH=""
VERSION=""

# Parse arguments
while [[ $# -gt 0 ]]; do
  case $1 in
    -p|--project)
      PROJECT_PATH="$2"
      shift 2
      ;;
    -o|--output)
      OUTPUT_PATH="$2"
      shift 2
      ;;
    -c|--configuration)
      CONFIGURATION="$2"
      shift 2
      ;;
    -v|--version)
      VERSION="$2"
      shift 2
      ;;
    *)
      usage
      ;;
  esac
done

# Ensure dotnet is installed
if ! command -v dotnet &> /dev/null; then
  echo "Error: .NET SDK is not installed."
  exit 1
fi

# Build the pack command
echo "Packing the project..."
PACK_COMMAND=(dotnet pack "$PROJECT_PATH" --configuration "$CONFIGURATION")

if [[ -n "$OUTPUT_PATH" ]]; then
  PACK_COMMAND+=(--output "$OUTPUT_PATH")
fi

if [[ -n "$VERSION" ]]; then
  PACK_COMMAND+=(/p:PackageVersion="$VERSION")
fi

# Execute the pack command
"${PACK_COMMAND[@]}"

if [[ -z "$OUTPUT_PATH" ]]; then
  echo "NuGet package created in the default .NET output directory."
else
  echo "NuGet package created in $OUTPUT_PATH"
fi