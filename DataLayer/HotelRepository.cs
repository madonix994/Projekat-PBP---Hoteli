using DataLayer.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HotelRepository
    {
        OracleConnection con = null;

        string conString = "USER ID=SEMA;PASSWORD=Kraljevo036+;DATA SOURCE=127.0.0.1:1521/ORCL;";


        public List<Hotel> GetAllHotels()
        {
            List<Hotel> lista = new List<Hotel>();
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM HOTELI";
            OracleDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Hotel h = new Hotel();
                h.Hotel_Id = dataReader.GetString(0);
                h.Hotel_Name = dataReader.GetString(1);
                h.Hotel_Address = dataReader.GetString(2);
                h.Hotel_Category = dataReader.GetString(3);
                h.Hotel_Bed_Number = dataReader.GetInt32(4);

                lista.Add(h);
            }

            return lista;


        }

        public int InsertHotel(Hotel h)
        {
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            List<Hotel> lista = this.GetAllHotels();
            int number = lista.Count() + 1;

            cmd.CommandText = "INSERT INTO HOTELI VALUES(" + number + ",'" + h.Hotel_Name + "', '" + h.Hotel_Address + "','"+ h.Hotel_Category + "'," + h.Hotel_Bed_Number + ")";

            return cmd.ExecuteNonQuery();
        }

        public int UpdateHotel(Hotel h)
        {
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE HOTELI SET NAZIV = '" + h.Hotel_Name + "', ADRESA = '" + h.Hotel_Address + "', KATEGORIJA ='" + h.Hotel_Category + "', BROJ_LEZAJA = " + h.Hotel_Bed_Number + " WHERE SIFRA = " + h.Hotel_Id;

            return cmd.ExecuteNonQuery();
        }


    }
}
