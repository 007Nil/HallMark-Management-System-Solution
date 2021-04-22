using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallMark_Management_System.Models
{
    class FundEntryModel
    {
        public int ID { get; set; }
        public int transaction_type { get; set; }
        public int type { get; set; }
        public int jeweller_id { get; set; }
        public float net_amount { get; set; }
        public string cheque_no { get; set; }
        public string cheque_date { get; set; }
        public int bank_id { get; set; }
        public string bill_no { get; set; }
        public string bill_date { get; set; }
        public string remarks { get; set; }

    }
}
