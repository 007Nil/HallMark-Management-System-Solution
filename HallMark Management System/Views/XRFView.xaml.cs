using HallMark_Management_System.Models;
using HallMark_Management_System.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
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
    /// Interaction logic for XRFView.xaml
    /// </summary>
    public partial class XRFView : UserControl
    {

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private JobCardTableService jobCardTableService = new JobCardTableService();
        private ReceiptEntryThreadTableService receiptEntryThreadTableService = new ReceiptEntryThreadTableService();
        private PartyTableService partyTableService = new PartyTableService();
        private ProductTableService productTableService = new ProductTableService();
        private System.Random random = new System.Random();
        public XRFView()
        {
            InitializeComponent();
            loadStartUpData();
        }

        private void loadStartUpData()
        {
            correction_factor.Text = "";
            List<JobCardModel> latestJobCardData = jobCardTableService.findLatestData();
            foreach (JobCardModel eachData in latestJobCardData)
            {
                job_card_no.Text = eachData.jobCardNo;
                initializeMainDataGrid(eachData.jewellerID, eachData.jobCardNo);
                break;
            }

        }


        private void initializeMainDataGrid(int masterID, string jobcardNo)
        {
            List<int> eachItemTotal = new List<int>();
            List<ReceiptEntryThreadModel> threadData = receiptEntryThreadTableService.findAll(masterID);

            List<MainXRFDataGrid> xrfGridData = new List<MainXRFDataGrid>();

            foreach (ReceiptEntryThreadModel eachData in threadData)
            {
                for (int i = 1; i <= Int32.Parse(eachData.total_pcs); i++)
                {
                    MainXRFDataGrid gridData = new MainXRFDataGrid();
                    //xrfGridData.Add(new MainXRFDataGrid() { jobCardNo = jobcardNo , nameOfJewllery = partyTableService.findById })

                    foreach (ProductModel eachParty in productTableService.findAll())
                    {
                        if (eachData.jewllery_id == eachParty.ID)
                        {
                            gridData.jobCardNo = jobcardNo;
                            gridData.nameOfJewllery = eachParty.product_name;
                            gridData.declaredPurity = float.Parse(eachParty.purity);
                            gridData.pb = "0.0";

                            xrfGridData.Add(gridData);



                            break;
                        }

                    }
                }
            }

            mainXRFDataGrid.ItemsSource = xrfGridData;


        }

        private string generateRandomNumber()
        {
            //Console.WriteLine("I am Called");
            
            int value = random.Next(0, 5);
            //double val = 0.0;
            //Console.WriteLine(value);

            double val = (random.NextDouble() * (4.0 - value) + value);

            Console.WriteLine(String.Format("{0:0.#}", (float)val));

            return String.Format("{0:0.#}", (float)val);
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            //Console.WriteLine("F5 Pressed");

            mainXRFDataGrid.SelectAllCells();
            for (int i = 0; i < mainXRFDataGrid.SelectedCells.Count - 11; i++)
            {
                //Console.WriteLine("Before"+generateRandomNumber());
                try
                {
                    if (String.Equals(mainXRFDataGrid.SelectedCells[i].Column.Header.ToString(), "Result"))
                    {
                        try
                        {
                            (mainXRFDataGrid.SelectedCells[i].Item as MainXRFDataGrid).result = "G";
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(i);
                        }


                    }

                    if (String.Equals(mainXRFDataGrid.SelectedCells[i].Column.Header.ToString(), "Finess"))
                    {
                        //Console.WriteLine(generateRandomNumber());
                        (mainXRFDataGrid.SelectedCells[i].Item as MainXRFDataGrid).finess = (mainXRFDataGrid.SelectedCells[i].Item as MainXRFDataGrid).declaredPurity
                                                                                             + float.Parse(this.generateRandomNumber());
                    }
                }
                catch (Exception ex)
                {

                }


            }

            mainXRFDataGrid.UnselectAllCells();

            mainXRFDataGrid.Items.Refresh();

        }

        private void correction_factor_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.Handled = !IsTextAllowed(correction_factor.Text);

            try
            {
                if (!String.IsNullOrEmpty(correction_factor.Text))
                {
                    Console.WriteLine(correction_factor.Text);
                }
                else if (String.IsNullOrWhiteSpace(correction_factor.Text) ||
                    String.IsNullOrEmpty(correction_factor.Text))
                {
                    Console.WriteLine(correction_factor.Text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void correction_factor_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            Console.WriteLine("HIT");
            //  Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.alter));
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    //Console.WriteLine("HIT");
                    e.CancelCommand();
                    correction_factor.Text = "";
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
    }






    class MainXRFDataGrid
    {
        public string jobCardNo { get; set; }
        public string nameOfJewllery { get; set; }
        public float declaredPurity { get; set; }
        public float finess { get; set; }
        public string result { get; set; }
        public float ag { get; set; }
        public float cu { get; set; }
        public string pb { get; set; }
        public float ir { get; set; }
        public float ru { get; set; }
        public double cd { get; set; }
        public string remark { get; set; }

    }
}
