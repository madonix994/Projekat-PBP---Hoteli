using BusinessLayer;
using DataLayer.Models;
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
    /// Interaction logic for VisitorPage.xaml
    /// </summary>
    public partial class VisitorPage : Window
    {
        private VisitorBusiness visitorBusiness = new VisitorBusiness();


        public VisitorPage()
        {
            InitializeComponent();
            this.FillData();
            
        }

        public void FillData()
        {
            List<Visitor> lista = this.visitorBusiness.GetAllVisitors();

            // Komanda za popunjavanje DataGrida
            dataGrid.ItemsSource = lista;
        }

        public void Clean()
        {

            txtAddress.Clear();
            txtCard_Id.Clear();
            txtName.Clear();
            txtSurname.Clear();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int Card_Id = Convert.ToInt32(txtCard_Id.Text);
            string Name = txtName.Text;
            string Surname = txtSurname.Text;
            string Address = txtAddress.Text;

            Visitor v = new Visitor();
            v.Card_Id = Card_Id;
            v.Name = Name;
            v.Surname = Surname;
            v.Address = Address;

            this.visitorBusiness.InsertVisitor(v);

            this.FillData();
            this.Clean();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                        
            Visitor v = (Visitor)dataGrid.SelectedItem;

            if (v != null)
            {
                txtCard_Id.Text = Convert.ToString(v.Card_Id);
                txtName.Text = v.Name;
                txtSurname.Text = v.Surname;
                txtAddress.Text = v.Address;
            }


        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {

            int Card_Id = Convert.ToInt32(txtCard_Id.Text);
            string Name = txtName.Text;
            string Surname = txtSurname.Text;
            string Address = txtAddress.Text;

            Visitor v = new Visitor();
            v.Card_Id = Card_Id;
            v.Name = Name;
            v.Surname = Surname;
            v.Address = Address;

            this.visitorBusiness.UpdateVisitor(v);

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
