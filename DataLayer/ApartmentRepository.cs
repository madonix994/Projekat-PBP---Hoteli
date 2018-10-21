using DataLayer.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ApartmentRepository
    {
        OracleConnection con = null;

        string conString = "USER ID=SEMA;PASSWORD=Kraljevo036+;DATA SOURCE=127.0.0.1:1521/ORCL;";


        public List<HotelApartmentType> GetAllApartments()
        {
            List<HotelApartmentType> lista = new List<HotelApartmentType>();
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT SOBE.BROJ_SOBE, SOBE.BROJ_SPRATA, SOBE.BROJ_KREVETA, HOTELI.NAZIV, TIPOVI.NAZIV FROM HOTELI JOIN SOBE ON HOTELI.SIFRA = SOBE.SIFRA_HOTELA JOIN TIPOVI ON SOBE.SIFRA_TIPA = TIPOVI.SIFRA";
            OracleDataReader dataReader = cmd.ExecuteReader();
            
            while (dataReader.Read())
            {
                HotelApartmentType hat = new HotelApartmentType();
                hat.Apartment_Number = dataReader.GetInt32(0);
                hat.Apartment_Floor_Number = dataReader.GetInt32(1);
                hat.Apartment_Bed_Number = dataReader.GetInt32(2);
                hat.Hotel_Name = dataReader.GetString(3);
                hat.Type_Name = dataReader.GetString(4);

                lista.Add(hat);
            }

            return lista;


        }

        public int InsertApartment(Apartment a)
        {
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            List<HotelApartmentType> lista = this.GetAllApartments();
            int number = lista.Count() + 1;

            cmd.CommandText = "INSERT INTO SOBE VALUES(" + number + ", " + a.Apartment_Floor_Number + ", " + a.Apartment_Bed_Number + ", '"+ a.Hotel_Id + "', '', '" + a.Type_Id + "')";

            return cmd.ExecuteNonQuery();
        }



        public int UpdateApartment(Apartment a)
        {
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE SOBE SET BROJ_SPRATA = " + a.Apartment_Floor_Number + ", BROJ_KREVETA = " + a.Apartment_Bed_Number + ", SIFRA_HOTELA ='" + a.Hotel_Id + "', SIFRA_TIPA ='" + a.Type_Id + "' WHERE BROJ_SOBE = " + a.Apartment_Number;

            return cmd.ExecuteNonQuery();
        }


    }
}
