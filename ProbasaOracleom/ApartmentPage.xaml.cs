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
    /// Interaction logic for ApartmentPage.xaml
    /// </summary>
    public partial class ApartmentPage : Window
    {
        private TypeBusiness typeBusiness = new TypeBusiness();
        private HotelBusiness hotelBusiness = new HotelBusiness();
        private ApartmentBusiness apartmentBusiness = new ApartmentBusiness();

        public ApartmentPage()
        {
            InitializeComponent();
            this.FillData();
            this.FillComboData();
        }

        public void FillData()
        {
            List<HotelApartmentType> lista = this.apartmentBusiness.GetAllApartments();

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

        }

        public void Clean()
        {

            txtBed_Number.Clear();
            txtApartmentNumber.Clear();
            txtFloorNumber.Clear();
            cboxHotel.Text = "";
            cboxType.Text = "";


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
            int Bed_Number = Convert.ToInt32(txtBed_Number.Text);
            int Floor_Number = Convert.ToInt32(txtFloorNumber.Text);

            List<Types> lista2 = this.typeBusiness.GetAllTypes();

            foreach (Types t in lista2)
            {
                if (t.Type_Name == Type_Name)
                {
                    Type_Id = t.Type_Id;
                }
            }

            Apartment a = new Apartment();
            a.Apartment_Bed_Number = Bed_Number;
            a.Apartment_Floor_Number = Floor_Number;
            a.Type_Id = Type_Id;
            a.Hotel_Id = Hotel_Id;

            this.apartmentBusiness.InsertApartment(a);

            this.FillData();
            this.Clean();
                      
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
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
            int Bed_Number = Convert.ToInt32(txtBed_Number.Text);
            int Floor_Number = Convert.ToInt32(txtFloorNumber.Text);
            int Apartment_Number = Convert.ToInt32(txtApartmentNumber.Text);

            List<Types> lista2 = this.typeBusiness.GetAllTypes();

            foreach (Types t in lista2)
            {
                if (t.Type_Name == Type_Name)
                {
                    Type_Id = t.Type_Id;
                }
            }

            

            Apartment a = new Apartment();
            a.Apartment_Number = Apartment_Number;
            a.Apartment_Bed_Number = Bed_Number;
            a.Apartment_Floor_Number = Floor_Number;
            a.Type_Id = Type_Id;
            a.Hotel_Id = Hotel_Id;

            this.apartmentBusiness.UpdateApartment(a);

            this.FillData();
            this.Clean();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            HotelApartmentType hat = (HotelApartmentType)dataGrid.SelectedItem;

            if (hat != null)
            {

                txtApartmentNumber.Text = Convert.ToString(hat.Apartment_Number);
                txtBed_Number.Text = Convert.ToString(hat.Apartment_Bed_Number);
                txtFloorNumber.Text = Convert.ToString(hat.Apartment_Floor_Number);
                cboxHotel.Text = hat.Hotel_Name;
                cboxType.Text = hat.Type_Name;
          
            }
            
        }



        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            MainPage mp = new MainPage();
            mp.Show();
            this.Close();
        }

    }
}
