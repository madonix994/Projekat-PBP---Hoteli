using DataLayer.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BillRepository
    {
        OracleConnection con = null;

        string conString = "USER ID=SEMA;PASSWORD=Kraljevo036+;DATA SOURCE=127.0.0.1:1521/ORCL;";


        public List<BillContractAdditionalServiceVisitor> GetAllBills()
        {
            List<BillContractAdditionalServiceVisitor> lista = new List<BillContractAdditionalServiceVisitor>();
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT HOTELI.NAZIV, GOSTI.BROJ_LICNE_KARTE, GOSTI.IME, GOSTI.PREZIME, DODATNE_USLUGE_HOTELA.NAZIV, UGOVORI.DATUM, UGOVORI.RADNIK, UGOVORI.CENA, UGOVORI.OPIS, RACUNI.NACIN_PLACANJA FROM HOTELI JOIN DODATNE_USLUGE_HOTELA ON HOTELI.SIFRA = DODATNE_USLUGE_HOTELA.SIFRA_HOTELA JOIN UGOVORI ON UGOVORI.REDNI_BROJ_USLUGE = DODATNE_USLUGE_HOTELA.REDNI_BROJ_USLUGE JOIN GOSTI ON GOSTI.BROJ_LICNE_KARTE = UGOVORI.BROJ_LICNE_KARTE JOIN RACUNI ON RACUNI.REDNI_BROJ_UGOVORA = UGOVORI.REDNI_BROJ_UGOVORA";
            OracleDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {

                BillContractAdditionalServiceVisitor bcasv = new BillContractAdditionalServiceVisitor();
                bcasv.Hotel_Name = dataReader.GetString(0);
                bcasv.Card_Id = dataReader.GetInt32(1);
                bcasv.Name = dataReader.GetString(2);
                bcasv.Surname = dataReader.GetString(3);
                bcasv.AService_Name = dataReader.GetString(4);
                bcasv.Date = Convert.ToString(dataReader.GetDateTime(5)).Substring(0, 9);
                bcasv.Worker = dataReader.GetString(6);
                bcasv.Price = dataReader.GetInt32(7);
                bcasv.Contract_Desc = dataReader.GetString(8);
                bcasv.PayWay = dataReader.GetString(9);
                
                lista.Add(bcasv);
            }

            return lista;


        }


        //public List<Contract> GetAllContractsIDNAME()
        //{
        //    List<Contract> lista = new List<Contract>();
        //    con = new OracleConnection();
        //    con.ConnectionString = conString;
        //    con.Open();
        //    OracleCommand cmd = con.CreateCommand();
        //    cmd.CommandText = "SELECT REDNI_BROJ_UGOVORA, OPIS FROM UGOVORI";
        //    OracleDataReader dataReader = cmd.ExecuteReader();

        //    while (dataReader.Read())
        //    {

        //        Contract c = new Contract();
        //        c.Contract_Id = dataReader.GetString(0);
        //        c.Contract_Desc = dataReader.GetString(1);
                
        //        lista.Add(c);
        //    }

        //    return lista;


        //}

        //public int InsertContract(Contract c)
        //{
        //    con = new OracleConnection();
        //    con.ConnectionString = conString;
        //    con.Open();
        //    OracleCommand cmd = con.CreateCommand();

        //    List<Contract> lista = this.GetAllContractsIDNAME();
        //    int number = lista.Count() + 1;

        //    cmd.CommandText = "INSERT INTO UGOVORI VALUES('" + number + "', TO_DATE('" + c.Date + "','MM/dd/yyyy'), '" + c.Worker + "', " + c.Price + ", '" + c.Contract_Desc + "', '" + c.AService_Id + "', " + c.Card_Id + ", '')";

        //    return cmd.ExecuteNonQuery();
        //}

        //public int UpdateContract(Contract c)
        //{
        //    con = new OracleConnection();
        //    con.ConnectionString = conString;
        //    con.Open();
        //    OracleCommand cmd = con.CreateCommand();
        //    cmd.CommandText = "UPDATE UGOVORI SET RADNIK = '" + c.Worker+ "', CENA = " + c.Price + ", OPIS = '" + c.Contract_Desc + "', REDNI_BROJ_USLUGE = '" + c.AService_Id + "', BROJ_LICNE_KARTE = " + c.Card_Id + " WHERE REDNI_BROJ_UGOVORA = '" + c.Contract_Id + "'";

        //    return cmd.ExecuteNonQuery();
        //}

        //public int DeleteContract(string id)
        //{
        //    con = new OracleConnection();
        //    con.ConnectionString = conString;
        //    con.Open();
        //    OracleCommand cmd = con.CreateCommand();
        //    cmd.CommandText = "DELETE FROM UGOVORI WHERE REDNI_BROJ_UGOVORA = '" + id + "'";

        //    return cmd.ExecuteNonQuery();
            
            
        //}


    }
}
