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
   - [ACEmulator](https://github.com/ACEmulator/ACE) server installation
   - [Prometheus](https://prometheus.io/) server installation

2. **Installation Steps**
   - Download the latest release zip file from the releases page
   - Extract the zip file to your ACEmulator server's `Mods` directory
   - Ensure the extracted folder is named `ACE.Mods.Metrics`
   - Ensure the plugin is enabled in your ACEmulator server configuration
   - Restart your ACEmulator server or reload mods using `/mod f` command from console or in-game.



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
