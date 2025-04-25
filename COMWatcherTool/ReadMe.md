# Automated COM Registration Watcher

## Project Description

This project is a Windows Presentation Foundation (WPF) application designed to automatically register and unregister COM (Component Object Model) visible .NET DLLs based on file system changes in a designated folder. It runs as a background application with a system tray icon for control and configuration.

The primary goal is to simplify the process of keeping COM registrations up-to-date for DLLs that are frequently updated or deployed to a specific location.

## Key Features

* **System Tray Application:** Runs in the background without a main window visible by default.
* **Tray Icon Menu:** Provides a context menu via the system tray icon to control the application (Start/Stop Monitoring, Settings, Exit).
* **Configurable Watch Folder:** Allows the user to specify the folder to monitor for DLL changes via a settings window.
* **Automated Registration/Unregistration:** Automatically calls `RegAsm.exe` to register a DLL when a `.dll` file is created or renamed in the watched folder, and unregisters it when a `.dll` file is deleted or renamed (using the old path).
* **Basic Logging:** Logs application events and `RegAsm.exe` output/errors to a log file (`AppLog.txt`).

## Core Components

* **WPF Application:** Provides the framework for the desktop application.
* **Hardcodet.NotifyIcon.Wpf:** A third-party library used to easily create and manage the system tray icon and its context menu.
* **FileSystemWatcher:** A .NET class used to monitor a specified directory for changes (creation, deletion, renaming of files).
* **RegAsmHelper:** A custom static helper class responsible for finding the correct `RegAsm.exe` utility and executing it with the necessary arguments (`/tlb`, `/codebase`, `/unregister`).
* **MainWindow:** A WPF window used as the application's settings interface to configure the watch folder.
* **Application Settings (Properties.Settings.Default):** Used to persistently store user settings, such as the watch folder path.
* **AppLogger:** A custom static helper class for writing log messages to a file (`AppLog.txt`).

## How to Use

1.  **Build the Application:** Compile the WPF project in Visual Studio.
2.  **Run as Administrator:** The application must be run with administrator privileges for `RegAsm.exe` to successfully write to the system registry. Right-click the application executable (`.exe` file) and select "Run as administrator".
3.  **Configure the Watch Folder:**
    * Look for the application's icon in the Windows system tray (bottom-right corner).
    * Right-click the tray icon.
    * Select "Settings" from the context menu.
    * In the settings window, enter or browse for the folder path you want to monitor.
    * Click "Save".
4.  **Start Monitoring:**
    * Right-click the tray icon again.
    * Select "Start Monitoring" from the context menu.
    * A balloon tip should appear confirming that monitoring has started.
5.  **Test Automation:**
    * Copy a COM-visible .NET Framework DLL into the configured watch folder. The application should detect the file creation and attempt to register it.
    * Delete a DLL from the folder. The application should detect the deletion and attempt to unregister it.
    * Rename a DLL in the folder. The application should detect the rename and attempt to unregister the old path and register the new path.
6.  **Check Logs:** Open the `AppLog.txt` file located in the same directory as the application's executable to view the monitoring events and the output/errors from `RegAsm.exe`.
7.  **Stop Monitoring:** Right-click the tray icon and select "Stop Monitoring".
8.  **Exit Application:** Right-click the tray icon and select "Exit".

## Key Concepts Learned During Development

* **WPF Tray Applications:** How to create an application that runs primarily in the system tray using `Hardcodet.NotifyIcon.Wpf`.
* **Application Lifecycle:** Managing application startup (`OnStartup`), shutdown (`OnExit`), and preventing automatic shutdown when windows are closed (`ShutdownMode="OnExplicitShutdown"`).
* **TaskbarIcon and ContextMenu:** Defining the tray icon's appearance and the menu that appears on right-click in XAML, and linking menu item clicks to event handlers in code-behind.
* **FileSystemWatcher:** Setting up a watcher to monitor file system events (`Created`, `Deleted`, `Renamed`, `Error`), configuring filters, and subscribing to event handlers.
* **COM Interop in .NET:** Understanding the role of `RegAsm.exe` and the importance of `[ComVisible(true)]` and `[Guid(...)]` attributes for making .NET assemblies and classes visible to COM clients.
* **.NET Framework vs. Modern .NET COM Configuration:** Learning that COM visibility is configured differently in older `.csproj` files (`AssemblyInfo.cs` and project properties) compared to newer `.csproj` files (`<EnableComHosting>`, `<ComVisible>`, `<Guid>` properties).
* **RegAsm.exe Exit Codes:** Interpreting the exit codes from `RegAsm.exe` (e.g., `0` for success, `100` for assembly not found/invalid) to diagnose registration issues.
* **Cross-Runtime Compatibility:** Understanding that a `RegAsm.exe` from one .NET runtime (e.g., .NET Framework 4.x) cannot register a DLL built for a different runtime (e.g., .NET 8.0).
* **Dispatcher for UI Updates:** Using `Application.Current.Dispatcher.Invoke` to safely update UI elements (like showing tray balloon tips) from background threads triggered by the `FileSystemWatcher`.
* **Application Settings:** Using `Properties.Settings.Default` to save and load user-specific configuration data persistently.
* **Logging:** Implementing a basic static logging class to write informative messages for debugging and monitoring background application activity.

## Areas for Future Enhancement

* **Robust RegAsm.exe Location:** Improve the `FindRegAsmPath` logic to reliably locate the correct `RegAsm.exe` for different .NET versions and architectures installed on the system.
* **Enhanced Error Handling and Reporting:** Provide more detailed error messages to the user via tray balloon tips or a dedicated status window when `RegAsm.exe` fails or other issues occur. Implement better handling for file locking or permission errors.
* **Admin Privileges Check:** Add a check on startup to verify the application is running with necessary permissions.
* **Visual Status Indication:** Change the tray icon's appearance or tooltip to show the current monitoring status (e.g., monitoring active, stopped, error).
* **More Advanced Settings:** Add options for filtering file types, including subdirectories, configuring logging levels, etc.
* **Background Service Option:** For true "install and forget" automation, consider implementing the core logic as a Windows Service instead of a user-run tray application.

This README provides a comprehensive overview of the project, its functionality, and the knowledge gained during its development.
