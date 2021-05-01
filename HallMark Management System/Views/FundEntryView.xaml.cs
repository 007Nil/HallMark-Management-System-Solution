using Dapper;
using HallMark_Management_System.Models;
using HallMark_Management_System.Service;
using HallMark_Management_System.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
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
using System.Windows.Threading;

namespace HallMark_Management_System.Views
{
    /// <summary>
    /// Interaction logic for FundEntryView.xaml
    /// </summary>
    public partial class FundEntryView : UserControl
    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text

       // private FundEntryModel fundEntry = new FundEntryModel();

        private PartyTableService partyTableService = new PartyTableService();

        private FundTransferTableService fundTransferTableService = new FundTransferTableService();

        private status status = new status();

        public FundEntryView()
        {
            InitializeComponent();
            addItemToComboBox();
        }

        public void addItemToComboBox()
        {
            List<CreditDebitModel> creditDebitModels = GetCreditDebitData();

            List<TransationTypeModel> transationTypeModels = GetTransactionTypeDate();

            foreach(CreditDebitModel eachData in creditDebitModels){
                transation_type.Items.Add(eachData.type);
            }

            foreach(TransationTypeModel eachData in transationTypeModels){
                type.Items.Add(eachData.type);
            }
            
        }
        private void DataSavedAlert()
        {
            MessageBox.Show("Data Saved !!");
        }

        private void ShowAlert()
        {
            MessageBox.Show("* Marked Options are requried !!");
        }

        private void ShowPartyNotFound()
        {
            MessageBox.Show("Jeweller Does Not Exist !!");
        }

        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void NetAmountCharAlert()
        {
            MessageBox.Show("Only Numbers allowed !!");
        }


        private void SameRecordFindAlert()
        {
            MessageBox.Show("Same Entry Already Exists !!");

        }


        private void net_amount_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            //  Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.alter));
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    //Console.WriteLine("HIT");
                    e.CancelCommand();
                    net_amount.Text = "";
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void net_amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.Handled = !IsTextAllowed(net_amount.Text);
            double text_amount;
            try
            {
                Console.WriteLine(net_amount.Text);
                if (!String.IsNullOrEmpty(net_amount.Text))
                {
                    text_amount = (float.Parse(net_amount.Text, CultureInfo.InvariantCulture.NumberFormat) * 18) / 100;
                    Console.WriteLine(text_amount);
                    tax_amount.Text = string.Format("{0:N2}", text_amount);

                    double total = float.Parse(net_amount.Text, CultureInfo.InvariantCulture.NumberFormat) + text_amount;

                    total_amount.Text = string.Format("{0:N2}", total);
                }
                else if (String.IsNullOrWhiteSpace(net_amount.Text) ||
                    String.IsNullOrEmpty(net_amount.Text))
                {
                    tax_amount.Text = "";
                    total_amount.Text = "";
                }
            }
            catch (Exception ex)
            {
                //net_amount.Text = "";
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.NetAmountCharAlert));


                string s = net_amount.Text;

                if (s.Length > 1)
                {
                    s = s.Substring(0, s.Length - 1);
                }
                else
                {
                    s = "";
                }

                net_amount.Text = s;
            }
        }


        public static List<TransationTypeModel> GetTransactionTypeDate()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var queryResult = cnn.Query<TransationTypeModel>("select * from transaction_type_table", new DynamicParameters());
                return queryResult.ToList();
            }
        }

        public static List<CreditDebitModel> GetCreditDebitData()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var queryResult = cnn.Query<CreditDebitModel>("select * from Credit_Debit_table", new DynamicParameters());
                return queryResult.ToList();
            }
        }

        public List<PartyModel> findAllParty()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var queryResult = cnn.Query<PartyModel>("select * from Party_table", new DynamicParameters());
                return queryResult.ToList();
            }
        }

        private static String LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }


        private void ShowJewllerDetails(object sender, ExecutedRoutedEventArgs e)
        {

            //party_model_view.Items.Clear();
            //Console.WriteLine("PRESSED F2");
            if (float_border.Visibility == Visibility.Hidden)
            {
                float_border.Visibility = Visibility.Visible;
            }
                 /* ? Visibility.Visible 
                  : Visibility.Hidden;*/
            Panel.SetZIndex(float_border, 1);



            List<ModalModel> modal = new List<ModalModel>();
                
            foreach (PartyModel each_model in findAllParty())
            {
                modal.Add(new ModalModel() {jewller_name = each_model.jewller_name, cml_no = each_model.cml_no, address = each_model.address, gst_no = each_model.gst_no, id = each_model.ID });
            }

            party_model_view.ItemsSource = modal;
        }

        private void modal_cls_btn_Click(object sender, RoutedEventArgs e)
        {
            float_border.Visibility = Visibility.Hidden;
            Panel.SetZIndex(float_border, -1);
        }


        void ClickonDataGrid(object sender, RoutedEventArgs e)
        {
            try
            {
                //Console.WriteLine("INTO CLICKONDATAGRID");
                int id = 0;
                String jeweller = "";
                /*  for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                      if (vis is DataGridRow)
                      {
                          //Console.WriteLine("Into FOR LOOP");
                          var rows = GetDataGridRowsForButtons(party_model_view);
                          //Console.WriteLine("AFTER FOR LOOP");
                          foreach (DataGridRow dr in rows)
                          {
                              //Console.WriteLine("INTO FOREACH");
                              try
                              {
                                  id = (dr.Item as ModalModel).id;
                                  jeweller = (dr.Item as ModalModel).jewller_name;
                              }catch (Exception ex)
                              {
                                  return;
                              }
                              //Console.WriteLine(jeweller);
                              break;
                          }
                          break;
                          //jeweller = (rows.Item as ModalModel)
                      }*/

                ModalModel model = party_model_view.SelectedItem as ModalModel;

                jeweller = model.jewller_name;
                id = model.id;
                if (!string.IsNullOrEmpty(jeweller) && id !=0)
                {
                   /* Console.WriteLine(jeweller);
                    Console.WriteLine(id);*/
                    hidden_id.Text = Convert.ToString(id);
                    float_border.Visibility = Visibility.Hidden;
                    Panel.SetZIndex(float_border, -1);

                    name_of_jeweller.Text = jeweller;
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private IEnumerable<DataGridRow> GetDataGridRowsForButtons(DataGrid grid)
        { //IQueryable
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
           
            foreach (var item in itemsSource)
            {
                /*  grid.ScrollIntoView(grid.Items[grid.Items.Count - 1]);
                  grid.UpdateLayout();
                  grid.ScrollIntoView(grid.SelectedItem);*/
              
                    var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (null != row & row.IsSelected) yield return row;
               
              
            }
        }

        private void CloseModalonEsc(object sender, ExecutedRoutedEventArgs e)
        {
            if (float_border.Visibility == Visibility.Visible)
            {
                Console.WriteLine(sender);
                float_border.Visibility = Visibility.Hidden;
                Panel.SetZIndex(float_border, -1);

            }
        }

        private void printToPDF(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine(hidden_id.Text);
            if (string.IsNullOrEmpty(voucher_no.Text) || string.IsNullOrEmpty(date.Text)
                ||string.IsNullOrEmpty(transation_type.Text) || string.IsNullOrEmpty(type.Text)
                ||string.IsNullOrEmpty(name_of_jeweller.Text) || string.IsNullOrEmpty(net_amount.Text)
                ||string.IsNullOrEmpty(cheque_no.Text) ||string.IsNullOrEmpty(cheque_date.Text)
                ||string.IsNullOrEmpty(bank_name.Text) ||string.IsNullOrEmpty(bill_date.Text)
                )
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.ShowAlert));
            }
            else
            {
                Boolean result = SaveDatatoFundTransferTable();
                if (result == true)
                {
                    FundReceiptPDFView fundPDF = new FundReceiptPDFView();
                    fundPDF.FundReceiptPDFView1(type.Text, transation_type.Text,
                        cheque_no.Text, cheque_date.Text, bank_name.Text, bill_no.Text, bill_date.Text,
                        remark.Text, date.Text,name_of_jeweller.Text,total_amount.Text);
                    fundPDF.Show();
                }

            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(voucher_no.Text) || string.IsNullOrEmpty(date.Text)
               || string.IsNullOrEmpty(transation_type.Text) || string.IsNullOrEmpty(type.Text)
               || string.IsNullOrEmpty(name_of_jeweller.Text) || string.IsNullOrEmpty(net_amount.Text)
               || string.IsNullOrEmpty(cheque_no.Text) || string.IsNullOrEmpty(cheque_date.Text)
               || string.IsNullOrEmpty(bank_name.Text) || string.IsNullOrEmpty(bill_date.Text)
               )
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.ShowAlert));
            }
            else
            {
                Boolean result = SaveDatatoFundTransferTable();
                if (result == true)
                {
                    if (status.DatabaseresultStatue == true) {
                            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.DataSavedAlert));
                    }
                    else
                    {
                        Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.SameRecordFindAlert));
                    }
                }

            }
        }

        private Boolean SaveDatatoFundTransferTable()
        {
            FundEntryModel fundEntry = new FundEntryModel();
            Console.WriteLine("HIT MAIN ELSE");
            List<TransationTypeModel> transactionList = GetTransactionTypeDate();
            List<CreditDebitModel> creditDebitList = GetCreditDebitData();
            List<PartyModel> partyDetails = partyTableService.findByJewllerName(name_of_jeweller.Text);
            try
            {
                if (partyDetails.Count != 0)
                {
                    fundEntry.jeweller_id = Int32.Parse(hidden_id.Text);
                }
                else
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.ShowPartyNotFound));
                    return false;

                }
            }
            catch (Exception ex)
            {
                

                if (partyDetails.Count == 0)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.ShowPartyNotFound));
                    return false;
                }
                else
                {
                    foreach (PartyModel eachParty in partyDetails)
                    {
                        fundEntry.jeweller_id = eachParty.ID;
                    }
                }
            }
            fundEntry.net_amount = float.Parse(net_amount.Text);
            foreach (TransationTypeModel each_data in transactionList)
            {
                //Console.WriteLine(transation_type.Text);
                //Console.WriteLine(each_data.type);
                if (String.Equals(each_data.type, type.Text))
                {
                    fundEntry.type = each_data.ID;
                    break;
                }
                //fundEntry.transaction_type
            }
            foreach (CreditDebitModel each_data in creditDebitList)
            {
                //Console.WriteLine(each_data.ID);
                if (String.Equals(each_data.type, transation_type.Text))
                {
                    fundEntry.transaction_type = each_data.ID;
                    break;
                }
            }

            fundEntry.cheque_no = cheque_no.Text;
            fundEntry.cheque_date = cheque_date.Text;
            // Need to get back name and enter it into bank table 
            //fundEntry

            //foreach(BankModel each in findAllBankDetails()){

            if (findAllBankDetails(bank_name.Text).Count != 0)
            {
                foreach (BankModel each_model in findAllBankDetails(bank_name.Text))
                {
                    fundEntry.bank_id = each_model.ID;
                }
            }
            else
            {
                Console.WriteLine("HIT ELSE");
                BankModel bank = new BankModel();
                bank.bank_name = bank_name.Text;
                AddBankDetails(bank);

                foreach (BankModel each_bank in findAllBankDetails(bank_name.Text))
                {
                    //Console.WriteLine(each_bank.bank_name);
                    fundEntry.bank_id = each_bank.ID;
                }
            }

            fundEntry.bill_no = bill_no.Text;

            fundEntry.bill_date = bill_date.Text;

            fundEntry.remarks = remark.Text;

            //Console.WriteLine(fundEntry);
            // Saving Data into database
            List<FundEntryModel> oneDateList = fundTransferTableService.findOneEntryWithAllParams(fundEntry);
            Console.WriteLine(oneDateList.Count);
            if (oneDateList.Count == 0)
            {
                EnterDataInFund_Transfer_table(fundEntry);
                status.DatabaseresultStatue = true;
            }
            else
            {
               
                status.DatabaseresultStatue = false;
            }
           return true;
        }

        private void clearForm()
        {
            transation_type.Text = "";
            type.Text = "";
            name_of_jeweller.Text = "";
            net_amount.Text = "";
            cheque_no.Text = "";
            cheque_date.Text = "";
            bank_name.Text = "";
            bill_date.Text = "";
            voucher_no.Text = "";
            date.Text = "";
            remark.Text = "";
            bill_no.Text = "";
        }

        private List<BankModel> findAllBankDetails(string bankName)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var queryResult = cnn.Query<BankModel>("select * from Bank_table where bank_name='"+ bankName + "';", new DynamicParameters());
                return queryResult.ToList();
            }
        }

        public void AddBankDetails(BankModel bankModel)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Bank_table (bank_name) values (@bank_name)", bankModel);
            }
        }

        private void EnterDataInFund_Transfer_table(FundEntryModel fundEntryModel)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Fund_Transfer_table(transaction_type,type,jeweller_id,net_amount," +
                    "cheque_no,cheque_date,bank_id,bill_no,bill_date,remarks) values" +
                    "(@transaction_type,@type,@jeweller_id,@net_amount,@cheque_no,@cheque_date,@bank_id" +
                    ",@bill_no,@bill_date,@remarks)", fundEntryModel);
            }
        }


    }

    public class ModalModel
    {
        public int id { get; set; }
        public string jewller_name { get; set; }

        public string cml_no { get; set; }

        public string address { get; set; }

        public string gst_no { get; set; }
    }

    public class status
    {
        public Boolean DatabaseresultStatue { get; set; }
    }
}
