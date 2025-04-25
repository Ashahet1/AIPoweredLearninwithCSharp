using System.IO; // For Directory.Exists
using System.Windows;

// Add these using directives for FolderBrowserDialog
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox; // Resolve ambiguity with System.Windows.MessageBox


namespace COMWatcherTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for when the window finishes loading
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Load the saved folder path from application settings
            FolderPathTextBox.Text = Properties.Settings.Default.FolderToWatch;

            // You might also set the DataContext if using more complex binding later
            // DataContext = Properties.Settings.Default;
        }

        // Event handler for the Browse button click
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                // Optionally set the initial folder
                if (Directory.Exists(FolderPathTextBox.Text))
                {
                    dialog.SelectedPath = FolderPathTextBox.Text;
                }

                DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    // Set the selected path to the TextBox
                    FolderPathTextBox.Text = dialog.SelectedPath;
                }
            }
        }

        // Event handler for the Save button click
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string folderPath = FolderPathTextBox.Text.Trim();

            // Basic validation: Check if the directory exists
            if (string.IsNullOrEmpty(folderPath))
            {
                MessageBox.Show("Please enter a folder path.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("The specified folder does not exist.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                // You might offer to create the folder here
                // if (MessageBox.Show($"The folder '{folderPath}' does not exist. Do you want to create it?", "Folder Not Found", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                // {
                //     try { Directory.CreateDirectory(folderPath); }
                //     catch (Exception createEx) { MessageBox.Show($"Error creating folder: {createEx.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error); return; }
                // }
                // else
                // {
                //     return; // Don't save if folder doesn't exist and user doesn't want to create it
                // }
                return; // Simple validation: Don't save if it doesn't exist
            }


            // Save the valid folder path to application settings
            Properties.Settings.Default.FolderToWatch = folderPath;
            Properties.Settings.Default.Save(); // Save the settings

            // Close the window
            this.Close();

            // Optional: Notify the main App class that settings were saved,
            // so it can update the FileSystemWatcher path if monitoring is stopped.
            // For example, you could raise an event here.
        }

        // Event handler for the Cancel button click
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the window without saving
            this.Close();
        }

        // --- Handle Window Closing (Optional for a Settings Window) ---
        // If you want to hide instead of close, override OnClosing as in the earlier example.
        // For a settings window opened from the tray, closing is usually fine.
        // protected override void OnClosing(CancelEventArgs e)
        // {
        //     base.OnClosing(e);
        //     // Add any cleanup or validation needed before closing
        // }
    }
}
