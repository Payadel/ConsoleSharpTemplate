#!/bin/bash

# Exit immediately if a command exits with a non-zero status.
set -e

# Function to show usage
usage() {
  echo "Usage: $(basename "$0") -p <package_path> -k <api_key> [-s <source>]"
  echo "  -p, --package       Path to the NuGet package (.nupkg file)"
  echo "  -k, --api-key       API key for the NuGet server"
  echo "  -s, --source        URL of the NuGet server (default: https://api.nuget.org/v3/index.json)"
  exit 1
}

# Default values
NUGET_SOURCE="https://api.nuget.org/v3/index.json"

# Parse arguments
while [[ $# -gt 0 ]]; do
  case $1 in
    -p|--package)
      PACKAGE_PATH="$2"
      shift 2
      ;;
    -k|--api-key)
      API_KEY="$2"
      shift 2
      ;;
    -s|--source)
      NUGET_SOURCE="$2"
      shift 2
      ;;
    *)
      usage
      ;;
  esac
done

# Ensure required arguments are provided
if [[ -z "$PACKAGE_PATH" || -z "$API_KEY" ]]; then
  usage
fi

# Ensure dotnet is installed
if ! command -v dotnet &> /dev/null; then
  echo "Error: .NET SDK is not installed."
  exit 1
fi

# Publish the package
echo "Publishing the package to $NUGET_SOURCE..."
dotnet nuget push "$PACKAGE_PATH" \
  --api-key "$API_KEY" \
  --source "$NUGET_SOURCE"

echo "Package published successfully."
