using Hardcodet.Wpf.TaskbarNotification;
using System.IO; // Required for FileSystemWatcher
using System.Windows;
// Make sure these using directives match the namespaces of your helper classes

namespace COMWatcherTool
{
    public partial class App : Application
    {
        private TaskbarIcon notifyIcon;
        private FileSystemWatcher watcher; // **Declare the FileSystemWatcher**

        // We'll get the folder path from settings now, no need for a separate field here
        // private string folderToWatch;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                // Retrieve the TaskbarIcon from resources using its x:Key="NotifyIcon"
                notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
                System.Diagnostics.Debug.WriteLine($"NotifyIcon loaded: {notifyIcon != null}");
            }
            catch (Exception ex) // Catching generic Exception for simplicity in example
            {
                MessageBox.Show($"Error loading TaskbarIcon: {ex.Message}", "Startup Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
                return;
            }

            // **Initialize the watcher on startup**
            // We don't need to call StartMonitoring() here if you want it manual via menu
            InitializeWatcher();

            // You might want to show a startup balloon tip
            // notifyIcon.ShowBalloonTip("App Started", "COM Registration Watcher is running.", BalloonIcon.Info);
        }

        private void InitializeWatcher()
        {
            // Dispose of existing watcher if re-initializing (e.g., after settings change)  
            if (watcher != null)
            {
                watcher.Dispose();
            }

            // **Get the folder path from application settings**  
            string folderPath = COMWatcherTool.Properties.Settings.Default.FolderToWatch;

            // **Basic check if the folder exists**  
            if (string.IsNullOrEmpty(folderPath) || !Directory.Exists(folderPath))
            {
                string errorMessage = string.IsNullOrEmpty(folderPath) ? "Monitoring path is not set." : $"Monitoring path not found: {folderPath}";
                AppLogger.LogMessage($"[ERROR] Watcher Initialization Failed: {errorMessage}");
                // Show a tray balloon tip error  
                notifyIcon.ShowBalloonTip("Watcher Setup Failed", errorMessage, BalloonIcon.Error);
                watcher = null; // Ensure watcher is null if initialization fails  
                return;
            }

            try
            {
                watcher = new FileSystemWatcher(folderPath);

                // Configure what changes to watch for  
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.DirectoryName; // Added DirectoryName for renamed folders  

                // Only watch for .dll files (adjust filter as needed)  
                watcher.Filter = "*.dll";

                // Include subdirectories if desired (optional)  
                // watcher.IncludeSubdirectories = true;  

                // **Subscribe to the event handlers**  
                watcher.Created += OnDllCreated;
                watcher.Deleted += OnDllDeleted;
                watcher.Renamed += OnDllRenamed;

                // **Handle errors that occur within the watcher**  
                watcher.Error += OnWatcherError;

                watcher.EnableRaisingEvents = false; // Start disabled  
                AppLogger.LogMessage($"[INFO] Watcher initialized for: {folderPath}");
                // Optional: Show a success balloon tip if initialization was successful  
                // notifyIcon.ShowBalloonTip("Watcher Initialized", $"Ready to watch: {folderPath}", BalloonIcon.Info);  

            }
            catch (Exception ex)
            {
                AppLogger.LogMessage($"[FATAL] Exception during Watcher Initialization: {ex.Message}");
                notifyIcon.ShowBalloonTip("Watcher Setup Error", $"An error occurred initializing the watcher. Check logs. Details: {ex.Message}", BalloonIcon.Error);
                watcher = null; // Ensure watcher is null on exception  
            }
        }


        // **Connect these to your ContextMenu Item Clicks in App.xaml**
        private void StartMonitoring_Click(object sender, RoutedEventArgs e)
        {
            AppLogger.LogMessage("[INFO] 'Start Monitoring' clicked.");
            // Re-initialize watcher to pick up potential settings changes
            InitializeWatcher();

            if (watcher != null)
            {
                if (!watcher.EnableRaisingEvents)
                {
                    watcher.EnableRaisingEvents = true;
                    AppLogger.LogMessage($"[INFO] Monitoring started for: {watcher.Path}");
                    notifyIcon.ShowBalloonTip("Monitoring Started", $"Watching folder: {watcher.Path}", BalloonIcon.Info);
                    // Optional: Update menu item states (e.g., disable Start, enable Stop)
                }
                else
                {
                    AppLogger.LogMessage("[INFO] Monitoring is already started.");
                    notifyIcon.ShowBalloonTip("Monitoring Status", "Already monitoring.", BalloonIcon.Info);
                }
            }
            else
            {
                AppLogger.LogMessage("[ERROR] Cannot start monitoring: Watcher not initialized.");
                notifyIcon.ShowBalloonTip("Monitoring Error", "Watcher not initialized. Check logs.", BalloonIcon.Error);
            }
        }

        private void StopMonitoring_Click(object sender, RoutedEventArgs e)
        {
            AppLogger.LogMessage("[INFO] 'Stop Monitoring' clicked.");
            if (watcher != null && watcher.EnableRaisingEvents)
            {
                watcher.EnableRaisingEvents = false;
                AppLogger.LogMessage($"[INFO] Monitoring stopped for: {watcher.Path}");
                notifyIcon.ShowBalloonTip("Monitoring Stopped", $"Stopped watching folder: {watcher.Path}", BalloonIcon.Info);
                // Optional: Update menu item states
            }
            else if (watcher != null && !watcher.EnableRaisingEvents)
            {
                AppLogger.LogMessage("[INFO] Monitoring is already stopped.");
                notifyIcon.ShowBalloonTip("Monitoring Status", "Already stopped.", BalloonIcon.Info);
            }
            else
            {
                AppLogger.LogMessage("[WARN] 'Stop Monitoring' clicked but watcher was not initialized.");
                notifyIcon.ShowBalloonTip("Monitoring Status", "Watcher not running.", BalloonIcon.Info);
            }
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            AppLogger.LogMessage("[INFO] 'Settings' clicked.");
            // Logic to show your settings window (MainWindow or a dedicated SettingsWindow)
            var settingsWindow = new MainWindow(); // Assuming MainWindow is your settings window

            // Optional: Subscribe to the Closing event of the settings window
            // to re-initialize the watcher if settings were saved and monitoring is stopped
            settingsWindow.Closing += (s, args) =>
            {
                // Check if settings were saved (you'd need a property in MainWindow)
                // If saved AND monitoring is stopped, call InitializeWatcher();
                AppLogger.LogMessage("[INFO] Settings window closing.");
                // Example check (requires adding a boolean property like IsSaved in MainWindow):
                // if (settingsWindow.IsSaved && watcher != null && !watcher.EnableRaisingEvents)
                // {
                //     AppLogger.LogMessage("[INFO] Settings saved, re-initializing watcher...");
                //     InitializeWatcher();
                // }
            };

            settingsWindow.Show(); // Show the settings window
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            AppLogger.LogMessage("[INFO] 'Exit' clicked. Shutting down application.");
            // Logic to shut down the application cleanly
            Application.Current.Shutdown(); // This stops the application cleanly
        }

        // **Implement OnDllCreated, OnDllDeleted, OnDllRenamed methods here**
        // **These will contain the RegAsmHelper.RunRegAsmCommand calls**
        private static void OnDllCreated(object sender, FileSystemEventArgs e)
        {
            AppLogger.LogMessage($"[EVENT] DLL Created: {e.FullPath} - Attempting Registration...");
            // ... (RegAsm call logic from Console app example, use RegAsmHelper.RunRegAsmCommand) ...
            if (e.FullPath.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
            {
                // Add a small delay - often needed to ensure the file is fully written and accessible
                Thread.Sleep(500); // Adjust delay as needed based on typical file copy time

                // Call your RegAsm helper method
                // This requires RegAsmHelper class to be accessible (e.g., in the same namespace or public)
                RegAsmHelper.RunRegAsmCommand($"\"{e.FullPath}\" /tlb /codebase");
            }
            else
            {
                AppLogger.LogMessage($"[WARN] Created file ignored (not a .dll): {e.FullPath}");
            }
        }

        private static void OnDllDeleted(object sender, FileSystemEventArgs e)
        {
            AppLogger.LogMessage($"[EVENT] DLL Deleted: {e.FullPath} - Attempting Unregistration...");
            if (e.FullPath.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
            {
                // Call your RegAsm helper method
                RegAsmHelper.RunRegAsmCommand($"\"{e.FullPath}\" /unregister");
            }
            else
            {
                AppLogger.LogMessage($"[WARN] Deleted file ignored (not a .dll): {e.FullPath}");
            }
        }

        private static void OnDllRenamed(object sender, RenamedEventArgs e)
        {
            AppLogger.LogMessage($"[EVENT] DLL Renamed: {e.OldFullPath} to {e.FullPath}");
            // Handle rename as unregistering the old path and registering the new path
            if (e.OldFullPath.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
            {
                AppLogger.LogMessage($"[INFO] Attempting unregistration of old DLL path: {e.OldFullPath}");
                RegAsmHelper.RunRegAsmCommand($"\"{e.OldFullPath}\" /unregister");
            }
            else
            {
                AppLogger.LogMessage($"[WARN] Old renamed file ignored (not a .dll): {e.OldFullPath}");
            }

            if (e.FullPath.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
            {
                // Add a small delay
                Thread.Sleep(500); // Adjust delay

                AppLogger.LogMessage($"[INFO] Attempting registration of new DLL path: {e.FullPath}");
                RegAsmHelper.RunRegAsmCommand($"\"{e.FullPath}\" /tlb /codebase");
            }
            else
            {
                AppLogger.LogMessage($"[WARN] New renamed file ignored (not a .dll): {e.FullPath}");
            }
        }

        // **Implement the watcher error handler**
        // **Implement the watcher error handler**
        private void OnWatcherError(object sender, ErrorEventArgs e)
        {
            AppLogger.LogMessage($"[FATAL] FileSystemWatcher Error: {e.GetException().Message}");

            // FileSystemWatcher events are raised on a ThreadPool thread.  
            // Updating UI elements (like showing a balloon tip) must be done on the UI thread.  
            // We use the Dispatcher for this.  
            Application.Current.Dispatcher.Invoke(() =>
            {
                notifyIcon.ShowBalloonTip("Watcher Error", $"A file system watcher error occurred. Monitoring stopped. Check logs. Details: {e.GetException().Message}", BalloonIcon.Error);
                StopMonitoring_Click(null, null); // Corrected to pass null for sender and event args  
            });
        }

        protected override void OnExit(ExitEventArgs e)
        {
            AppLogger.LogMessage("[INFO] Application exiting.");
            // Stop watching before exiting
            if (watcher != null)
            {
                watcher.EnableRaisingEvents = false; // Explicitly stop events
                watcher.Dispose(); // Dispose the watcher
                AppLogger.LogMessage("[INFO] Watcher disposed.");
            }
            if (notifyIcon != null)
            {
                notifyIcon.Dispose(); // Dispose the TaskbarIcon
                AppLogger.LogMessage("[INFO] TaskbarIcon disposed.");
            }

            // Optional: Save settings on exit (though saving from settings window is more common)
            // Properties.Settings.Default.Save();

            base.OnExit(e);
        }
    }
}