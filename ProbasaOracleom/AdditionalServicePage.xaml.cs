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
    /// Interaction logic for AdditionalServicePage.xaml
    /// </summary>
    public partial class AdditionalServicePage : Window
    {
        private HotelBusiness hotelBusiness = new HotelBusiness();
        private AdditionalServiceBusiness additionalServiceBusiness = new AdditionalServiceBusiness();



        public AdditionalServicePage()
        {
            InitializeComponent();
            this.FillData();
            this.FillComboData();
        }

        public void FillData()
        {
            List<AdditionalServiceHotel> lista = this.additionalServiceBusiness.GetAllAdditionalServices();

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

            

        }

        public void Clean()
        {

            txtAServiceDesc.Clear();
            txtAServiceName.Clear();
            cboxHotel.Text = "";

        }




        private void Unesi_Click(object sender, RoutedEventArgs e)
        {

            string AService_Name = txtAServiceName.Text;
            string AService_Desc = txtAServiceDesc.Text;

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

            AdditionalService a = new AdditionalService();

            a.AService_Name = AService_Name;
            a.AService_Desc = AService_Desc;
            a.Hotel_Id = Hotel_Id;

            this.additionalServiceBusiness.InsertAdditionalService(a);

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
