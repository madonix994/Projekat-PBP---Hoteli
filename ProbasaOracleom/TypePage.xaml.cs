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
    /// Interaction logic for TypePage.xaml
    /// </summary>
    public partial class TypePage : Window
    {
        private TypeBusiness typeBusiness = new TypeBusiness();

        public TypePage()
        {
            InitializeComponent();
            this.FillData();
        }

        public void FillData()
        {
            List<Types> lista = this.typeBusiness.GetAllTypes();

            // Komanda za popunjavanje DataGrida
            dataGrid.ItemsSource = lista;
        }

        public void Clean()
        {

            txtType_Id.Clear();
            txtName.Clear();

        }

        private void Unesi_Click(object sender, RoutedEventArgs e)
        {
            string Name = txtName.Text;
                       
            Types t = new Types();
            
            t.Type_Name = Name;

            this.typeBusiness.InsertType(t);

            this.FillData();
            this.Clean();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            string Type_Id = txtType_Id.Text;
            string Name = txtName.Text;

            Types t = new Types();

            t.Type_Id = Type_Id;
            t.Type_Name = Name;

            this.typeBusiness.UpdateType(t);

            this.FillData();
            this.Clean();


        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Types t = (Types)dataGrid.SelectedItem;

            if (t != null)
            {
                txtType_Id.Text = t.Type_Id;
                txtName.Text = t.Type_Name;
                
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
