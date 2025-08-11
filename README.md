# ACE.Mods.Metrics

A Prometheus based metrics exporter for ACEmulator servers

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
