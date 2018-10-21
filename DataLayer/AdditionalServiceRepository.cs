using DataLayer.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AdditionalServiceRepository
    {
        OracleConnection con = null;

        string conString = "USER ID=SEMA;PASSWORD=Kraljevo036+;DATA SOURCE=127.0.0.1:1521/ORCL;";


        public List<AdditionalServiceHotel> GetAllAdditionalServices()
        {
            List<AdditionalServiceHotel> lista = new List<AdditionalServiceHotel>();
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT DODATNE_USLUGE_HOTELA.NAZIV, DODATNE_USLUGE_HOTELA.OPIS, HOTELI.NAZIV FROM DODATNE_USLUGE_HOTELA JOIN HOTELI ON HOTELI.SIFRA = DODATNE_USLUGE_HOTELA.SIFRA_HOTELA";
            OracleDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                AdditionalServiceHotel ash = new AdditionalServiceHotel();
                ash.AService_Name = dataReader.GetString(0);
                ash.AService_Desc = dataReader.GetString(1);
                ash.Hotel_Name = dataReader.GetString(2);
                lista.Add(ash);
            }

            return lista;


        }

        public List<AdditionalService> GetAllAdditionalServicesIDNAME()
        {
            List<AdditionalService> lista = new List<AdditionalService>();
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT REDNI_BROJ_USLUGE, NAZIV FROM DODATNE_USLUGE_HOTELA";
            OracleDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                AdditionalService ash = new AdditionalService();
                ash.AService_Id = dataReader.GetString(0);
                ash.AService_Name = dataReader.GetString(1);
                lista.Add(ash);
            }

            return lista;


        }

        public int InsertAdditionalService(AdditionalService a)
        {
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            List<AdditionalServiceHotel> lista = this.GetAllAdditionalServices();
            int number = lista.Count() + 1;

            cmd.CommandText = "INSERT INTO DODATNE_USLUGE_HOTELA VALUES(" + number + ",'" + a.AService_Name + "', '" + a.AService_Desc + "','" + a.Hotel_Id + "')";

            return cmd.ExecuteNonQuery();
        }



    }
}
