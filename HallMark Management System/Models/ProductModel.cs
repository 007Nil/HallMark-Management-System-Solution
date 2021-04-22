using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallMark_Management_System.Models
{
    public class ProductModel
    {
        public int ID { get; set; }

        public String product_name { get; set; }
        public string purity { get; set; }
        public int sampling_method { get; set; }

    }
}
