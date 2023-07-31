# Narod's FFXV (Final Fantasy 15) Screenshot Grabber

Narod's FFXV Screenshot Grabber is a utility which converts the .ss files output by the game, in to usable .jpg files.

[Find it on NexusMods](https://www.nexusmods.com/finalfantasy15/mods/237)

[Find it on NGServe](https://ngserve.games/mods/ffxv-ss-grabber.html)

## Background

In FFXV (Final Fantasy 15), Prompto (an in-game character) will take in-game photos of what your party has gotten up to. These are saved by the game in a format which a regular photoviewer does not support. This utility can convert these .ss files in to .jpg files for you.

## Overview

![alt text](img/no_preview.png "The Main Window with No Preview Selected (Image)")

## Requirements

- .NET 6.0

## Supported Systems

- Windows: 7, 8.1, 10, 11
- Linux: SteamOS (officially supported), other distros should also work, no guarantee

macOS is not officially supported, planned to be investigated further at Sonoma launch. Feel free to investigate beforehand and create a pull request! (Look at FolderDetector.cs)

## Features

- See a live preview of what the .ss file contains before exporting it
- Export a single photo, or an entire folders worth in one go
  - Compared to the most popular FFXV Screenshot Utility, this utility is incredibly fast
- Automatic detection of your screenshot folder, with the option to browse to a custom one
- Realtime mode, which can be activated to save a copy of the screenshots as they are taken in-game.
- Automatic version checker, you will be notified of future updates.

## Limitations

- Auto detection on Linux doesn't always work. The manual location you'll need is quite long, you're looking for the compatdata folder (might need to Google), from there: 637650/pfx/dosdevices/c:/users/steamuser/Documents/My Games/Final Fantasy XV/Steam - then a set of numbers, then savestorage/snapshot/
- SteamOS/Linux setup is complicated, instructions on Nexus: https://www.nexusmods.com/finalfantasy15/mods/237

## Helping Narod's FFXV Screenshot Grabber

This utility is fully open-source under GPLv3. Right now, we're looking for help with:

- Any issues/bugs found
- Improvements to features and functionality
- Better Linux/SteamOS support & setup
