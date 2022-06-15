using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OptikerrDB
{
    /// <summary>
    /// Interaktionslogik für LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

        }

        private void buttonA_Click(object sender, RoutedEventArgs e)
        {
            //Statische Werte
            var stName = "Admin";
            var stPassword = "Admin";

            if (TextBoxName.Text == stName && TextBoxPasswort.Text == stPassword)
            {
                DialogResult = true;
                Close();
            }
            else if (TextBoxName.Text != stName && TextBoxPasswort.Text != stPassword)
            {
                MessageBox.Show("Username or Passwort is Incorrect");
                DialogResult = false;
                Close();
            }
            else
            {
                MessageBox.Show("No, Username or Passwort");
                DialogResult=false;
                Close();
            }
            
        }
    }
}
