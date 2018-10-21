using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ApartmentBusiness
    {
        private ApartmentRepository apartmentRepository;


        public ApartmentBusiness()
        {
            this.apartmentRepository = new ApartmentRepository();
        }

        public List<HotelApartmentType> GetAllApartments()
        {
            return this.apartmentRepository.GetAllApartments();
            
        }

        public bool InsertApartment(Apartment a)
        {

            if (apartmentRepository.InsertApartment(a) > 0)
            {

                return true;

            }
            else
            {

                return false;

            }

        }

        public bool UpdateApartment(Apartment a)
        {

            if (apartmentRepository.UpdateApartment(a) > 0)
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
