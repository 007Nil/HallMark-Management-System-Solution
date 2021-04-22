using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallMark_Management_System.ViewModels
{
    class FundReceiptPDFViewModel : Screen
    {
   
        private string type;
        private string date;
        private string name_of_jeweller;
        private string total_amount;
        private string cheque_no;
        private string cheque_date;
        private string bank_info;
        private string payment_info;
        private string bill_no;
        private string total_amount_number;
        public string Type { get => type; set => Set(ref type, value); }

        public string Date { get => date; set => Set(ref date, value); }

        public string NameOfJeweller { get => name_of_jeweller; set => Set(ref name_of_jeweller, value); }

        public string TotalAmount { get => total_amount; set => Set(ref total_amount, value); }

        public string ChequeNo { get => cheque_no; set => Set(ref cheque_no, value); }

        public string ChequeDate { get => cheque_date; set => Set(ref cheque_date, value); }

        public string BankInfo { get => bank_info; set => Set(ref bank_info, value); }

        public string PaymentInfo { get => payment_info; set => Set(ref payment_info, value); }

        public string BillNo { get => bill_no; set => Set(ref bill_no, value); }

        public string TotalAmountNumber { get => total_amount_number; set => Set(ref total_amount_number, value); }


    }
}
