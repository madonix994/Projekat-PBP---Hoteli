using DataLayer.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TypeRepository
    {
        OracleConnection con = null;

        string conString = "USER ID=SEMA;PASSWORD=Kraljevo036+;DATA SOURCE=127.0.0.1:1521/ORCL;";


        public List<Types> GetAllTypes()
        {
            List<Types> lista = new List<Types>();
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM TIPOVI";
            OracleDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Types t = new Types();
                t.Type_Id= dataReader.GetString(0);
                t.Type_Name= dataReader.GetString(1);
                
                lista.Add(t);
            }

            return lista;


        }

        public int InsertType(Types t)
        {
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            List<Types> lista = this.GetAllTypes();
            int number = lista.Count() + 1;

            cmd.CommandText = "INSERT INTO TIPOVI VALUES('" + number + "','" + t.Type_Name+"')";

            return cmd.ExecuteNonQuery();
        }

        public int UpdateType(Types t)
        {
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE TIPOVI SET NAZIV = '" + t.Type_Name+ "' WHERE SIFRA = " +  t.Type_Id;

            return cmd.ExecuteNonQuery();
        }


    }
}
