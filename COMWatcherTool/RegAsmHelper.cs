using System.Diagnostics;
using System.IO;
using System.Text;

namespace COMWatcherTool
{
    public static class RegAsmHelper
    {
        // --- Logging Helper (Assumes AppLogger exists) ---
        private static void LogRegAsmOutput(string message)
        {
            // Replace with your actual logging call
            AppLogger.LogMessage(message);
        }
        // --- End Logging Helper ---


        // --- Helper to find RegAsm.exe ---
        private static string FindRegAsmPath()
        {
            string windir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            string regasmFileName = "regasm.exe";

            // Common .NET Framework directories to check (more recent versions first)
            // Prioritize Framework64 on 64-bit systems for registering 64-bit DLLs
            List<string> potentialPaths = new List<string>();

            // Search in Framework64 (64-bit RegAsm)
            if (Environment.Is64BitOperatingSystem)
            {
                // Check common Framework64 folders (adjust versions as needed)
                potentialPaths.Add(Path.Combine(windir, @"Microsoft.NET\Framework64\v4.0.30319", regasmFileName));
                // Add paths for other v4.x Frameworks if necessary
                // potentialPaths.Add(Path.Combine(windir, @"Microsoft.NET\Framework64\v4.0.xxxx", regasmFileName)); // Example
                potentialPaths.Add(Path.Combine(windir, @"Microsoft.NET\Framework64\v2.0.50727", regasmFileName));
            }

            // Search in Framework (32-bit RegAsm)
            // Check common Framework folders (adjust versions as needed)
            potentialPaths.Add(Path.Combine(windir, @"Microsoft.NET\Framework\v4.0.30319", regasmFileName));
            // Add paths for other v4.x Frameworks if necessary
            // potentialPaths.Add(Path.Combine(windir, @"Microsoft.NET\Framework\v4.0.xxxx", regasmFileName)); // Example
            potentialPaths.Add(Path.Combine(windir, @"Microsoft.NET\Framework\v2.0.50727", regasmFileName));

            // Add a check for RegAsm in the system's PATH as a fallback
            potentialPaths.Add(regasmFileName);


            // Check each potential path
            foreach (string path in potentialPaths)
            {
                if (File.Exists(path))
                {
                    LogRegAsmOutput($"[INFO] Found RegAsm.exe at: {path}");
                    return path; // Return the first found path
                }
            }

            // If not found in common locations
            LogRegAsmOutput("[ERROR] RegAsm.exe not found in common .NET Framework directories or system PATH.");
            return null; // Indicate that RegAsm.exe was not found
        }
        // --- End Helper to find RegAsm.exe ---


        public static void RunRegAsmCommand(string arguments)
        {
            string regasmPath = FindRegAsmPath(); // **Use the helper method**

            if (string.IsNullOrEmpty(regasmPath))
            {
                LogRegAsmOutput("[ERROR] Cannot run RegAsm command: RegAsm.exe path not found.");
                // Consider showing a tray balloon tip error here
                // App.ShowTrayErrorBalloon("COM Registration Failed", $"RegAsm.exe not found. Registration aborted for {arguments}.");
                return; // Cannot proceed if RegAsm.exe is not found
            }


            ProcessStartInfo psi = new ProcessStartInfo(regasmPath, arguments)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false, // Required to redirect streams
                CreateNoWindow = true    // Don't open a console window for regasm
            };

            StringBuilder outputBuilder = new StringBuilder();
            StringBuilder errorBuilder = new StringBuilder();

            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo = psi;

                    process.OutputDataReceived += (sender, e) => { if (!string.IsNullOrEmpty(e.Data)) outputBuilder.AppendLine(e.Data); };
                    process.ErrorDataReceived += (sender, e) => { if (!string.IsNullOrEmpty(e.Data)) errorBuilder.AppendLine(e.Data); };

                    LogRegAsmOutput($"[INFO] Attempting to run: {regasmPath} {arguments}");

                    process.Start();

                    process.BeginOutputReadLine(); // Start reading output asynchronously
                    process.BeginErrorReadLine();  // Start reading errors asynchronously

                    // Wait for the process to exit (with a timeout to prevent hanging)
                    int timeoutMilliseconds = 30000; // 30 seconds
                    if (!process.WaitForExit(timeoutMilliseconds))
                    {
                        LogRegAsmOutput($"[WARN] RegAsm process timed out after {timeoutMilliseconds / 1000} seconds for arguments: {arguments}. Attempting to kill process.");
                        try { process.Kill(); } catch (Exception killEx) { LogRegAsmOutput($"[ERROR] Error killing timed-out RegAsm process: {killEx.Message}"); }
                        // Consider showing a tray balloon tip warning/error
                        // App.ShowTrayWarningBalloon("COM Registration Timed Out", $"RegAsm process timed out for {arguments}.");
                        return; // Exit the method after timeout/kill
                    }


                    string output = outputBuilder.ToString().Trim();
                    string error = errorBuilder.ToString().Trim();

                    if (!string.IsNullOrEmpty(output))
                    {
                        LogRegAsmOutput("RegAsm Output:");
                        LogRegAsmOutput(output);
                    }
                    if (!string.IsNullOrEmpty(error))
                    {
                        LogRegAsmOutput("RegAsm Error Output:"); // Changed label for clarity
                        LogRegAsmOutput(error);
                    }

                    if (process.ExitCode == 0)
                    {
                        LogRegAsmOutput($"[INFO] RegAsm command succeeded with exit code 0 for: {arguments}");
                        // Consider showing a tray balloon tip success notification
                        // App.ShowTrayInfoBalloon("COM Registration Success", $"Successfully processed: {Path.GetFileName(arguments.Trim('"'))}"); // Extract filename
                    }
                    else
                    {
                        LogRegAsmOutput($"[ERROR] RegAsm command failed with exit code {process.ExitCode} for: {arguments}");
                        // Consider showing a tray balloon tip error
                        // App.ShowTrayErrorBalloon("COM Registration Failed", $"RegAsm failed for {arguments}. Exit Code: {process.ExitCode}. Check logs.");
                    }
                }
            }
            catch (Exception ex)
            {
                LogRegAsmOutput($"[FATAL] An exception occurred trying to run RegAsm command '{regasmPath} {arguments}': {ex.Message}");
                // Show a tray balloon tip error for the exception
                // App.ShowTrayErrorBalloon("COM Registration Error", $"Exception running RegAsm for {arguments}. Check logs. Details: {ex.Message}");
            }
        }
    }
}