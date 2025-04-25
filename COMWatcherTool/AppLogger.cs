using System.Diagnostics; // For Debug.WriteLine (optional fallback)
using System.IO;

namespace COMWatcherTool
{
    public static class AppLogger
    {
        // Define the path for your log file.
        // Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppLog.txt") places it
        // in the same directory as your application's executable.
        private static string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppLog.txt");

        // Use an object for locking to ensure thread-safe writing to the file
        private static readonly object _lock = new object();

        /// <summary>
        /// Logs a message to the application's log file.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void LogMessage(string message)
        {
            try
            {
                // Format the log entry with a timestamp
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";

                // Use a lock to ensure that only one thread writes to the file at a time
                lock (_lock)
                {
                    // Append the log entry to the file
                    File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
                }

                // Optionally write to Debug output for easier debugging in Visual Studio
                Debug.WriteLine(logEntry);
            }
            catch (Exception ex)
            {
                // If logging to the file fails, you might log to Console or Debug as a fallback,
                // or handle the error in a way that doesn't cause a crash in a background app.
                Console.WriteLine($"Error writing to log file: {ex.Message}");
                Debug.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }

        // You can add other logging methods here, e.g., LogError, LogWarning, etc.
        // public static void LogError(string message) { LogMessage($"[ERROR] {message}"); }
        // public static void LogWarning(string message) { LogMessage($"[WARN] {message}"); }
        // public static void LogInfo(string message) { LogMessage($"[INFO] {message}"); }
    }
}