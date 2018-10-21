using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ContractBusiness
    {
        private ContractRepository contractRepository;


        public ContractBusiness()
        {
            this.contractRepository = new ContractRepository();
        }

        public List<ContractAdditionalServiceVisitor> GetAllContracts()
        {
            return this.contractRepository.GetAllContracts();
            
        }

        public List<Contract> GetAllContractsIDNAME()
        {
            return this.contractRepository.GetAllContractsIDNAME();

        }

        public bool InsertContract(Contract c)
        {

            if (contractRepository.InsertContract(c) > 0)
            {

                return true;

            }
            else
            {

                return false;

            }

        }

        public bool UpdateContract(Contract c)
        {

            if (contractRepository.UpdateContract(c) > 0)
            {

                return true;

            }
            else
            {

                return false;

            }

        }

        public bool DeleteContract(string id)
        {

            if (contractRepository.DeleteContract(id) > 0)
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
