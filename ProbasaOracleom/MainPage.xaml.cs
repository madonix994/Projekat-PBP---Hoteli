using BusinessLayer;
using DataLayer.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {

        public MainPage()
        {
            InitializeComponent();
            
        }

        private void visitors_MouseEnter(object sender, MouseEventArgs e)
        {
            borderimage.BorderBrush = Brushes.LightBlue;
                        
        }

        private void visitors_MouseLeave(object sender, MouseEventArgs e)
        {
            borderimage.BorderBrush = Brushes.DodgerBlue;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VisitorPage vp = new VisitorPage();
            vp.Show();
            this.Close();
        }

        private void Hotel_Click(object sender, RoutedEventArgs e)
        {
            HotelPage hp = new HotelPage();
            hp.Show();
            this.Close();
        }

        private void Service_Click(object sender, RoutedEventArgs e)
        {
            ServicePage sp = new ServicePage();
            sp.Show();
            this.Close();
        }

        private void Type_Click(object sender, RoutedEventArgs e)
        {
            TypePage tp = new TypePage();
            tp.Show();
            this.Close();
        }

        private void Apartment_Click(object sender, RoutedEventArgs e)
        {
            ApartmentPage ap = new ApartmentPage();
            ap.Show();
            this.Close();
        }

        private void Bill_Click(object sender, RoutedEventArgs e)
        {
            BillPage bp = new BillPage();
            bp.Show();
            this.Close();
        }

        private void Contract_Click(object sender, RoutedEventArgs e)
        {
            ContractPage cp = new ContractPage();
            cp.Show();
            this.Close();
        }

        private void AdditionalService_Click(object sender, RoutedEventArgs e)
        {
            AdditionalServicePage asp = new AdditionalServicePage();
            asp.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginPage lp = new LoginPage();
            lp.Show();
            this.Close();
        }

        private void Reservation_Click(object sender, RoutedEventArgs e)
        {
            ReservationPage rp = new ReservationPage();
            rp.Show();
            this.Close();
        }

    }
}
