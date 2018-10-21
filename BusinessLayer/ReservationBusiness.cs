using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ReservationBusiness
    {
        private ReservationRepository reservationRepository;


        public ReservationBusiness()
        {
            this.reservationRepository = new ReservationRepository();
        }

        public List<ReservationHotelTypeVisitorService> GetAllReservations()
        {
            return this.reservationRepository.GetAllReservations();
            
        }

        public bool InsertReservation(Reservation r)
        {

            if (reservationRepository.InsertReservation(r) > 0)
            {

                return true;

            }
            else
            {

                return false;

            }

        }

        


    }
}
