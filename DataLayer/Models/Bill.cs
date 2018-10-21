using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Bill
    {
        public string Bill_Id { set; get; }
        public string PayWay { set; get; }
        public string Worker { set; get; }
        public int Cost { set; get; }
        public int Contract_Id { set; get; }

    }
}
