using Caliburn.Micro;
using HallMark_Management_System.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallMark_Management_System.ViewModels
{
    class ReceiptEntryViewModel : Screen
    {

        private System.Collections.IEnumerable jewlleryDetails;

        public System.Collections.IEnumerable JewlleryDetails { get => jewlleryDetails; set => Set(ref jewlleryDetails, value); }

        private string sumOfToatlPcs1;

        public string sumOfToatlPcs { get => sumOfToatlPcs1; set => Set(ref sumOfToatlPcs1, value); }
        //  public ObservableCollection<GridData> GridData { get; set; }
    }
}
