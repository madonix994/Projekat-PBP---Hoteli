using DataLayer.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class VisitorRepository
    {
        OracleConnection con = null;

        string conString = "USER ID=SEMA;PASSWORD=Kraljevo036+;DATA SOURCE=127.0.0.1:1521/ORCL;";


        public List<Visitor> GetAllVisitors()
        {
            List<Visitor> lista = new List<Visitor>();
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GOSTI";
            OracleDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Visitor v = new Visitor();
                v.Card_Id = dataReader.GetInt32(0);
                v.Name = dataReader.GetString(1);
                v.Surname = dataReader.GetString(2);
                v.Address = dataReader.GetString(3);
                lista.Add(v);
            }

            return lista;


        }

        public int InsertVisitor(Visitor v)
        {
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO GOSTI VALUES(" + v.Card_Id + ",'" + v.Name + "', '" + v.Surname+ "','"+ v.Address +"')";

            return cmd.ExecuteNonQuery();
        }

        public int UpdateVisitor(Visitor v)
        {
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE GOSTI SET IME = '" + v.Name + "', PREZIME = '" + v.Surname + "', ADRESA ='" + v.Address + "' WHERE BROJ_LICNE_KARTE = " + v.Card_Id;

            return cmd.ExecuteNonQuery();
        }


    }
}
