using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallMark_Management_System.Models
{
    class ReceiptEntryThreadModel
    {
        public int Id { get; set; }
        public int jewllery_id { get; set; }
        public int receipt_entry_master_id { get; set; }

        public string total_pcs { get; set; }
        public string gross_wt { get; set; }
        public string net_wt { get; set; }
        public string msphc_wt { get; set; }
        public string remark { get; set; }
    }
}
