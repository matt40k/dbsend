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
                bool result = File.Exists(this.textBox.Text);
                if (result)
                {
                    this.textBox.Background = Brushes.WhiteSmoke;
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
                SolidColorBrush errBackColor = new SolidColorBrush();
                errBackColor.Color = (Color)ColorConverter.ConvertFromString("#FFFF6A6A");
                errBackColor.Opacity = 0.4;
                return errBackColor;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (doesFileExist)
            {
                reference.SetFileName = this.textBox.Text;
                var winName = new SelectName(reference);
                winName.Show();
                this.Close();
            }
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            string tmp1 = this.textBox.Text;
            if (!string.IsNullOrWhiteSpace(tmp1))
            {
                tmp1 = System.IO.Path.GetDirectoryName(tmp1);
            }

            ////
            //Reference: http://www.c-sharpcorner.com/uploadfile/mahesh/openfiledialog-in-wpf/
            ////

            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            if (Directory.Exists(tmp1))
            {
                dlg.InitialDirectory = tmp1;
            }

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
                bool result1 = doesFileExist;
            }

        }

        private void textBox_KeyDown_1(object sender, KeyEventArgs e)
        {
           bool result = doesFileExist;
        }
    }
}
