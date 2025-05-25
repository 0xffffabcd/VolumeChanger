# VolumeChanger

## Project Overview
VolumeChanger is a Windows Forms application designed to control and maintain a consistent microphone input volume level. It allows users to select a microphone, set a desired volume, and the application will automatically adjust the microphone's volume to the set level at regular intervals.

## Features
- **Microphone Selection**: Lists available input devices and allows the user to select one.
- **Volume Control**: Users can specify a target volume level for the selected microphone.
- **Automatic Volume Adjustment**: Periodically checks and adjusts the microphone volume to the desired level.
- **Adjustable Update Frequency**: Users can configure how often the volume is checked and adjusted.
- **Start with Windows**: Option to automatically start the application when Windows boots up.
- **System Tray Integration**: The application can be minimized to the system tray for unobtrusive operation.

## How to Use
1.  **Launch the application**: Run `VolumeChanger.exe`.
2.  **Select Microphone**: From the dropdown menu, choose the input device you want to manage.
3.  **Set Desired Volume**: Use the numeric up/down control to set your preferred volume level (0-100).
4.  **Set Update Frequency**: Adjust how often (in milliseconds) the application should check and correct the volume.
5.  **Enable/Disable**: Click the "Start/Stop Volume Adjustment" button to activate or deactivate the automatic volume control.
6.  **Start with Windows**: Check the "Start with Windows" option in the application settings or via the tray icon menu if you want VolumeChanger to launch automatically on system startup.
7.  **Minimize to Tray**: Closing the main window will minimize the application to the system tray. You can restore it or exit completely by right-clicking the tray icon.

## Dependencies
-   [.NET 8 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/8.0)
-   [NAudio](https://github.com/naudio/NAudio) (included via NuGet package)

## Building from Source
1.  Clone the repository.
2.  Open the solution file (`VolumeChanger.sln`) in Visual Studio.
3.  Ensure the .NET 8 SDK is installed.
4.  Build the solution. The executable will be located in the `bin\Debug` or `bin\Release` folder of the `VolumeChanger` project.

## Contributing
Contributions are welcome! If you have suggestions for improvements or bug fixes, please feel free to open an issue or submit a pull request.