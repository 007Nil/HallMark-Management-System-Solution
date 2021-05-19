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
                            gridData.finess = 0;
                            gridData.ag = "0.0";

                            gridData.cu = "0.0";
                            gridData.pb = "0.0";

                            gridData.ir = "0.00";
                            gridData.ru = "0.00";
                            gridData.cd = "0.00";

                            xrfGridData.Add(gridData);



                            break;
                        }

                    }
                }
            }

            mainXRFDataGrid.ItemsSource = xrfGridData;

            mainXRFDataGrid.CellEditEnding += this.gridDataCellEditEvent;


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

        private void DataGridRow_MouseDown(object sender, MouseButtonEventArgs e)
        {



        }

        private void gridDataCellEditEvent(object sender, DataGridCellEditEndingEventArgs e)
        {
            // Console.WriteLine("HIT");
            if (String.Equals("Finess", (string)mainXRFDataGrid.SelectedCells[0].Column.Header))
            {
                var cellInfo = mainXRFDataGrid.SelectedCells[0];
                var content = cellInfo.Column.GetCellContent(cellInfo.Item);
                try
                {
                    //Console.WriteLine(content);
                    float newFinessValue = float.Parse((String.Concat(content.ToString().Split(':')[1].Where(c => !Char.IsWhiteSpace(c)))));
                    //Console.WriteLine((mainXRFDataGrid.SelectedCells[0].Item as MainXRFDataGrid).finess);
                    float declearedPurityValue = (mainXRFDataGrid.SelectedCells[0].Item as MainXRFDataGrid).declaredPurity;
                    if (declearedPurityValue > newFinessValue)
                    {
                        //Console.WriteLine("R");
                        (mainXRFDataGrid.SelectedCells[0].Item as MainXRFDataGrid).result = "R";
                    }
                    else if (declearedPurityValue < newFinessValue)
                    {
                        Console.WriteLine(declearedPurityValue + 0.1);
                        Console.WriteLine(declearedPurityValue + 0.9);
                        Console.WriteLine("NEW " + newFinessValue);
                        if ((declearedPurityValue + 0.1 <= newFinessValue && declearedPurityValue + 0.9 >= newFinessValue))
                        {
                            Console.WriteLine("HIT");
                            (mainXRFDataGrid.SelectedCells[0].Item as MainXRFDataGrid).result = "W";
                        }
                        else if (String.Equals(Convert.ToString(declearedPurityValue + 0.1), Convert.ToString(newFinessValue))
                            || String.Equals(Convert.ToString(declearedPurityValue + 0.9), Convert.ToString(newFinessValue)))
                        {
                            Console.WriteLine("HIT ELSE");
                            (mainXRFDataGrid.SelectedCells[0].Item as MainXRFDataGrid).result = "W";
                        }
                        else
                        {
                            Console.WriteLine("HIT ELSE");
                            (mainXRFDataGrid.SelectedCells[0].Item as MainXRFDataGrid).result = "G";
                        }

                        //mainXRFDataGrid.Items.Refresh();
                    }

                    //(mainXRFDataGrid.SelectedCells[0].Item as MainXRFDataGrid).finess = newFinessValue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    
                }


            }

            if (String.Equals("IR\n %", (string)mainXRFDataGrid.SelectedCells[0].Column.Header))
            {
                var cellInfo = mainXRFDataGrid.SelectedCells[0];
                var content = cellInfo.Column.GetCellContent(cellInfo.Item);
                
                try
                {
                    float IRValue = float.Parse((String.Concat(content.ToString().Split(':')[1].Where(c => !Char.IsWhiteSpace(c)))));
                }
                catch
                {
                    Console.WriteLine("error");
                    
                    (mainXRFDataGrid.SelectedCells[0].Item as MainXRFDataGrid).remark = "0.0";
                }
            }

            if (String.Equals("Result", (string)mainXRFDataGrid.SelectedCells[0].Column.Header))
            {
                var cellInfo = mainXRFDataGrid.SelectedCells[0];
                var content = cellInfo.Column.GetCellContent(cellInfo.Item);

                string value = (String.Concat(content.ToString().Split(':')[1].Where(c => !Char.IsWhiteSpace(c))));

                if (!string.Equals("G", value))
                {
                    (mainXRFDataGrid.SelectedCells[0].Item as MainXRFDataGrid).result = " ";
                }
            }

            //Console.WriteLine(mainXRFDataGrid.SelectedCells[0].Column.Header.ToString());
        }
    }






    class MainXRFDataGrid
    {
        public string jobCardNo { get; set; }
        public string nameOfJewllery { get; set; }
        public float declaredPurity { get; set; }
        public float finess { get; set; }
        public string result { get; set; }
        public string ag { get; set; }
        public string cu { get; set; }
        public string pb { get; set; }
        public string ir { get; set; }
        public string ru { get; set; }
        public string cd { get; set; }
        public string remark { get; set; }

    }
}
