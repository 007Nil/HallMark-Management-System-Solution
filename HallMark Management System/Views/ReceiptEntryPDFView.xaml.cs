using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HallMark_Management_System.Models;
using HallMark_Management_System.Service;

namespace HallMark_Management_System.Views
{
    /// <summary>
    /// Interaction logic for ReceiptEntryPDFView.xaml
    /// </summary>
    public partial class ReceiptEntryPDFView : Window
    {
        private ProductTableService productTableService = new ProductTableService();
        private CompanyTableService CompanyTableService = new CompanyTableService();
        private PartyTableService PartyTableService = new PartyTableService();
        public ReceiptEntryPDFView()
        {
            InitializeComponent();
        }

        public void GetPDFData(List<ReceiptEntryMasterModel> receiptEntryMasterModels, List<ReceiptEntryThreadModel> receiptEntryThreadModels)
        {

            

            List<CompanyModel> allData = CompanyTableService.findAll();

            foreach(CompanyModel eachData in allData)
            {
                companyGSTNo.Text = eachData.gst_no;
                companyName.Text = eachData.customer_name;

                break;
            }


            foreach (ReceiptEntryMasterModel eachData in receiptEntryMasterModels)
            {

                reciptNo.Text = "Recipt No: " + Convert.ToString(eachData.Id);
                foreach (PartyModel eachParty in PartyTableService.findAllData())
                {
                    if (eachData.jeweller_id == eachParty.ID)
                    {
                        customer_name.Text = "Customer Name: " + eachParty.jewller_name;
                        customer_address.Text = ("Address: " + eachParty.address).Replace('\n',',').Replace('\r',' ');
                        customer_gst_no.Text = eachParty.gst_no;
                        cmlNo.Text = "CML/NO: " + eachParty.cml_no;
                        break;
                    }
                }

                receiptDataandTime.Text = "Date and Time: " + eachData.receipt_date;
             //reciptNo.Text = eachData.
            }





            // Preparing Grid Data
            List<ThreadDataGridModel> threadDataGridData = new List<ThreadDataGridModel>();
            List<ProductModel> allProduct = productTableService.findAll();
            int sumTotal = 0;
            float sumGrossWt = 0;
            float hallmarkTotal = 0;
            float puritySum = 0;
            int i = 0;
            foreach(ReceiptEntryThreadModel eachData in receiptEntryThreadModels)
            {
                i++;
                ThreadDataGridModel singleData = new ThreadDataGridModel();

                singleData.sr_no = Convert.ToString(i);
                foreach(ProductModel eachProduct in allProduct)
                {
                    if (eachProduct.ID == eachData.jewllery_id)
                    {
                        singleData.description = eachProduct.product_name;
                        singleData.purity = eachProduct.purity;

                        puritySum += float.Parse(eachProduct.purity);
                        break;
                    }
                }
                singleData.customer_wt = eachData.gross_wt;
                singleData.no_of_pices = eachData.total_pcs;
                singleData.hallmark_wt = eachData.msphc_wt;
                singleData.remark = eachData.remark;

                sumTotal += Int16.Parse(eachData.total_pcs);

                sumGrossWt += float.Parse(eachData.gross_wt);

                hallmarkTotal += float.Parse(eachData.msphc_wt);

                threadDataGridData.Add(singleData);
                
            }

            sumofPurity.Text = Convert.ToString(puritySum);
            hallmarkSum.Text = Convert.ToString(hallmarkTotal);
            grossWtSum.Text = Convert.ToString(sumGrossWt);
            sunofTotal.Text = Convert.ToString(sumTotal);

            ThreadDataGrid.ItemsSource = threadDataGridData;

        }

        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            // We may have already set the LayoutTransform to a ScaleTransform.
            // If not, do so now.

            var scaler = PDFGrid.LayoutTransform as ScaleTransform;

            if (scaler == null)
            {
                scaler = new ScaleTransform(1.0, 1.0);
                PDFGrid.LayoutTransform = scaler;
            }

            // We'll need a DoubleAnimation object to drive
            // the ScaleX and ScaleY properties.

            DoubleAnimation animator = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromMilliseconds(600)),
            };

            // Toggle the scale between 1.0 and 1.5.

            if (scaler.ScaleX == 1.0)
            {
                animator.To = 1.5;
            }
            else
            {
                animator.To = 1.0;
            }

            scaler.BeginAnimation(ScaleTransform.ScaleXProperty, animator);
            scaler.BeginAnimation(ScaleTransform.ScaleYProperty, animator);
        }
    }

    class ThreadDataGridModel
    {
        public string sr_no { get; set; }
        public string description { get; set; }
        public string no_of_pices { get; set; }
        public string customer_wt { get; set; }
        public string hallmark_wt { get; set; }
        public string purity { get; set; }
        public string remark { get; set; }


    }
}
