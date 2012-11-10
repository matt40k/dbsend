using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace dbSend.GUI
{
    /// <summary>
    /// Interaction logic for SelectFile.xaml
    /// </summary>
    public partial class SelectFile : Window
    {
        private Reference reference;
        public SelectFile()
        {
            reference = new Reference();
            InitializeComponent();
        }

        private bool doesFileExist
        {
            get
            {
                return File.Exists(this.textBox.Text);
            }
        }

        private SolidColorBrush errorBackColor
        {
            get
            {
                SolidColorBrush errBackColor = new SolidColorBrush();
                errBackColor.Color = (Color)ColorConverter.ConvertFromString("#FFFF6A6A");
                errBackColor.Opacity = 0.4;
                return errBackColor;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (!doesFileExist)
            {
                textBox.Background = errorBackColor;
            }
            else
            {
                textBox.Background = Brushes.WhiteSmoke;
                reference.SetFileName = this.textBox.Text;
                var winName = new SelectName(reference);
                winName.Show();
                this.Close();
            }
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            ////
            //Reference: http://www.c-sharpcorner.com/uploadfile/mahesh/openfiledialog-in-wpf/
            ////

            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".sql";
            dlg.Filter = "SQL Backup (.sql)|*.sql|All files (*.*)|*.*";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                this.textBox.Text = filename;
            }

        }
    }
}
