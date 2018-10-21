using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BillBusiness
    {
        private BillRepository billRepository;


        public BillBusiness()
        {
            this.billRepository = new BillRepository();
        }

        public List<BillContractAdditionalServiceVisitor> GetAllBills()
        {
            return this.billRepository.GetAllBills();
            
        }

        //public List<Contract> GetAllContractsIDNAME()
        //{
        //    return this.billRepository.GetAllContractsIDNAME();

        //}

        //public bool InsertContract(Contract c)
        //{

        //    if (billRepository.InsertContract(c) > 0)
        //    {

        //        return true;

        //    }
        //    else
        //    {

        //        return false;

        //    }

        //}

        //public bool UpdateContract(Contract c)
        //{

        //    if (billRepository.UpdateContract(c) > 0)
        //    {

        //        return true;

        //    }
        //    else
        //    {

        //        return false;

        //    }

        //}

        //public bool DeleteContract(string id)
        //{

        //    if (contractRepository.DeleteContract(id) > 0)
        //    {

        //        return true;

        //    }
        //    else
        //    {

        //        return false;

        //    }

        //}


    }
}
