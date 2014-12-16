using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;

namespace dbSend.GUI
{
    /// <summary>
    ///     Interaction logic for SelectFile.xaml
    /// </summary>
    public partial class SelectFile : Window
    {
        private readonly Reference reference;

        public SelectFile()
        {
            reference = new Reference();
            InitializeComponent();
        }

        private bool doesFileExist
        {
            get
            {
                var result = File.Exists(textBox.Text);
                if (result)
                {
                    textBox.Background = Brushes.WhiteSmoke;
                }
                else
                {
                    textBox.Background = errorBackColor;
                }
                return result;
            }
        }

        private SolidColorBrush errorBackColor
        {
            get
            {
                var errBackColor = new SolidColorBrush();
                errBackColor.Color = (Color) ColorConverter.ConvertFromString("#FFFF6A6A");
                errBackColor.Opacity = 0.4;
                return errBackColor;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (doesFileExist)
            {
                reference.SetFileName = textBox.Text;
                var winName = new SelectName(reference);
                winName.Show();
                Close();
            }
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            var tmp1 = textBox.Text;
            if (!string.IsNullOrWhiteSpace(tmp1))
            {
                tmp1 = Path.GetDirectoryName(tmp1);
            }

            ////
            //Reference: http://www.c-sharpcorner.com/uploadfile/mahesh/openfiledialog-in-wpf/
            ////

            // Create OpenFileDialog 
            var dlg = new OpenFileDialog();

            if (Directory.Exists(tmp1))
            {
                dlg.InitialDirectory = tmp1;
            }

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".sql";
            dlg.Filter = "SQL Backup (.sql)|*.sql|All files (*.*)|*.*";

            // Display OpenFileDialog by calling ShowDialog method 
            var result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                var filename = dlg.FileName;
                textBox.Text = filename;
                var result1 = doesFileExist;
            }
        }

        private void textBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            var result = doesFileExist;
        }
    }
}