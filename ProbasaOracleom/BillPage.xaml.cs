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
    /// Interaction logic for BillPage.xaml
    /// </summary>
    public partial class BillPage : Window
    {
        private HotelBusiness hotelBusiness = new HotelBusiness();
        private VisitorBusiness visitorBusiness = new VisitorBusiness();
        private ContractBusiness contractBusiness = new ContractBusiness();
        private AdditionalServiceBusiness additionalServiceBusiness = new AdditionalServiceBusiness();
        private BillBusiness billBusiness = new BillBusiness();

        public BillPage()
        {
            InitializeComponent();
            this.FillData();
        }

        public void FillData()
        {
            List<BillContractAdditionalServiceVisitor> lista = this.billBusiness.GetAllBills();

            // Komanda za popunjavanje DataGrida
            dataGrid.ItemsSource = lista;
        }


        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            MainPage mp = new MainPage();
            mp.Show();
            this.Close();
        }

    }
}
