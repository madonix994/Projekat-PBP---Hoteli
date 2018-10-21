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
    /// Interaction logic for ReservationPage.xaml
    /// </summary>
    public partial class ReservationPage : Window
    {
        private TypeBusiness typeBusiness = new TypeBusiness();
        private HotelBusiness hotelBusiness = new HotelBusiness();
        private ReservationBusiness reservationBusiness = new ReservationBusiness();
        private ServiceBusiness serviceBusiness = new ServiceBusiness();
        private VisitorBusiness visitorBusiness = new VisitorBusiness();

        
        public ReservationPage()
        {
            InitializeComponent();
            this.FillData();
            this.FillComboData();
        }

        public void FillData()
        {
            List<ReservationHotelTypeVisitorService> lista = this.reservationBusiness.GetAllReservations();

            // Komanda za popunjavanje DataGrida
            dataGrid.ItemsSource = lista;
        }

        public void FillComboData()
        {

            List<Hotel> lista = this.hotelBusiness.GetAllHotels();

            foreach (Hotel h in lista)
            {
                cboxHotel.Items.Add(h.Hotel_Name);

            }

            List<Types> lista2 = this.typeBusiness.GetAllTypes();

            foreach (Types t in lista2)
            {
                cboxType.Items.Add(t.Type_Name);
            }

            List<Service> lista3 = this.serviceBusiness.GetAllServicesIDNAME();

            foreach (Service s in lista3)
            {
                cboxService.Items.Add(s.Service_Name);

            }

            List<Visitor> lista4 = this.visitorBusiness.GetAllVisitors();

            foreach (Visitor v in lista4)
            {
                string fullname = v.Name + " " + v.Surname;
                cboxCard.Items.Add(fullname);
            }

        }

        public void Clean()
        {
            
            txtDate.Text = "";
            cboxCard.Text = "";
            cboxHotel.Text = "";
            cboxType.Text = "";
            cboxService.Text = "";


        }

        private void Unesi_Click(object sender, RoutedEventArgs e)
        {

            string Hotel_Id = "";
            string Hotel_Name = cboxHotel.SelectedItem.ToString();

            List<Hotel> lista = this.hotelBusiness.GetAllHotels();

            foreach (Hotel h in lista)
            {
                if (h.Hotel_Name == Hotel_Name)
                {
                    Hotel_Id = h.Hotel_Id;
                }
            }

            string Type_Id = "";
            string Type_Name = cboxType.SelectedItem.ToString();

            List<Types> lista2 = this.typeBusiness.GetAllTypes();

            foreach (Types t in lista2)
            {
                if (t.Type_Name == Type_Name)
                {
                    Type_Id = t.Type_Id;
                }
            }

            int Card_Id = 0;
            string fullname = cboxCard.SelectedItem.ToString();

            List<Visitor> lista3 = this.visitorBusiness.GetAllVisitors();

            foreach (Visitor v in lista3)
            {
                if (v.Name + " " + v.Surname == fullname)
                {
                    Card_Id = v.Card_Id;
                }
            }

            string Service_Id = "";
            string Service_Name = cboxService.SelectedItem.ToString();

            List<Service> lista4 = this.serviceBusiness.GetAllServicesIDNAME();

            foreach (Service s in lista4)
            {
                if (s.Service_Name == Service_Name)
                {
                    Service_Id = s.Service_Id;
                }
            }
            string DateofCancellation = "";
            if (txtDate.Text != "")
            {
                DateofCancellation = txtDate.Text;

            }

            Reservation r = new Reservation();
            r.Date_of_cancellation = DateofCancellation;
            r.Card_Id = Card_Id;
            r.Hotel_Id = Hotel_Id;
            r.Type_Id = Type_Id;
            r.Service_Id = Service_Id;


            this.reservationBusiness.InsertReservation(r);

            this.FillData();
            this.Clean();
            

        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            MainPage mp = new MainPage();
            mp.Show();
            this.Close();
        }

    }
}
