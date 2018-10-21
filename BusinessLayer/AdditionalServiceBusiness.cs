using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AdditionalServiceBusiness
    {
        private AdditionalServiceRepository additionalServiceRepository;


        public AdditionalServiceBusiness()
        {
            this.additionalServiceRepository = new AdditionalServiceRepository();
        }

        public List<AdditionalServiceHotel> GetAllAdditionalServices()
        {
            return this.additionalServiceRepository.GetAllAdditionalServices();
            
        }

        public List<AdditionalService> GetAllAdditionalServicesIDNAME()
        {
            return this.additionalServiceRepository.GetAllAdditionalServicesIDNAME();

        }

        public bool InsertAdditionalService(AdditionalService a)
        {

            if (additionalServiceRepository.InsertAdditionalService(a) > 0)
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
