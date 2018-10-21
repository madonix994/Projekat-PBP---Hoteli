using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class HotelBusiness
    {
        private HotelRepository hotelRepository;


        public HotelBusiness()
        {
            this.hotelRepository = new HotelRepository();
        }

        public List<Hotel> GetAllHotels()
        {
            return this.hotelRepository.GetAllHotels();
            
        }

        public bool InsertHotel(Hotel h)
        {

            if (hotelRepository.InsertHotel(h) > 0)
            {

                return true;

            }
            else
            {

                return false;

            }

        }

        public bool UpdateHotel(Hotel h)
        {

            if (hotelRepository.UpdateHotel(h) > 0)
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
