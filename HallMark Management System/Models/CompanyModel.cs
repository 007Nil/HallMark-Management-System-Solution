using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallMark_Management_System.Models
{
    public class CompanyModel
    {

        public int ID { get; set; }
        public String customer_name { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String pin { get; set; }
        public String state { get; set; }
        public String mobile { get; set; }
        public String phone_0 { get; set; }
        public String phone_1 { get; set; }
        public String email { get; set; }

        public String gst_no { get; set; }
        public String pan_no { get; set; }
        public String place_of_supply { get; set; }
        public String state_code { get; set; }
        public String license_no { get; set; }

        public String invoice_code { get; set; }

        public override string ToString()
        {
            return customer_name + " " + Address + " " + City+ " "+ pin+ " "+ state+" "+ mobile+ " "+ phone_0+" "+
               phone_1+" "+ email+" "+ gst_no+" "+ pan_no+" "+ place_of_supply+" "+ state_code+" "+ license_no+" "+ invoice_code;
        }
    }



}
