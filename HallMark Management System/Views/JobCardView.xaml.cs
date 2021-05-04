using HallMark_Management_System.Models;
using HallMark_Management_System.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HallMark_Management_System.Views
{
    /// <summary>
    /// Interaction logic for JobCardView.xaml
    /// </summary>
    public partial class JobCardView : UserControl
    {

        private JobCardTableService jobCardTableService = new JobCardTableService();
        private ReceiptEntryMasterTableService receiptEntryMasterTableService = new ReceiptEntryMasterTableService();
        private ReceiptEntryThreadTableService receiptEntryThreadTableService = new ReceiptEntryThreadTableService();
        private PartyTableService partyTableService = new PartyTableService();
        private ProductTableService productTableService = new ProductTableService();

        public JobCardView()
        {
            InitializeComponent();
            initializeViewData();
        }


        private void initializeViewData()
        {
            List<JobCardModel> jobCardModel = jobCardTableService.findLatestData();

            foreach(JobCardModel eachData in jobCardModel)
            {
                job_card_no.Text = eachData.jobCardNo;
                sr_no.Text = Convert.ToString(eachData.id);
                initializeStaticData(eachData.jewellerID);
                initializeMainDataGrid(eachData.jewellerID);
            }
        }

        private void initializeStaticData(int receiveMasterID)
        {
            List<ReceiptEntryMasterModel> receiptEntryMasterData = receiptEntryMasterTableService.findByID(receiveMasterID);

            foreach(ReceiptEntryMasterModel eachData in receiptEntryMasterData)
            {
                List<PartyModel> partyDetails = partyTableService.findById(eachData.jeweller_id);
                foreach(PartyModel eachParty in partyDetails)
                {
                    jeweller_name.Text = eachParty.jewller_name;
                    break;
                }

                packing_date.Text = eachData.receipt_date;
                issue_voucher_no.Text = eachData.issue_voucher_no;
                delivery_by.Text = eachData.delivery_by;
                job_card_date.Text = eachData.receipt_date;
            }
        }

        private void initializeMainDataGrid(int receiveMasterID)
        {
            List<ReceiptEntryThreadModel> requriedThreadData = receiptEntryThreadTableService.findAll(receiveMasterID);
            List<ProductModel> partyDetails = productTableService.findAll();
            List<MainDataGrid> mainDataGrids = new List<MainDataGrid>();

            char increment = 'A';
            foreach(ReceiptEntryThreadModel eachData in requriedThreadData)
            {
                
                MainDataGrid mainDataGrid = new MainDataGrid();

                mainDataGrid.srNo = Convert.ToString(increment);

                foreach (ProductModel eachModel in partyDetails)
                {
                    if (eachModel.ID == eachData.jewllery_id)
                    {
                        mainDataGrid.NameofJewllery = eachModel.product_name;
                        mainDataGrid.DeclaredPurity = eachModel.purity;
                        break;
                    }
                }

                mainDataGrid.TotalPcs = eachData.total_pcs;
                mainDataGrid.GrossWt = eachData.gross_wt;
                mainDataGrid.NetWt = eachData.net_wt;
                mainDataGrid.MSPHCWt = eachData.msphc_wt;
                mainDataGrid.Remark = eachData.remark;
                increment++;
                mainDataGrids.Add(mainDataGrid);

            }
            mainJobCardDataGrid.ItemsSource = mainDataGrids;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }

    class MainDataGrid
    {
        public string srNo { get; set; }
        public string NameofJewllery { get; set; }

        public string TotalPcs { get; set; }
        public string DeclaredPurity { get; set; }
        public string GrossWt { get; set; }
        public string NetWt { get; set; }
        public string MSPHCWt { get; set; }
        public string Remark { get; set; }

    }
}
