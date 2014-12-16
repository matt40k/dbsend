using System.Windows;
using System.Windows.Media;

namespace dbSend.GUI
{
    /// <summary>
    ///     Interaction logic for SelectSftp.xaml
    /// </summary>
    public partial class SelectSftp : Window
    {
        private readonly Reference reference;

        public SelectSftp(Reference ref1)
        {
            InitializeComponent();
            reference = ref1;
        }

        private bool isUserOk
        {
            get { return reference.SetSftpUser(userBox.Text); }
        }

        private bool isPassOk
        {
            get { return reference.SetSftpPass(passBox.Text); }
        }

        private bool isAddressOk
        {
            get { return reference.SetSftpAddress(addressBox.Text); }
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

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            if (!isUserOk)
            {
                userBox.Background = errorBackColor;
            }
            if (!isPassOk)
            {
                passBox.Background = errorBackColor;
            }
            if (!isAddressOk)
            {
                addressBox.Background = errorBackColor;
            }

            if (isUserOk && isPassOk && isAddressOk)
            {
                if (reference.IsSftpConnectionOk)
                {
                    errorLabel.Content = "";
                    var winName = new ProcessWin(reference);
                    winName.Show();
                    Close();
                }
                else
                {
                    errorLabel.Content = "Error: Unable to connect to server";
                }
            }
        }
    }
}