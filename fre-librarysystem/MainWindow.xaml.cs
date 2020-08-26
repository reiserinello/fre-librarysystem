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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace fre_librarysystem
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ControllerLogin C_ControllerLogin = new ControllerLogin();
            string mypass = pwdPassword.Password;
            var user = C_ControllerLogin.getUser(txtUsername.Text);

            // If user exists
            if (user != null)
            {
                // If password is correct
                if (pwdPassword.Password == user[0].password)
                {
                    if (user[0].write == false && user[0].write_rent == false)
                    {
                        // UserUI
                        MainUserUI newMainUserUI = new MainUserUI(user[0].username);
                        newMainUserUI.Show();
                    } else
                    {
                        // AdminUI
                        MainAdminUI newMainAdminUI = new MainAdminUI();
                        newMainAdminUI.Show();
                    }

                    this.Close();
                    
                } else
                {
                    MessageBox.Show("Password is not correct", "Invalide credentials", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            } else
            {
                MessageBox.Show("User does not exist", "Invalide credntials", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
