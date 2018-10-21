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
    public class ReservationRepository
    {
        OracleConnection con = null;

        string conString = "USER ID=SEMA;PASSWORD=Kraljevo036+;DATA SOURCE=127.0.0.1:1521/ORCL;";


        public List<ReservationHotelTypeVisitorService> GetAllReservations()
        {
            List<ReservationHotelTypeVisitorService> lista = new List<ReservationHotelTypeVisitorService>();
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT HOTELI.NAZIV, REZERVACIJE.DATUM_PRIJAVE, REZERVACIJE.DATUM_ODJAVE, GOSTI.BROJ_LICNE_KARTE, GOSTI.IME, GOSTI.PREZIME, TIPOVI.NAZIV, USLUGE.VRSTA FROM HOTELI JOIN REZERVACIJE ON HOTELI.SIFRA = REZERVACIJE.SIFRA_HOTELA JOIN TIPOVI ON REZERVACIJE.SIFRA_TIPA = TIPOVI.SIFRA JOIN USLUGE ON REZERVACIJE.ID_USLUGE = USLUGE.ID_USLUGE JOIN GOSTI ON REZERVACIJE.BROJ_LICNE_KARTE = GOSTI.BROJ_LICNE_KARTE";
            OracleDataReader dataReader = cmd.ExecuteReader();
            
            while (dataReader.Read())
            {
                ReservationHotelTypeVisitorService rhtvs = new ReservationHotelTypeVisitorService();
                rhtvs.Hotel_Name = dataReader.GetString(0);
                rhtvs.Date_of_registration = Convert.ToString(dataReader.GetDateTime(1)).Substring(0, 9);

                if (!dataReader.IsDBNull(2))
                {
                    rhtvs.Date_of_cancellation = Convert.ToString(dataReader.GetDateTime(2)).Substring(0, 9);

                }
                else
                {
                    rhtvs.Date_of_cancellation = "Nije određen";
                }


                rhtvs.Card_Id = dataReader.GetInt32(3);
                rhtvs.Name = dataReader.GetString(4);
                rhtvs.Surname = dataReader.GetString(5);
                rhtvs.Type_Name = dataReader.GetString(6);
                rhtvs.Service_Name = dataReader.GetString(7);
                

                lista.Add(rhtvs);
            }

            return lista;


        }



        public int InsertReservation(Reservation r)
        {
            con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            string date = DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            if (r.Date_of_cancellation != "")
            {
                cmd.CommandText = "INSERT INTO REZERVACIJE VALUES( TO_DATE('" + date + "','MM/dd/yyyy'), TO_DATE('" + r.Date_of_cancellation + "','MM/dd/yyyy'),'" + r.Hotel_Id + "', " + r.Card_Id + ", '" + r.Type_Id + "', '" + r.Service_Id + "')";

            }
            else
            {
                cmd.CommandText = "INSERT INTO REZERVACIJE VALUES( TO_DATE('" + date + "','MM/dd/yyyy'), '', '" + r.Hotel_Id + "', " + r.Card_Id + ", '" + r.Type_Id + "', '" + r.Service_Id + "')";

            }


            return cmd.ExecuteNonQuery();
        }

        

    }
}
