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
    /// Interaction logic for SelectName.xaml
    /// </summary>
    public partial class SelectName : Window
    {
        private bool nameDone;
        private Reference reference;

        public SelectName(Reference ref1)
        {
            InitializeComponent();
            nameDone = false;
            reference = ref1;
            this.textBox.Text = reference.GetName;
        }

        private bool fieldIsNull
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.textBox.Text);
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
            if (!nameDone)
            {
                if (!nameCheck)
                {
                    textBox.Background = errorBackColor;
                }
                else
                {
                    reference.SetName = this.textBox.Text;
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
                    reference.SetPassword = this.textBox.Text;
                    var winName = new SelectSftp(reference);
                    winName.Show();
                    this.Close();
                }
            }
        }

        private bool nameCheck
        {
            get
            {
                string tmp1 = this.textBox.Text;

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
                string tmp1 = this.textBox.Text;

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

        private void changeToPassword()
        {
            this.textBox.Text = reference.GetPassword;
        }     
    }
}
