using Dapper;
using HallMark_Management_System.Models;
using HallMark_Management_System.Service;
using HallMark_Management_System.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class ReceiptEntryView : UserControl, INotifyCollectionChanged
    {

        private PartyTableService partyService = new PartyTableService();
        private ReceiptEntryMasterTableService receiptEntryMasterTableService = new ReceiptEntryMasterTableService();
        private ReceiptEntryThreadTableService receiptEntryThreadTableService = new ReceiptEntryThreadTableService();
        private ProductTableService productTableService = new ProductTableService();



        public ReceiptEntryView()
        {
            InitializeComponent();
            SetSrNo();
            initializeGridtable();
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public Session session = new Session();

        public string SetSrNo()
        {
            List<String> reversedIds = receiptEntryMasterTableService.findAllIdReverse();

            if (reversedIds.Count == 0)
            {
                sr_no.Text = "1";
            }
            else
            {
                foreach (String eachId in reversedIds)
                {
                    sr_no.Text = Convert.ToString(Int32.Parse(eachId) + 1);
                    break;
                }
            }
            return "";
        }

        private void initializeGridtable()
        {
            gridData.ItemsSource = null;
            ObservableCollection<GridData> gridDataList = new ObservableCollection<GridData>();
            GridData gdata = new GridData();
            if (gridData.Items.Count == 0)
            {
                gdata.srNo = "1";
                gdata.masterId = sr_no.Text;
                gdata.id = 0;


                gridDataList.Add(gdata);
            }

            ReceiptEntryViewModel vm = new ReceiptEntryViewModel
            {
                gridDataList = gridDataList
            };

            this.DataContext = vm;

            gridData.ItemsSource = gridDataList;

            gridData.CellEditEnding += gridDataCellEditEvent;
        }



        private void ClickonDataGrid(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine(sender.ToString());
            //(sender as DataGrid.SelectedCells[0])
            //Console.WriteLine(gridData.SelectedCells.Count);
            //Console.WriteLine();
            if (gridData.SelectedCells.Count == 1)
            {
                //Console.WriteLine("HIT ANYWAY");
                if (string.Equals("Name of Jewllery", (string)gridData.SelectedCells[0].Column.Header))
                {
                    //showJeweller(sender);
                    // Method show enable F2 for user
                    session.isGridClick = true;
                    //gridData.SelectionUnit = DataGridSelectionUnit.Cell;

                }
                if ((string.Equals("SrNo", (string)gridData.SelectedCells[0].Column.Header)))
                {
                    //Console.WriteLine("HIT");
                    //Console.WriteLine(gridData.Columns.Single(c => c.Header.ToString() == "Remark").DisplayIndex);

                    gridData.SelectionUnit = DataGridSelectionUnit.FullRow;
                    //gridData.Columns[1].RowS = 
                }
            }
            else
            {

                if (!(string.Equals("SrNo", (string)gridData.CurrentCell.Column.Header)))
                {
                    gridData.SelectionUnit = DataGridSelectionUnit.Cell;
                }
                /* for (int i = 0; i < gridData.SelectedCells.Count; i++)
                 {
                     Console.WriteLine(gridData.CurrentCell.Column.Header);
                     //Console.WriteLine(gridData.SelectedCells[i].Column.Header);
                     if (gridData.SelectedCells[i].Column.Header)
                 }*/
            }
        }


        private void JewlleryGridExceptionAlert()
        {
            MessageBox.Show("Only Numbers allowed !!");
        }

        private void DataSavedAlert()
        {
            MessageBox.Show("Data Saved !!");

        }

        private void DataNotSaved()
        {
            MessageBox.Show("Data Not Saved, Please fill up the from with proper details");

        }

        private void DataUpdatedAlert()
        {
            MessageBox.Show("Data Updated");

        }

        private void DataNotSavedAlert()
        {
            MessageBox.Show("Please Save Data First");

        }

        /*
         * gridDataCellEditEvent functuin will calcluate the toal for given values 
         * and saved the dynamic data on model
         * 
         */
        private void gridDataCellEditEvent(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (string.Equals("Total Pcs.", (string)gridData.SelectedCells[0].Column.Header))
            {
                int sumTotalPcs = 0;
                var cellInfo = gridData.SelectedCells[0];
                var content = cellInfo.Column.GetCellContent(cellInfo.Item);
                try
                {
                    (gridData.SelectedCells[0].Item as GridData).totalPcs = Convert.ToInt32(String.Concat(content.ToString().Split(':')[1].Where(c => !Char.IsWhiteSpace(c))));
                    foreach (GridData eachdata in gridData.ItemsSource.OfType<GridData>().ToList())
                    {
                        sumTotalPcs += Convert.ToInt32(eachdata.totalPcs);
                    }
                }
                catch (Exception ex)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.JewlleryGridExceptionAlert));
                    sumTotalPcs += 0;
                }

                sumOfTotalPcs.Text = Convert.ToString(sumTotalPcs);
            }
            else if (string.Equals("Gross Wt.", (string)gridData.SelectedCells[0].Column.Header))
            {
                //Console.WriteLine("CLICK ON Gross Wt.");
                double sumGrossWt = 0.0;
                var cellInfo = gridData.SelectedCells[0];
                var content = cellInfo.Column.GetCellContent(cellInfo.Item);
                try
                {
                    (gridData.SelectedCells[0].Item as GridData).grossWt = Convert.ToDouble(String.Concat(content.ToString().Split(':')[1].Where(c => !Char.IsWhiteSpace(c))));

                    foreach (GridData eachdata in gridData.ItemsSource.OfType<GridData>().ToList())
                    {
                        sumGrossWt += eachdata.grossWt;
                    }
                }
                catch (Exception ex)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.JewlleryGridExceptionAlert));
                    sumGrossWt += 0.0;
                }

                sumOfGrossWt.Text = Convert.ToString(sumGrossWt);

                //Console.WriteLine(content);
            }
            else if (string.Equals("Net Wt.", (string)gridData.SelectedCells[0].Column.Header))
            {
                double sumNetWt = 0.0;

                try
                {
                    var cellInfo = gridData.SelectedCells[0];
                    var content = cellInfo.Column.GetCellContent(cellInfo.Item);
                    (gridData.SelectedCells[0].Item as GridData).NetWt = Convert.ToDouble(String.Concat(content.ToString().Split(':')[1].Where(c => !Char.IsWhiteSpace(c))));
                    foreach (GridData eachdata in gridData.ItemsSource.OfType<GridData>().ToList())
                    {
                        sumNetWt += eachdata.NetWt;
                        Console.WriteLine(eachdata.NetWt);
                    }

                    sumOfNetWt.Text = Convert.ToString(sumNetWt);
                }
                catch (Exception ex)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.JewlleryGridExceptionAlert));
                    sumNetWt += 0.0;
                }
            }
            else if (string.Equals("MSPHC Wt.", (string)gridData.SelectedCells[0].Column.Header))
            {
                //  Console.WriteLine("CLICK ON MSPHC Wt.");
                var cellInfo = gridData.SelectedCells[0];
                double sumMSPHCWt = 0;
                var content = cellInfo.Column.GetCellContent(cellInfo.Item);

                try
                {
                    (gridData.SelectedCells[0].Item as GridData).msphcWt = Convert.ToDouble(String.Concat(content.ToString().Split(':')[1].Where(c => !Char.IsWhiteSpace(c))));

                    foreach (GridData eachdata in gridData.ItemsSource.OfType<GridData>().ToList())
                    {
                        sumMSPHCWt += eachdata.msphcWt;
                    }
                    sumOfMSPHSWt.Text = Convert.ToString(sumMSPHCWt);
                }
                catch (Exception ex)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.JewlleryGridExceptionAlert));
                    sumMSPHCWt += 0;
                }


            }
            else if (string.Equals("Remark", (string)gridData.SelectedCells[0].Column.Header))
            {
                try
                {
                    var cellInfo = gridData.SelectedCells[0];
                    var content = cellInfo.Column.GetCellContent(cellInfo.Item);
                    (gridData.SelectedCells[0].Item as GridData).remark = String.Concat(content.ToString().Split(':')[1].Where(c => !Char.IsWhiteSpace(c)));
                }
                catch (Exception ex)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.JewlleryGridExceptionAlert));
                }

            }
            else if (string.Equals("SrNo", (string)gridData.SelectedCells[0].Column.Header))
            {
                //gridData.Items.Remove(gridData.SelectedItem);
            }


        }

        /*        private void showJeweller(object sender)
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
                }*/

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Console.WriteLine("CLICKED ON F2");
            //Console.WriteLine(e);
            if (session.isGridClick)
            {
                //Grid Code
                //Console.WriteLine("TRUE");

                if (jewlleryDetailsBorder.Visibility == Visibility.Hidden)
                {
                    jewlleryDetailsBorder.Visibility = Visibility.Visible;
                    Panel.SetZIndex(jewlleryDetailsBorder, 1);
                    this.SetJewllerGridData();
                }

            }
            else
            {
                // Jewller Code
                //Console.WriteLine("False");
                if (JewllerInformationBorder.Visibility == Visibility.Hidden)
                {
                    JewllerInformationBorder.Visibility = Visibility.Visible;
                    Panel.SetZIndex(JewllerInformationBorder, 11);

                    List<PartyModel> partyModel = partyService.findAllData();

                    List<JewellerDetailsDataGrid> jewellerDetailsDataGrids = new List<JewellerDetailsDataGrid>();
                    //Console.WriteLine(partyModel.Count);
                    foreach (PartyModel eachData in partyModel)
                    {
                        jewellerDetailsDataGrids.Add(new JewellerDetailsDataGrid()
                        {
                            jewller_name = eachData.jewller_name,
                            cml_no = eachData.cml_no,
                            gst_no = eachData.gst_no,
                            address = eachData.address,
                            Id = eachData.ID
                        });
                    }

                    jewellerDetailsDataGrid.ItemsSource = jewellerDetailsDataGrids;



                }
            }
        }

        // private List<ProductModel> allProducts = new List<ProductModel>();

        private void SetJewllerGridData()
        {
            List<ProductModel> productList = findAllProduct();

            List<jewelleryModal> jewelleryModal = new List<jewelleryModal>();

            foreach (ProductModel each_item in productList)
            {
                jewelleryModal.Add(new Views.jewelleryModal()
                {
                    jewlleryName = each_item.product_name,
                    purity = each_item.purity
                ,
                    Id = each_item.ID
                });
            }

            jewlleryDetailsGrid.ItemsSource = jewelleryModal;
        }

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
            //Console.WriteLine("I GOT CLCKED");
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
            String productTableID = "";
            /*            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
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
                                        productTableID = Convert.ToString((dr.Item as jewelleryModal).Id);
                                    }
                                    catch (Exception ex)
                                    {
                                        return;
                                    }
                                    break;
                                }

                            }*/

            jewelleryModal selectedData = jewlleryDetailsGrid.SelectedItem as jewelleryModal;

            jewlleryName = selectedData.jewlleryName;
            purity = Convert.ToDouble(selectedData.purity);
            productTableID = Convert.ToString(selectedData.Id);

            //    Console.WriteLine(gridData.SelectedItems);
            (gridData.SelectedCells[0].Item as GridData).nameOfJewllery = jewlleryName;
            (gridData.SelectedCells[0].Item as GridData).declearedPurity = (float)purity;
            Console.WriteLine(productTableID);
            (gridData.SelectedCells[0].Item as GridData).productTableID = productTableID;

            gridData.Items.Refresh();

            jewlleryDetailsBorder.Visibility = Visibility.Hidden;
            Panel.SetZIndex(jewlleryDetailsBorder, -1);
        }

        private void gridData_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            e.NewItem = new GridData
            {
                srNo = String.Concat(sender.ToString().Split(':')[1].Where(c => !Char.IsWhiteSpace(c))),
                masterId = sr_no.Text
            };
        }

        private void jewellerDetailsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Console.WriteLine("HIT");
            String nameOfJewller = "";
            string localCml_no = "";
            string localGts_no = "";
            string locaAddress = "";
            int hidden_jewller_id = 0;

            JewellerDetailsDataGrid selectedData = jewellerDetailsDataGrid.SelectedItem as JewellerDetailsDataGrid;

            nameOfJewller = selectedData.jewller_name;
            localCml_no = selectedData.cml_no;
            localGts_no = selectedData.gst_no;
            locaAddress = selectedData.address;
            hidden_jewller_id = selectedData.Id;

            if (!String.IsNullOrEmpty(nameOfJewller) && !String.IsNullOrEmpty(localCml_no))
            {
                name_of_jeweller.Text = nameOfJewller;
                address.Text = locaAddress;
                cml_no.Text = localCml_no;
                gst_no.Text = localGts_no;
                jewller_id_hidden.Text = Convert.ToString(hidden_jewller_id);

                JewllerInformationBorder.Visibility = Visibility.Hidden;
                Panel.SetZIndex(JewllerInformationBorder, -1);

            }
        }

        private void Button_Close_jewellerDetailsDataGrid_Click(object sender, RoutedEventArgs e)
        {
            JewllerInformationBorder.Visibility = Visibility.Hidden;
            Panel.SetZIndex(JewllerInformationBorder, -1);
        }


        // On Save Btn click function
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Save Datato Database
            // Master Model
            ReceiptEntryMasterModel receiptEntryMasterModel = new ReceiptEntryMasterModel();
            // Thread Model
            List<ReceiptEntryThreadModel> receiptEntryThreadModelList = new List<ReceiptEntryThreadModel>();

            if (receiptEntryMasterTableService.findByID(Int32.Parse(sr_no.Text)).Count == 0)
            {
                // If count is zero the new entry

                try
                {
                    receiptEntryMasterModel.jeweller_id = Int32.Parse(jewller_id_hidden.Text);
                }
                catch (Exception ex)
                {
                    // Manual Entry Catch


                }

                receiptEntryMasterModel.receipt_date = receipt_date.Text;
                receiptEntryMasterModel.issue_voucher_no = issue_voucher_no.Text;
                receiptEntryMasterModel.delivery_by = delivery_by.Text;
                receiptEntryMasterModel.delivery_date = delivery_date.Text;
                receiptEntryMasterModel.box_no = box_no.Text;
                receiptEntryMasterModel.previous_box_no = previous_box_no.Text;
                receiptEntryMasterModel.customer_name = customer_name.Text;
                receiptEntryMasterModel.ILC_receipt = (bool)ilcReceipt.IsChecked;

                //GridData ridData = gridData.Items;
                List<GridData> threadDataList = gridData.Items.OfType<GridData>().ToList();
                foreach (GridData data in threadDataList)
                {
                    ReceiptEntryThreadModel newReceiptEntryThreadModel = new ReceiptEntryThreadModel();
                    //Console.WriteLine(data.nameOfJewllery);
                    try
                    {
                        newReceiptEntryThreadModel.jewllery_id = Int32.Parse(data.productTableID);
                        newReceiptEntryThreadModel.total_pcs = Convert.ToString(data.totalPcs);
                        newReceiptEntryThreadModel.gross_wt = Convert.ToString(data.grossWt);
                        newReceiptEntryThreadModel.net_wt = Convert.ToString(data.NetWt);
                        newReceiptEntryThreadModel.msphc_wt = Convert.ToString(data.msphcWt);
                        newReceiptEntryThreadModel.receipt_entry_master_id = Int32.Parse(data.masterId);
                        newReceiptEntryThreadModel.remark = data.remark;
                    }
                    catch (Exception ex)
                    {
                        Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.DataNotSaved));
                        return;
                    }


                    receiptEntryThreadModelList.Add(newReceiptEntryThreadModel);

                }

                Boolean result = receiptEntryMasterTableService.SaveAllData(receiptEntryMasterModel);

                if (result == true)
                {
                    Boolean returnValue = receiptEntryThreadTableService.SaveAllData(receiptEntryThreadModelList);

                    if (returnValue == true)
                    {
                        Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.DataSavedAlert));
                        this.ResetJewlleryGrid();
                    }
                }
            }
            else
            {

                List<GridData> threadDataList = gridData.Items.OfType<GridData>().ToList();
                int masterId = Int32.Parse(sr_no.Text);
                List<ReceiptEntryThreadModel> dbThreadData = receiptEntryThreadTableService.findAll(masterId);

                /* if (threadDataList.Count == dbThreadData.Count || threadDataList.Count > dbThreadData.Count)
                 {*/
                List<ReceiptEntryThreadModel> newThreadData = new List<ReceiptEntryThreadModel>();
                List<ReceiptEntryThreadModel> updateThreadData = new List<ReceiptEntryThreadModel>();
                List<int> DeletedEntriesId = new List<int>();
                List<int> DatabaseSearchedId = receiptEntryThreadTableService.findAllByMasterId(masterId);
                List<int> jewllerGridId = new List<int>();
                //List<ReceiptEntryThreadModel> DeletedThreadData = new List<ReceiptEntryThreadModel>();
                foreach (GridData data in threadDataList)
                {
                    //New Data
                    if (data.id == 0)
                    {
                        //Console.WriteLine("NEW DATA");
                        ReceiptEntryThreadModel newReceiptEntryThreadModel = new ReceiptEntryThreadModel();
                        try
                        {
                            newReceiptEntryThreadModel.jewllery_id = Int32.Parse(data.productTableID);
                            newReceiptEntryThreadModel.total_pcs = Convert.ToString(data.totalPcs);
                            newReceiptEntryThreadModel.gross_wt = Convert.ToString(data.grossWt);
                            newReceiptEntryThreadModel.net_wt = Convert.ToString(data.NetWt);
                            newReceiptEntryThreadModel.msphc_wt = Convert.ToString(data.msphcWt);
                            newReceiptEntryThreadModel.receipt_entry_master_id = Int32.Parse(data.masterId);
                            newReceiptEntryThreadModel.remark = data.remark;

                            newThreadData.Add(newReceiptEntryThreadModel);
                        }
                        catch (Exception ex)
                        {
                            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.DataNotSaved));
                            return;
                        }
                    }
                    else
                    {
                        jewllerGridId.Add(data.id);
                        //Console.WriteLine(data.srNo);
                        //EntriesId.Add(data.id);
                        //Console.WriteLine("Updated Data");
                        // Update the existing Data
                        ReceiptEntryThreadModel oldReceiptEntryThreadModel = new ReceiptEntryThreadModel();
                        //ReceiptEntryThreadModel DeletedReceiptEntryThreadModel = new ReceiptEntryThreadModel();
                        try
                        {
                            oldReceiptEntryThreadModel.Id = data.id;
                            oldReceiptEntryThreadModel.jewllery_id = Int32.Parse(data.productTableID);
                            oldReceiptEntryThreadModel.total_pcs = Convert.ToString(data.totalPcs);
                            oldReceiptEntryThreadModel.gross_wt = Convert.ToString(data.grossWt);
                            oldReceiptEntryThreadModel.net_wt = Convert.ToString(data.NetWt);
                            oldReceiptEntryThreadModel.msphc_wt = Convert.ToString(data.msphcWt);
                            oldReceiptEntryThreadModel.receipt_entry_master_id = Int32.Parse(data.masterId);
                            oldReceiptEntryThreadModel.remark = data.remark;

                            updateThreadData.Add(oldReceiptEntryThreadModel);


                            //DeletedReceiptEntryThreadModel = dbThreadData.Where(p => )
                        }
                        catch (Exception ex)
                        {
                            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.DataNotSaved));
                            return;
                        }
                    }
                }

                foreach (int each in DatabaseSearchedId)
                {
                   if (!jewllerGridId.Contains(each))
                    {
                        DeletedEntriesId.Add(each);
                    }
                }

                try
                {
                    if (newThreadData.Count > 0)
                    {
                        //Console.WriteLine("New Thread Data");
                        receiptEntryThreadTableService.SaveAllData(newThreadData);
                    }
                    if (updateThreadData.Count > 0)
                    {
                        //Console.WriteLine("Update Thread data");
                        receiptEntryThreadTableService.updateThreadData(updateThreadData);
                    }

                    if (DeletedEntriesId.Count > 0)
                    {
                        receiptEntryThreadTableService.DisableData(DeletedEntriesId);
                    }

                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.DataUpdatedAlert));
                    this.ResetJewlleryGrid();
                }
                catch (Exception ex)
                {

                }

                //}
                /* else if (threadDataList.Count < dbThreadData.Count)
                 {
                     //Data Deleted
                     //Console.WriteLine("Data Deleted");
                     List<ReceiptEntryThreadModel> DeletedData = new List<ReceiptEntryThreadModel>();



                 }*/
            }

        }

        private void ResetJewlleryGrid()
        {
            List<GridData> newData = new List<GridData>();
            List<ReceiptEntryThreadModel> DBThreadData = receiptEntryThreadTableService.findAll(Int32.Parse(sr_no.Text));
            List<ProductModel> allProducts = productTableService.findAll();
            int i = 0;
            foreach (ReceiptEntryThreadModel eachThreadData in DBThreadData)
            {
                i += 1;
                foreach (ProductModel eachProduct in allProducts)
                {
                    if (eachProduct.ID == eachThreadData.jewllery_id)
                    {
                        //Console.WriteLine("REWRITE GRID DATA");
                        GridData gridData = new GridData()
                        {
                            nameOfJewllery = eachProduct.product_name,
                            totalPcs = Convert.ToInt32(eachThreadData.total_pcs),
                            declearedPurity = float.Parse(eachProduct.purity),
                            grossWt = Convert.ToDouble(eachThreadData.gross_wt),
                            NetWt = Convert.ToDouble(eachThreadData.net_wt),
                            msphcWt = Convert.ToDouble(eachThreadData.msphc_wt),
                            remark = eachThreadData.remark,
                            id = eachThreadData.Id,
                            productTableID = Convert.ToString(eachThreadData.jewllery_id),
                            masterId = sr_no.Text,
                            srNo = Convert.ToString(i)
                        };

                        newData.Add(gridData);
                        break;
                    }
                }
            }
            // Null the Item source
            gridData.ItemsSource = null;
            //this.SetJewllerGridData();
            gridData.ItemsSource = newData;
        }

        private void jewlleryDetailsGridCloseButon_Click(object sender, RoutedEventArgs e)
        {

            jewlleryDetailsBorder.Visibility = Visibility.Hidden;
            Panel.SetZIndex(jewlleryDetailsBorder, -1);

        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {

            name_of_jeweller.Text = "";
            address.Text = "";
            cml_no.Text = "";
            gst_no.Text = "";
            receipt_date.Text = "";
            issue_voucher_no.Text = "";
            delivery_by.Text = "";
            SetSrNo();
            delivery_date.Text = "";
            box_no.Text = "";
            previous_box_no.Text = "";
            customer_name.Text = "";
            ilcReceipt.IsChecked = false;



            gridData.SelectionUnit = DataGridSelectionUnit.Cell;
            initializeGridtable();
        }

        private void DataGridRow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("HIT ROW STYLE");
            //GridView View = sender as GridView;


        }

        private void CommandBinding_Executed_Ctrl_W(object sender, ExecutedRoutedEventArgs e)
        {
            // Console.WriteLine("HIT CTRL +W");

            SavedDataLoadGridBorder.Visibility = Visibility.Visible;
            Panel.SetZIndex(SavedDataLoadGridBorder, 1);

            List<ReceiptEntryMasterModel> DatabaseMasterTableData = receiptEntryMasterTableService.findAll();

            List<PartyModel> allPartyData = partyService.findAllData();
            List<SavedDataLoadGridModel> savedDataLoadGridData = new List<SavedDataLoadGridModel>();

            foreach(ReceiptEntryMasterModel eachModel in DatabaseMasterTableData)
            {
                SavedDataLoadGridModel requriedData = new SavedDataLoadGridModel();

                requriedData.srNo = eachModel.Id;
                foreach(PartyModel eachData in allPartyData)
                {
                    if (eachData.ID == eachModel.jeweller_id)
                    {
                        requriedData.nameOfJeweller = eachData.jewller_name;
                        requriedData.cmlsNo = eachData.cml_no;
                        requriedData.gst_no = eachData.gst_no;
                        requriedData.addressOfJeweller = eachData.address;
                        break;
                    }
                }

                requriedData.receiptDate = eachModel.receipt_date;
                requriedData.issueVoucherNo = eachModel.issue_voucher_no;
                requriedData.deliveryBy = eachModel.delivery_by;
                requriedData.deliveryDate = eachModel.delivery_date;
                requriedData.boxNo = eachModel.box_no;
                requriedData.previousBoxNo = eachModel.previous_box_no;
                requriedData.customerName = eachModel.customer_name;

                savedDataLoadGridData.Add(requriedData);
               


              //  requriedData.nameOfJeweller = eachModel
            }

            SavedDataLoadGrid.ItemsSource = savedDataLoadGridData;

        }

        private void ButtonCloseSavedDataLoadGrid_Click(object sender, RoutedEventArgs e)
        {
            SavedDataLoadGridBorder.Visibility = Visibility.Hidden;
            Panel.SetZIndex(SavedDataLoadGridBorder, -1);
        }

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Console.WriteLine("HIT");
            string jewellerName = "";
            string jewllerAddress = "";
            string cmlNo = "";
            string gstNo = "";
            string receiptDate = "";
            string issueVocherNo = "";
            string deliveryBy = "";
            string jewellerSrNo = "";
            string deliveryDate = "";
            string boxNo = "";
            string previosBoxNo = "";
            string customerName = "";

            SavedDataLoadGridModel requriedGridData = SavedDataLoadGrid.SelectedItem as SavedDataLoadGridModel;

            jewellerName = requriedGridData.nameOfJeweller;
            jewllerAddress = requriedGridData.addressOfJeweller;
            cmlNo = requriedGridData.cmlsNo;
            gstNo = requriedGridData.gst_no;
            receiptDate = requriedGridData.receiptDate;
            issueVocherNo = requriedGridData.issueVoucherNo;
            deliveryBy = requriedGridData.deliveryBy;
            jewellerSrNo = Convert.ToString(requriedGridData.srNo);
            deliveryDate = requriedGridData.deliveryDate;
            boxNo = requriedGridData.boxNo;
            previosBoxNo = requriedGridData.previousBoxNo;
            customerName = requriedGridData.customerName;

            this.makeViewReadOnly();

            name_of_jeweller.Text = jewellerName;
            address.Text = jewllerAddress;
            cml_no.Text = cmlNo;
            gst_no.Text = gstNo;
            receipt_date.Text = receiptDate;
            issue_voucher_no.Text = issueVocherNo;
            delivery_by.Text = deliveryBy;
            sr_no.Text = jewellerSrNo;
            delivery_date.Text = deliveryDate;
            box_no.Text = boxNo;
            previous_box_no.Text = previosBoxNo;
            customer_name.Text = customerName;

            

            this.ResetJewlleryGrid();

            SavedDataLoadGridBorder.Visibility = Visibility.Hidden;
            Panel.SetZIndex(SavedDataLoadGridBorder, -1);
        }

        private void makeViewReadOnly()
        {
            name_of_jeweller.IsReadOnly = true;
            address.IsReadOnly = true;
            gst_no.IsReadOnly = true;
            receipt_date.IsReadOnly = true;
            issue_voucher_no.IsReadOnly = true;
            delivery_by.IsReadOnly = true;
            delivery_date.IsReadOnly = true;
            delivery_by.IsReadOnly = true;
            delivery_date.IsReadOnly = true;
            box_no.IsReadOnly = true;
            previous_box_no.IsReadOnly = true;
            customer_name.IsReadOnly = true;
            gridData.IsReadOnly = true;
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            name_of_jeweller.IsReadOnly = false;
            address.IsReadOnly = false;
            gst_no.IsReadOnly = false;
            receipt_date.IsReadOnly = false;
            issue_voucher_no.IsReadOnly = false;
            delivery_by.IsReadOnly = false;
            delivery_date.IsReadOnly = false;
            delivery_by.IsReadOnly = false;
            delivery_date.IsReadOnly = false;
            box_no.IsReadOnly = false;
            previous_box_no.IsReadOnly = false;
            customer_name.IsReadOnly = false;

            gridData.IsReadOnly = false;
        }

        private void printBtn_Click(object sender, RoutedEventArgs e)
        {
            int requriedID = Int32.Parse(sr_no.Text);

            List<ReceiptEntryMasterModel> masterData = receiptEntryMasterTableService.findByID(requriedID);
            List<ReceiptEntryThreadModel> threadData = receiptEntryThreadTableService.findAll(requriedID);

            if (masterData.Count > 0 && threadData.Count > 0)
            {
                ReceiptEntryPDFView pdfView = new ReceiptEntryPDFView();
                pdfView.GetPDFData(masterData, threadData);
                pdfView.Show();
            }
            else
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.DataNotSavedAlert));
            }
        }
    }

    public class GridData : INotifyPropertyChanged
    {
        public int id { get; set; }
        public String srNo { get; set; }
        public string nameOfJewllery { get; set; }
        public float totalPcs { get; set; }
        public float declearedPurity { get; set; }

        public double grossWt { get; set; }
        private double netWt;

        public double NetWt
        {
            get { return netWt; }
            set
            {
                netWt = value;
                OnPropertyChanged("NetWt");
            }
        }
        public double msphcWt { get; set; }
        public string remark { get; set; }

        public string masterId { get; set; }

        public string productTableID { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public GridData()
        {

        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class jewelleryModal
    {
        public int Id { get; set; }
        public string jewlleryName { get; set; }
        public string purity { get; set; }
    }

    public class Session
    {
        public bool isGridClick { get; set; }
    }

    public class JewellerDetailsDataGrid
    {
        public int Id { get; set; }
        public String jewller_name { get; set; }

        public String cml_no { get; set; }

        public String gst_no { get; set; }

        public string address { get; set; }
    }


    public class SavedDataLoadGridModel
    {
        public int srNo { get; set; }
        public string nameOfJeweller { get; set; }
        public string addressOfJeweller { get; set; }
        public string cmlsNo { get; set; }
        public string receiptDate { get; set; }

        public string gst_no { get; set; }

        public string issueVoucherNo { get; set; }

        public string deliveryBy { get; set; }

        //public string srNo { get; set; }

        public string deliveryDate { get; set; }
        public string boxNo { get; set; }
        public string previousBoxNo { get; set; }
        public string customerName { get; set; }


    }
}
