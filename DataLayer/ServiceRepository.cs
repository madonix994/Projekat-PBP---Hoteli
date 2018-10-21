using DataLayer.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ServiceRepository
    {
        OracleConnection con = null;

        string conString = "USER ID=SEMA;PASSWORD=Kraljevo036+;DATA SOURCE=127.0.0.1:1521/ORCL;";


        public List<ServiceType> GetAllServices()
        {
            List<ServiceType> lista = new List<ServiceType>();
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT USLUGE.VRSTA, USLUGE.CENA, TIPOVI.NAZIV FROM USLUGE JOIN TIPOVI ON USLUGE.SIFRA_TIPA = TIPOVI.SIFRA";
            OracleDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                ServiceType st = new ServiceType();
                st.Service_Name = dataReader.GetString(0);
                st.Service_Price = dataReader.GetString(1);
                st.Type_Name = dataReader.GetString(2);


                lista.Add(st);
            }

            return lista;


        }

    

        public List<Service> GetAllServicesIDNAME()
        {
            List<Service> lista = new List<Service>();
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT ID_USLUGE, VRSTA FROM USLUGE";
            OracleDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Service s = new Service();
                s.Service_Id = dataReader.GetString(0);
                s.Service_Name = dataReader.GetString(1);
                

                lista.Add(s);
            }

            return lista;


        }

        public int InsertService(Service s)
        {
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            List<ServiceType> lista = this.GetAllServices();
            int number = lista.Count() + 1;

            cmd.CommandText = "INSERT INTO USLUGE VALUES('" + number + "','" + s.Service_Name + "', " + s.Service_Price + ", '"+ s.Type_Id_Fk +"')";

            return cmd.ExecuteNonQuery();
        }
                

    }
}
