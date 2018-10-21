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
    /// Interaction logic for ContractPage.xaml
    /// </summary>
    public partial class ContractPage : Window
    {
        private HotelBusiness hotelBusiness = new HotelBusiness();
        private VisitorBusiness visitorBusiness = new VisitorBusiness();
        private ContractBusiness contractBusiness = new ContractBusiness();
        private AdditionalServiceBusiness additionalServiceBusiness = new AdditionalServiceBusiness();

        public ContractPage()
        {
            InitializeComponent();
            this.FillComboData();
            this.FillData();
        }

        public void FillData()
        {
            List<ContractAdditionalServiceVisitor> lista = this.contractBusiness.GetAllContracts();

            // Komanda za popunjavanje DataGrida
            dataGrid.ItemsSource = lista;
        }

        public void FillComboData()
        {

            List<AdditionalService> lista = this.additionalServiceBusiness.GetAllAdditionalServicesIDNAME();

            foreach (AdditionalService ash in lista)
            {
                cboxService.Items.Add(ash.AService_Name);

            }

           
            List<Visitor> lista2 = this.visitorBusiness.GetAllVisitors();

            foreach (Visitor v in lista2)
            {
                string fullname = v.Name + " " + v.Surname;
                cboxCard.Items.Add(fullname);
            }

            cboxWorker.Items.Add("Milan Ivanovic");
            cboxWorker.Items.Add("Petar Kitic");
            cboxWorker.Items.Add("Sanja Kostovic");
            cboxWorker.Items.Add("Jovan Kesic");



        }

        public void Clean()
        {

            txtDate.Text = "";
            cboxCard.Text = "";
            cboxService.Text = "";
            cboxWorker.Text = "";
            txtContract_Id.Text = "";
            txtContract_Desc.Text = "";
            txtPrice.Text = "";

        }

        private void Unesi_Click(object sender, RoutedEventArgs e)
        {

            int Price = Convert.ToInt32(txtPrice.Text);
            string Desc = txtContract_Desc.Text;
            string Worker = cboxWorker.SelectedItem.ToString();
            string Date = txtDate.Text;



            int Card_Id = 0;
            string fullname = cboxCard.SelectedItem.ToString();

            List<Visitor> lista2 = this.visitorBusiness.GetAllVisitors();

            foreach (Visitor v in lista2)
            {
                if (v.Name + " " + v.Surname == fullname)
                {
                    Card_Id = v.Card_Id;
                }
            }

            string AService_Id = "";
            string AService_Name = cboxService.SelectedItem.ToString();

            List<AdditionalService> lista3 = this.additionalServiceBusiness.GetAllAdditionalServicesIDNAME();

            foreach (AdditionalService a in lista3)
            {
                if (a.AService_Name == AService_Name)
                {
                    AService_Id = a.AService_Id;
                }
            }

            Contract c = new Contract();

            c.AService_Id = AService_Id;
            c.Card_Id = Card_Id;
            c.Contract_Desc = Desc;
            c.Price = Price;
            c.Worker = Worker;
            c.Date = Date;


            this.contractBusiness.InsertContract(c);

            this.FillData();
            this.Clean();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ContractAdditionalServiceVisitor casv = (ContractAdditionalServiceVisitor)dataGrid.SelectedItem;

            if (casv != null)
            {
                txtContract_Desc.Text = casv.Contract_Desc;
                txtDate.Text = casv.Date;
                txtPrice.Text = Convert.ToString(casv.Price);
                cboxCard.Text = casv.Name + " " + casv.Surname;
                cboxWorker.Text = casv.Worker;
                cboxService.Text = casv.AService_Name;
                
                List<Contract> lista = this.contractBusiness.GetAllContractsIDNAME();
                foreach (Contract c in lista)
                {
                    if (c.Contract_Desc == casv.Contract_Desc)
                    {
                        txtContract_Id.Text = c.Contract_Id;
                    }
                }

            }


        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            string Contract_Id = txtContract_Id.Text;
            string Desc = txtContract_Desc.Text;
            int Price = Convert.ToInt32(txtPrice.Text);
            string Worker = cboxWorker.SelectedItem.ToString();

            int Card_Id = 0;
            string fullname = cboxCard.SelectedItem.ToString();

            List<Visitor> lista2 = this.visitorBusiness.GetAllVisitors();

            foreach (Visitor v in lista2)
            {
                if (v.Name + " " + v.Surname == fullname)
                {
                    Card_Id = v.Card_Id;
                }
            }

            string AService_Id = "";
            string AService_Name = cboxService.SelectedItem.ToString();

            List<AdditionalService> lista3 = this.additionalServiceBusiness.GetAllAdditionalServicesIDNAME();

            foreach (AdditionalService a in lista3)
            {
                if (a.AService_Name == AService_Name)
                {
                    AService_Id = a.AService_Id;
                }
            }

            Contract c = new Contract();

            c.Contract_Id = Contract_Id;
            c.AService_Id = AService_Id;
            c.Card_Id = Card_Id;
            c.Contract_Desc = Desc;
            c.Price = Price;
            c.Worker = Worker;


            this.contractBusiness.UpdateContract(c);

            this.FillData();
            this.Clean();

            
        }

        private void Izbriši_Click(object sender, RoutedEventArgs e)
        {
            string Contract_Id = txtContract_Id.Text;

            try
            {
                this.contractBusiness.DeleteContract(Contract_Id);

            }
            catch (Exception)
            {
                MessageBox.Show("Red se ne može obrisati.");

            }

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
