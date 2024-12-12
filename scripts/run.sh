#!/bin/bash

# Default Docker image name
DOCKER_NAME="${1:-console-sharp}"

# Function to display usage
usage() {
    echo "Usage: $(basename "$0") [docker_image_name]"
    echo "Runs a Docker Compose setup with the specified image name (default: console-sharp)."
    exit 1
}

# Clear the screen
clear

# Check if Docker is installed
if ! command -v docker &> /dev/null; then
    echo "Error: Docker is not installed. Please install Docker and try again."
    exit 1
fi

# Confirm removal of the Docker image
read -p "Are you sure you want to remove the Docker image '$DOCKER_NAME'? (y/N): " CONFIRMATION
CONFIRMATION="${CONFIRMATION,,}" # Convert to lowercase
if [[ "$CONFIRMATION" != "y" ]]; then
    echo "Aborted by user."
    exit 0
fi

# Remove the specified Docker image (forcefully)
echo "Removing Docker image '$DOCKER_NAME'..."
docker rmi "$DOCKER_NAME" -f
if [[ $? -ne 0 ]]; then
    echo "Error: Failed to remove Docker image '$DOCKER_NAME'."
    exit 1
fi

# Run Docker Compose
echo "Starting Docker Compose..."
docker compose up --abort-on-container-exit

# Check the status of the previous command
if [[ $? -eq 0 ]]; then
    echo "Docker Compose ran successfully."
else
    echo "Error: Docker Compose encountered an issue."
    exit 1
fi
