using BusinessLayer;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;
using System.Windows;

namespace ProbasaOracleom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        private UserBusiness userBusiness = new UserBusiness();


        public LoginPage()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = Username.Text;
            string password = Password.Password;

            if (this.userBusiness.GetUser(username, password) == false)
            {
                MessageBox.Show("Uneli ste pogrešne podatke.");

            }
            else
            {
                MessageBox.Show("Uspešno ste se ulogovali.");


                MainPage mp = new MainPage();

                mp.Show();
                this.Close();
            }

        }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Password_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void brtRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage rp = new RegisterPage();
            rp.Show();
            this.Close();
        }

      
    }
}
