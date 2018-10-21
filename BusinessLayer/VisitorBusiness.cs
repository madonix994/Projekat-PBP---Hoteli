using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class VisitorBusiness
    {
        private VisitorRepository visitorRepository;


        public VisitorBusiness()
        {
            this.visitorRepository = new VisitorRepository();
        }

        public List<Visitor> GetAllVisitors()
        {
            return this.visitorRepository.GetAllVisitors();
            
        }

        public bool InsertVisitor(Visitor v)
        {

            if (visitorRepository.InsertVisitor(v) > 0)
            {

                return true;

            }
            else
            {

                return false;

            }

        }

        public bool UpdateVisitor(Visitor v)
        {

            if (visitorRepository.UpdateVisitor(v) > 0)
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
