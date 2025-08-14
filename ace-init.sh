#!/bin/bash

echo "Starting init for ace-metrics-demo..."

# download and extract dat files
megadl 'https://mega.nz/#!Q98n0BiR!p5IugPS8ZkQ7uX2A_LdN3Un2_wMX4gZBHowgs1Qomng'
7z x ac-updates.zip -o/ace/Dats *.dat -y
rm ac-updates.zip

# download and extract ACE.Mods.AntiCheat plugin
wget https://github.com/trevis/ACE.Mods.AntiCheat/releases/download/v1.7.0/ACE.Mods.AntiCheat-1.7.zip
7z x ACE.Mods.AntiCheat-1.7.zip -o/ace/Mods -y
rm ACE.Mods.AntiCheat-1.7.zip

# download and extract ACE.Mods.Metrics plugin
wget https://github.com/ACEmulator/ACE.Mods.Metrics/releases/latest/download/ACE.Mods.Metrics.zip
7z x ACE.Mods.Metrics.zip -o/ace/Mods/ACE.Mods.Metrics -y
rm ACE.Mods.Metrics.zip

# Change default Settings.json for ACE.Mods.Metrics plugin
cat << EOF > /ace/Mods/ACE.Mods.Metrics/Settings.json
{
  "Host": "ace-server",
  "Port": 9200,
  "Url": "metrics/",
  "UseHTTPs": false
}
EOF

echo "init complete."
