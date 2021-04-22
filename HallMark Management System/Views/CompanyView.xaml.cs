using Dapper;
using HallMark_Management_System.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for CompanyView.xaml
    /// </summary>
    public partial class CompanyView : UserControl
    {

        private CompanyModel companyModel = new CompanyModel();


        public CompanyView()
        {
            InitializeComponent();

            List<String> count = countCompanyTableTupples();
            onStartUp(count);


        }

        public void onStartUp(List<String> count)
        {
            int tupple_count = 0;
            foreach (String each in count)
            {
                tupple_count = Int16.Parse(each);
            }

            //System.Diagnostics.Trace.WriteLine(tupple_count);

            if (tupple_count == 1)
            {
                List<CompanyModel> allData = LoadCompanyData();

                foreach(CompanyModel each_data in allData)
                {
                    customer_name.Text = each_data.customer_name;
                    address.Text = each_data.Address;
                    city.Text = each_data.City;
                    pin.Text = each_data.pin;
                    state.Text = each_data.state;
                    mobile.Text = each_data.mobile;
                    phone_0.Text = each_data.phone_0;
                    phone_1.Text = each_data.phone_1;
                    email.Text = each_data.email;
                    gst_no.Text = each_data.gst_no;
                    pan_no.Text = each_data.pan_no;
                    place_of_supply.Text = each_data.place_of_supply;
                    state_code.Text = each_data.state_code;
                    license_no.Text = each_data.license_no;
                    invoice_code.Text = each_data.invoice_code;
                }
            }
        }

        private void ShowAlert()
        {
            MessageBox.Show("* Marked Options are requried !!");
        }


        public static List<String> countCompanyTableTupples()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var queryResult = cnn.Query<String>("select count (*) from Company_table", new DynamicParameters());
                return queryResult.ToList();
            }
        }
        public static  List<CompanyModel> LoadCompanyData()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var queryResult = cnn.Query<CompanyModel>("select * from Company_table", new DynamicParameters());
                return queryResult.ToList();
            }
        }

        public void addACompany(CompanyModel companyData)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Company_table (customer_name,Address,City,pin,state,mobile,phone_0,phone_1,email," +
                    "gst_no,pan_no,place_of_supply,state_code,license_no,invoice_code) " +
                    "VALUES (@customer_name,@Address,@City,@pin,@state,@mobile,@phone_0,@phone_1,@email," +
                    "@gst_no,@pan_no,@place_of_supply,@state_code,@license_no,@invoice_code)", companyData);
                
            }
        }

        private static String LoadConnectionString(string id= "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            if (customer_name.Text == " " || address.Text == " " ||
               pin.Text == " " || state.Text == " " || pan_no.Text == " "
               || String.IsNullOrEmpty(customer_name.Text) || String.IsNullOrEmpty(address.Text)
               || String.IsNullOrEmpty(pin.Text) || String.IsNullOrEmpty(state.Text) ||
               String.IsNullOrEmpty(pan_no.Text))
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.ShowAlert));
            }
            else
            {
                companyModel.customer_name = customer_name.Text;
                companyModel.Address = address.Text;
                companyModel.City = city.Text;
                companyModel.pin = pin.Text;
                companyModel.state = state.Text;
                companyModel.mobile = mobile.Text;
                companyModel.phone_0 = phone_0.Text;
                companyModel.phone_1 = phone_1.Text;
                companyModel.email = email.Text;
                companyModel.gst_no = gst_no.Text;
                companyModel.pan_no = pan_no.Text;
                companyModel.place_of_supply = place_of_supply.Text;
                companyModel.state_code = state_code.Text;
                companyModel.license_no = license_no.Text;
                companyModel.invoice_code = invoice_code.Text;

                addACompany(companyModel);


            }
            //System.Diagnostics.Trace.WriteLine(companyModel.ToString());
        }
    }
}
