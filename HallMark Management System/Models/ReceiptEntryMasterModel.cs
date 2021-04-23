using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallMark_Management_System.Models
{
    public class ReceiptEntryMasterModel
    {
        public int Id { get; set; }

        public int jeweller_id { get; set; }

        public string receipt_date { get; set; }

        public string issue_voucher_no { get; set; }
        public string delivery_by { get; set; }
        public string delivery_date { get; set; }
        public string box_no { get; set; }
        public string previous_box_no { get; set; }
        public string customer_name { get; set; }
        public Boolean ILC_receipt { get; set; }



    }
}
