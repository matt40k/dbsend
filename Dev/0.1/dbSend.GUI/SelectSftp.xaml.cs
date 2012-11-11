using System;
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
    /// Interaction logic for SelectSftp.xaml
    /// </summary>
    public partial class SelectSftp : Window
    {
        Reference reference;
        public SelectSftp(Reference ref1)
        {
            InitializeComponent();
            reference = ref1;
        }

        private bool isUserOk
        {
            get
            {
                return reference.SetSftpUser(this.userBox.Text);
            }
        }

        private bool isPassOk
        {
            get
            {
                return reference.SetSftpPass(this.passBox.Text);
            }
        }

        private bool isAddressOk
        {
            get
            {
                return reference.SetSftpAddress(this.addressBox.Text);
            }
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            if (!isUserOk)
            {
                this.userBox.Background = errorBackColor;
            }
            if (!isPassOk)
            {
                this.passBox.Background = errorBackColor;
            }
            if (!isAddressOk)
            {
                this.addressBox.Background = errorBackColor;
            }

            if (isUserOk && isPassOk && isAddressOk)
            {
                if (reference.IsSftpConnectionOk)
                {
                    errorLabel.Content = "";
                    var winName = new ProcessWin(reference);
                    winName.Show();
                    this.Close();
                }
                else
                {
                    errorLabel.Content = "Error: Unable to connect to server";
                }
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
    }
}
