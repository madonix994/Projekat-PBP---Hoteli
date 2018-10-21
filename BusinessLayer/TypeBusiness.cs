using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TypeBusiness
    {
        private TypeRepository typeRepository;


        public TypeBusiness()
        {
            this.typeRepository = new TypeRepository();
        }

        public List<Types> GetAllTypes()
        {
            return this.typeRepository.GetAllTypes();
            
        }

        public bool InsertType(Types t)
        {

            if (typeRepository.InsertType(t) > 0)
            {

                return true;

            }
            else
            {

                return false;

            }

        }

        public bool UpdateType(Types t)
        {

            if (typeRepository.UpdateType(t) > 0)
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
