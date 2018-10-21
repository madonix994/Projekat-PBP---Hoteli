using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ServiceBusiness
    {
        private ServiceRepository serviceRepository;


        public ServiceBusiness()
        {
            this.serviceRepository = new ServiceRepository();
        }

        public List<ServiceType> GetAllServices()
        {
            return this.serviceRepository.GetAllServices();
            
        }

        public List<Service> GetAllServicesIDNAME()
        {
            return this.serviceRepository.GetAllServicesIDNAME();

        }

        public bool InsertService(Service s)
        {

            if (serviceRepository.InsertService(s) > 0)
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
