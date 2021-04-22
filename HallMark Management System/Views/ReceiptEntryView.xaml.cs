using Dapper;
using HallMark_Management_System.Models;
using HallMark_Management_System.Service;
using HallMark_Management_System.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
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
using System.Windows.Threading;

namespace HallMark_Management_System.Views
{
    /// <summary>
    /// Interaction logic for ReceiptEntryView.xaml
    /// </summary>
    public partial class ReceiptEntryView : UserControl,INotifyCollectionChanged
    {

        private PartyTableService partyService = new PartyTableService();
        private int sumTotalPcs = 0;
        private int sumGrossWt = 0;
        private int sumNetWt = 0;
        private int sumMSPHCWt = 0;
        public ReceiptEntryView()
        {
            InitializeComponent();

            initializeGridtable();
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public Session session = new Session();

        private void initializeGridtable()
        {
            ObservableCollection<GridData> gridDataList = new ObservableCollection<GridData>();
            GridData gdata = new GridData();
            if (gridData.Items.Count == 0)
            {
                gdata.srNo = "1";
                gridDataList.Add(gdata);
            }
            else
            {
                Console.WriteLine("HIT ELSE");
            }

            gridData.ItemsSource = gridDataList;

            gridData.CellEditEnding += gridDataCellEditEvent;
        }

      

        private void ClickonDataGrid(object sender, RoutedEventArgs e)
        {
             
            Console.WriteLine("HIT ON ClickOnDataGrid");
            if (gridData.SelectedCells.Count == 1)
            {
                Console.WriteLine("HIT ANYWAY");
                if (string.Equals("Name of Jewllery", (string)gridData.SelectedCells[0].Column.Header))
                {
                    //showJeweller(sender);
                    // Method show enable F2 for user
                    session.isGridClick = true;

                }
            }
        }

        private void JewlleryGridExceptionAlert()
        {
            MessageBox.Show("Only Numbers allowed !!");
        }

        /*
         * gridDataCellEditEvent functuin will calcluate the toal for given values 
         * 
         */
        private void gridDataCellEditEvent(object sender, DataGridCellEditEndingEventArgs e)
        {
            
           /* Console.WriteLine("HIT GRID DATA");
            Console.WriteLine((string)gridData.SelectedCells[0].Column.Header);*/
            if (string.Equals("Total Pcs.", (string)gridData.SelectedCells[0].Column.Header))
            {
             
                var cellInfo = gridData.SelectedCells[0];

                var content = cellInfo.Column.GetCellContent(cellInfo.Item);
                try {
                    sumTotalPcs += Int32.Parse(String.Concat(content.ToString().Split(':')[1].Where(c => !Char.IsWhiteSpace(c))));
                }catch(Exception ex)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.JewlleryGridExceptionAlert));
                    sumTotalPcs += 0;
                }

                sumOfTotalPcs.Text = Convert.ToString(sumTotalPcs);


            }
            else if (string.Equals("Gross Wt.", (string)gridData.SelectedCells[0].Column.Header))
            {
                //Console.WriteLine("CLICK ON Gross Wt.");
                var cellInfo = gridData.SelectedCells[0];

                var content = cellInfo.Column.GetCellContent(cellInfo.Item);
                try
                {
                    sumGrossWt += Int32.Parse(String.Concat(content.ToString().Split(':')[1].Where(c => !Char.IsWhiteSpace(c))));
                }
                catch(Exception ex)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.JewlleryGridExceptionAlert));
                    sumGrossWt += 0;
                }

                sumOfGrossWt.Text = Convert.ToString(sumGrossWt);

                //Console.WriteLine(content);
            }
            else if (string.Equals("Net Wt.", (string)gridData.SelectedCells[0].Column.Header))
            {
                // Console.WriteLine("CLICK ON Net Wt.");
                var cellInfo = gridData.SelectedCells[0];

                var content = cellInfo.Column.GetCellContent(cellInfo.Item);
                try
                {
                    sumNetWt += Int32.Parse(String.Concat(content.ToString().Split(':')[1].Where(c => !Char.IsWhiteSpace(c))));
                }
                catch(Exception ex)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.JewlleryGridExceptionAlert));
                    sumNetWt += 0;
                }

                sumOfNetWt.Text = Convert.ToString(sumNetWt);
            }
            else if (string.Equals("MSPHC Wt.", (string)gridData.SelectedCells[0].Column.Header))
            {
                //  Console.WriteLine("CLICK ON MSPHC Wt.");
                var cellInfo = gridData.SelectedCells[0];

                var content = cellInfo.Column.GetCellContent(cellInfo.Item);
                try
                {
                    sumMSPHCWt += Int32.Parse(String.Concat(content.ToString().Split(':')[1].Where(c => !Char.IsWhiteSpace(c))));
                }
                catch(Exception ex)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.JewlleryGridExceptionAlert));
                    sumMSPHCWt += 0;
                }

                sumOfMSPHSWt.Text = Convert.ToString(sumMSPHCWt);
            }
       
        }

        private void showJeweller(object sender)
        {
            var cell = sender as DataGridCell;

            if (cell != null && cell.Content is TextBlock)
            {
                Console.WriteLine(cell.Content);
                var textBlock = cell.Content as TextBlock;
                textBlock.SetCurrentValue(TextBlock.TextProperty, "put your text here");
                var binding = BindingOperations.GetBindingExpression(textBlock, TextBlock.TextProperty);
                binding.UpdateSource();
            }
        }

        private IEnumerable<DataGridRow> GetDataGridRowsForButtons(DataGrid grid)
        { //IQueryable
            //Console.WriteLine("HIT HERE");
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;

            foreach (var item in itemsSource)
            {
                //Console.WriteLine("HIT HERE");
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row & row.IsSelected) yield return row;
            }
        }



        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Console.WriteLine("CLICKED ON F2");
            //Console.WriteLine(e);
            if (session.isGridClick)
            {
                //Grid Code
                //Console.WriteLine("TRUE");

                if (jewlleryDetailsGrid.Visibility == Visibility.Hidden)
                {
                    jewlleryDetailsGrid.Visibility = Visibility.Visible;
                    Panel.SetZIndex(jewlleryDetailsGrid, 1);

                    List<ProductModel> productList = findAllProduct();

                    List<jewelleryModal> jewelleryModal = new List<jewelleryModal>();

                    foreach (ProductModel each_item in productList)
                    {
                        jewelleryModal.Add(new Views.jewelleryModal() { jewlleryName = each_item.product_name, purity = each_item.purity });
                    }

                    jewlleryDetailsGrid.ItemsSource = jewelleryModal;
                }
                



            }
            else
            {
                // Jewller Code
                //Console.WriteLine("False");
                if (JewllerInformationBorder.Visibility == Visibility.Hidden)
                {
                    JewllerInformationBorder.Visibility = Visibility.Visible;
                    Panel.SetZIndex(JewllerInformationBorder, 1);

                    List<PartyModel> partyModel = partyService.findAllData();

                    List<JewellerDetailsDataGrid> jewellerDetailsDataGrids = new List<JewellerDetailsDataGrid>();
                    //Console.WriteLine(partyModel.Count);
                    foreach (PartyModel eachData in partyModel)
                    {
                        jewellerDetailsDataGrids.Add(new JewellerDetailsDataGrid() { jewller_name = eachData.jewller_name,
                            cml_no = eachData.cml_no, gst_no = eachData.gst_no,address = eachData.address });
                    }

                    jewellerDetailsDataGrid.ItemsSource = jewellerDetailsDataGrids;



                }
            }
        }

       // private List<ProductModel> allProducts = new List<ProductModel>();

        private List<ProductModel> findAllProduct()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var queryResult = cnn.Query<ProductModel>("select * from Product_table", new DynamicParameters());
                return queryResult.ToList();
            }
        }

        private void name_of_jeweller_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("I GOT CLCKED");
            session.isGridClick = false;
        }


        private static String LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private void jewlleryDetailsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            String jewlleryName = "";
            Double purity = 0.0;
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    //Console.WriteLine("Into FOR LOOP");
                    var rows = GetDataGridRowsForButtons(jewlleryDetailsGrid);
                    //Console.WriteLine("AFTER FOR LOOP");
                    foreach (DataGridRow dr in rows)
                    {
                        //Console.WriteLine("INTO FOREACH");
                        try
                        {
                            //id = (dr.Item as ModalModel).id;
                            jewlleryName = (dr.Item as jewelleryModal).jewlleryName;
                            purity = Convert.ToDouble((dr.Item as jewelleryModal).purity);
                        }
                        catch (Exception ex)
                        {
                            return;
                        }
                        //Console.WriteLine(jeweller);
                        break;
                    }

                }

        //    Console.WriteLine(gridData.SelectedItems);
           (gridData.SelectedCells[0].Item as GridData).nameOfJewllery = jewlleryName;
           (gridData.SelectedCells[0].Item as GridData).declearedPurity = (float)purity;

            gridData.Items.Refresh();

            jewlleryDetailsGrid.Visibility = Visibility.Hidden;
            Panel.SetZIndex(jewlleryDetailsGrid, -1);


            /*  cellInfo.Column.SetCurrentValue(TextBlock.TextProperty,jewlleryName);
              var binding = BindingOperations.GetBindingExpression(cellInfo.Column, TextBlock.TextProperty);*/
            //binding.UpdateSource();


        }

        private void gridData_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            e.NewItem = new GridData
            {
                srNo = String.Concat(sender.ToString().Split(':')[1].Where(c => !Char.IsWhiteSpace(c)))
            };
        }

        private void jewellerDetailsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            Console.WriteLine("HIT");
            String nameOfJewller = "";
            string localCml_no = "";
            string localGts_no = "";
            string locaAddress = "";

            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    //Console.WriteLine("Into FOR LOOP");
                    var rows = GetDataGridRowsForButtons(jewellerDetailsDataGrid);
                    Console.WriteLine("AFTER FOR LOOP");
                    foreach (DataGridRow dr in rows)
                    {
                        Console.WriteLine("INTO FOREACH");
                        try
                        {
                            //id = (dr.Item as ModalModel).id;
                           /* jewlleryName = (dr.Item as jewelleryModal).jewlleryName;
                            purity = Convert.ToDouble((dr.Item as jewelleryModal).purity);*/
                            nameOfJewller = (dr.Item as JewellerDetailsDataGrid).jewller_name;
                            localCml_no = (dr.Item as JewellerDetailsDataGrid).cml_no;
                            localGts_no = (dr.Item as JewellerDetailsDataGrid).gst_no;
                            locaAddress = (dr.Item as JewellerDetailsDataGrid).address;

                        }
                        catch (Exception ex)
                        {
                            return;
                        }
                        //Console.WriteLine(jeweller);
                        break;
                    }

                }

            if (!String.IsNullOrEmpty(nameOfJewller) && !String.IsNullOrEmpty(localCml_no))
            {
                name_of_jeweller.Text = nameOfJewller;
                address.Text = locaAddress;
                cml_no.Text = localCml_no;
                gst_no.Text = localGts_no;

                JewllerInformationBorder.Visibility = Visibility.Hidden;
                Panel.SetZIndex(JewllerInformationBorder, -1);

            }
        }

        private void Button_Close_jewellerDetailsDataGrid_Click(object sender, RoutedEventArgs e)
        {
            JewllerInformationBorder.Visibility = Visibility.Hidden;
            Panel.SetZIndex(JewllerInformationBorder, -1);
        }
    }

    public class GridData
    {
        public String srNo { get; set; }
        public string nameOfJewllery { get; set; }
        public float totalPcs { get; set; }
        public float declearedPurity { get; set; }

        public float grossWt { get; set; }
        public float netWt { get; set; }
        public float msphcWt { get; set; }
        public string remark { get; set; }

        public static implicit operator List<object>(GridData v)
        {
            throw new NotImplementedException();
        }
    }

    public class jewelleryModal
    {
        public string jewlleryName { get; set; }
        public string purity { get; set; }
    }

    public class Session
    {
        public bool isGridClick { get; set; }
    }

    public class JewellerDetailsDataGrid
    {
        public String jewller_name { get; set; }

        public String cml_no { get; set; }

        public String gst_no { get; set; }

        public string address { get; set; }
    }
}
