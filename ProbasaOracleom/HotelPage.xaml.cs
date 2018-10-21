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
    /// Interaction logic for HotelPage.xaml
    /// </summary>
    public partial class HotelPage : Window
    {
        private HotelBusiness hotelBusiness = new HotelBusiness();


        public HotelPage()
        {
            InitializeComponent();
            this.FillData();
            this.FillComboData();
        }

        public void FillData()
        {
            List<Hotel> lista = this.hotelBusiness.GetAllHotels();

            // Komanda za popunjavanje DataGrida
            dataGrid.ItemsSource = lista;
        }

        public void FillComboData()
        {
            
            cboxCategory.Items.Add("A");
            cboxCategory.Items.Add("B");
            cboxCategory.Items.Add("C");
            cboxCategory.Items.Add("D");
            
        }

        public void Clean()
        {

            txtAddress.Clear();
            txtHotel_Id.Clear();
            txtName.Clear();
            txtBed_Number.Clear();
            cboxCategory.Text = "";

        }

        private void Unesi_Click(object sender, RoutedEventArgs e)
        {

            string Name = txtName.Text;
            string Address = txtAddress.Text;
            string Category = cboxCategory.SelectedItem.ToString();
            int Bed_Number = Convert.ToInt32(txtBed_Number.Text);


            Hotel h = new Hotel();
            h.Hotel_Name = Name;
            h.Hotel_Category = Category;
            h.Hotel_Address = Address;
            h.Hotel_Bed_Number = Bed_Number;
            
            this.hotelBusiness.InsertHotel(h);

            this.FillData();
            this.Clean();





        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Hotel h = (Hotel)dataGrid.SelectedItem;

            if (h != null)
            {
                txtHotel_Id.Text = Convert.ToString(h.Hotel_Id);
                txtName.Text = h.Hotel_Name;
                txtAddress.Text = h.Hotel_Address;
                cboxCategory.Text = h.Hotel_Category;
                txtBed_Number.Text = Convert.ToString(h.Hotel_Bed_Number);

            }
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            string Hotel_Id = txtHotel_Id.Text;
            string Name = txtName.Text;
            string Address = txtAddress.Text;
            string Category = cboxCategory.SelectedItem.ToString();
            int Bed_Number = Convert.ToInt32(txtBed_Number.Text);


            Hotel h = new Hotel();
            h.Hotel_Id = Hotel_Id;
            h.Hotel_Name = Name;
            h.Hotel_Category = Category;
            h.Hotel_Address = Address;
            h.Hotel_Bed_Number = Bed_Number;

            this.hotelBusiness.UpdateHotel(h);

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
