using System.Windows;
using System.Windows.Media;

namespace dbSend.GUI
{
    /// <summary>
    ///     Interaction logic for SelectName.xaml
    /// </summary>
    public partial class SelectName : Window
    {
        private bool nameDone;
        private readonly Reference reference;

        public SelectName(Reference ref1)
        {
            InitializeComponent();
            nameDone = false;
            reference = ref1;
            textBox.Text = reference.GetName;
        }

        private bool fieldIsNull
        {
            get { return string.IsNullOrWhiteSpace(textBox.Text); }
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

        private bool nameCheck
        {
            get
            {
                var tmp1 = textBox.Text;

                if (string.IsNullOrWhiteSpace(tmp1))
                {
                    return false;
                }
                if (tmp1.Length > 40)
                {
                    return false;
                }
                return true;
            }
        }

        private bool passCheck
        {
            get
            {
                var tmp1 = textBox.Text;

                if (string.IsNullOrWhiteSpace(tmp1))
                {
                    return false;
                }
                if (tmp1.Length < 5)
                {
                    return false;
                }
                if (tmp1 == reference.GetName)
                {
                    return false;
                }
                return true;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (!nameDone)
            {
                if (!nameCheck)
                {
                    textBox.Background = errorBackColor;
                }
                else
                {
                    reference.SetName = textBox.Text;
                    nameDone = true;
                    changeToPassword();
                }
            }
            else
            {
                if (!passCheck)
                {
                    textBox.Background = errorBackColor;
                }
                else
                {
                    reference.SetPassword = textBox.Text;
                    var winName = new SelectSftp(reference);
                    winName.Show();
                    Close();
                }
            }
        }

        private void changeToPassword()
        {
            textBox.Text = reference.GetPassword;
            labelTitle.Content = "Enter a password";
        }
    }
}