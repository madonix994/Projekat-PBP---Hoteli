using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Apartment
    {

        public int Apartment_Number { set; get; }
        public int Apartment_Floor_Number { set; get; }
        public int Apartment_Bed_Number { set; get; }
        public string Hotel_Id { set; get; }
        public string Type_Id { set; get; }
        
    }
}
