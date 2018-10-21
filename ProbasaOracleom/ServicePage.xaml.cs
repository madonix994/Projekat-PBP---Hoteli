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
    /// Interaction logic for ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Window
    {

        private ServiceBusiness serviceBusiness = new ServiceBusiness();
        private TypeBusiness typeBusiness = new TypeBusiness();


        public ServicePage()
        {
            InitializeComponent();
            this.FillData();
            this.FillComboData();
        }

        public void FillData()
        {
            List<ServiceType> lista = this.serviceBusiness.GetAllServices();

            // Komanda za popunjavanje DataGrida
            dataGrid.ItemsSource = lista;
        }

        public void FillComboData()
        {
            List<Types> lista = this.typeBusiness.GetAllTypes();

            foreach(Types t in lista)
            {
                cboxType.Items.Add(t.Type_Name);
            }

        }

        public void Clean()
        {

            txtServiceName.Text = "";
            txtServicePrice.Text = "";
            cboxType.Text = "";
            
        }




        private void Unesi_Click(object sender, RoutedEventArgs e)
        {

            string Service_Name = txtServiceName.Text;
            string Service_Price = txtServicePrice.Text;
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

            Service s = new Service();
            s.Service_Name = Service_Name;
            s.Service_Price = Service_Price;
            s.Type_Id_Fk = Type_Id;
            
            this.serviceBusiness.InsertService(s);

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
