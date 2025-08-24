# ACE.Mods.Metrics

A Prometheus based metrics exporter for ACEmulator servers

[![Discord](https://img.shields.io/discord/261242462972936192.svg?label=play+now!&style=for-the-badge&logo=discord)](https://discord.gg/C2WzhP9)

[![License](https://img.shields.io/github/license/acemulator/ace.mods.metrics)](https://github.com/ACEmulator/ACE.Mods.Metrics/blob/main/LICENSE)[![GitHub last commit (main)](https://img.shields.io/github/last-commit/acemulator/ace.mods.metrics/main)](https://github.com/ACEmulator/ACE.Mods.Metrics/commits/main)[![Windows CI](https://ci.appveyor.com/api/projects/status/audksvlkdmhqusem/branch/main?svg=true)](https://ci.appveyor.com/project/LtRipley36706/ace-mods-metrics/branch/main)

[![Download Latest Release](https://img.shields.io/github/v/release/ACEmulator/ACE.Mods.Metrics?label=latest%20release)![GitHub Release Date](https://img.shields.io/github/release-date/acemulator/ace.mods.metrics)](https://github.com/ACEmulator/ACE.Mods.Metrics/releases/latest)

[![GitHub All Releases](https://img.shields.io/github/downloads/acemulator/ace.mods.metrics/total?label=mod%20downloads)](https://github.com/ACEmulator/ACE.Mods.Metrics/releases)

## Features

- **Real-time on-demand Metrics**: Allows your prometheus server to collect metrics output from ACEmulator

## Installation

1. **Prerequisites**
   - .NET 8.0 runtime
   - [ACEmulator](https://github.com/ACEmulator/ACE) server installation, version 1.71.4694 or higher required
   - [Prometheus](https://prometheus.io/) server installation

2. **Installation Steps**
   - Download the latest release zip file from the releases page
   - Extract the zip file to your ACEmulator server's `Mods` directory
   - Ensure the extracted folder is named `ACE.Mods.Metrics`
   - Ensure the plugin is enabled in your ACEmulator server configuration
   - Restart your ACEmulator server or reload mods using `/mod f` command from console or in-game.


## Sample Dashboard

Located in `grafana\provisioning\dashboards` you will find `ACE_NET_runtime_metrics_dashboard.json` which is a sample dashboard for use with this mod.

Additionally, this repo has a docker compose stack found at `docker-compose.yml` to easily demo the plugin and dashboard.

To use the demo:
1. Clone this repo to easily download all needed files.
2. Initialize the docker stack with the following command: `docker compose run --rm ace-init`
   - This will download Dats and Mods for the server to use and place them in the correct locations
   - You can choose to do this manually by
     - Placing your DAT files in a directory called `Dats`
     - Any Mods, including this one, in to the `Mods` directory using a subfolder for each mod, seperately.
3. Start the docker stack with the following command: `docker compose up -d`
    - This will download, create required directories, auto configure, and start the following services:
      - ace-db
        - `mysql:8.0` configured to use `mysql-data` as its data directory
        - You can change some defaults found in the `docker.env` file
      - ace-prometheus
        - `prom/prometheus:latest` configured to use `prometheus-data` as its data directory and its configuration at `prometheus`
        - Accessible at http://localhost:9090/
      - ace-grafana
        - `grafana/grafana-enterprise:latest` configured to use `grafana-data` as its data directory and its configuration at `grafana/provisioning`
        - Accessible at http://localhost:3000/ and the dashboard located at http://localhost:3000/d/RHbwEa8mzACE3/ace-net-runtime-metrics
      - ace-server
        - `acemulator/ace:latest` configured to use `Config`, `Content`, `Dats`, `Logs` and `Mods` for data and configuration.
        - You can change some defaults found in the `docker.env` file
        - The server will download and install the latest database on first start up, and will be set to make the first account connected an Admin.
       
4. To stop the docker stack, use the following command: `docker compose down`

## Configuration

Edit `Settings.json` to customize the plugin behavior:

```json
{
  "Host": "127.0.0.1",
  "Port": 9200,
  "Url": "metrics/",
  "UseHTTPs": false
}
```

### Configuration Options

You can change these options below, but we do recommend the defaults be left as-is and instead use a reverse proxy to securely expose the metrics data

- **Host**: IP Address to bind listener to (default: "127.0.0.1")
- **Port**: Port to bind listener to (default: 9200)
- **Url**: Base path that metrics are published to (default: "metrics/")
- **UseHTTPs**: Use SSL on metrics server (default: false)

## Troubleshooting

**Plugin not loading:**
- Check that the plugin is in the correct Mods directory
- Verify .NET 8.0 is installed
- Check server logs for error messages

**Settings not loading:**
- Ensure Settings.json is properly formatted
- Check for JSON syntax errors
- Verify file permissions

## Dependencies

- .NET 8.0 Runtime
- [ACEmulator](https://github.com/ACEmulator/ACE) Server (with mod support)
- Lib.Harmony bundled with ACEmulator (for patching)
- ACE.Shared library bundled with this plugin
- Prometheus libraries bundled with this plugin
