using DataLayer.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserRepository
    {
        OracleConnection con = null;


        string conString = "USER ID=SEMA;PASSWORD=Kraljevo036+;DATA SOURCE=127.0.0.1:1521/ORCL;";

        public List<User> GetAllUsers()
        {
            List<User> lista = new List<User>();
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM KORISNIK";
            OracleDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                User u = new User();
                u.Id = dataReader.GetInt32(0);
                u.Username = dataReader.GetString(1);
                u.Password = dataReader.GetString(2);
                
                
                lista.Add(u);
            }

            return lista;


        }
        public int InsertUser(User u)
        {

            List<User> lista = this.GetAllUsers();
            int number = lista.Count() + 1;
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO KORISNIK VALUES(" + number +",'" + u.Username + "', '" + u.Password + "')";

            return cmd.ExecuteNonQuery();


        }




    }
}
