using BusinessLayer;
using DataLayer.Models;
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

namespace ProbasaOracleom
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        private UserBusiness userBusiness = new UserBusiness();


        public RegisterPage()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;
            string password2 = Password2.Text;

            if (username.Length > 0 && password.Length > 0 && password.Equals(password2))
            {
                User u = new User();

                u.Username = username;
                u.Password = password;

                this.userBusiness.InsertUser(u);

                MessageBox.Show("Uspešno ste se registrovali.");

                LoginPage lp = new LoginPage();

                lp.Show();

                this.Close();

            }
            else
            {
                MessageBox.Show("Uneli ste pogrešne podatke.");
            }




        }
    }
}
