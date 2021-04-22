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

namespace HallMark_Management_System.Views
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {

        private ProductModel productModel = new ProductModel();
        public ProductView()
        {
            InitializeComponent();
            /* sampling_combobox.Items.Add("TEST");
             sampling_combobox.Items.Add("TEST2");*/

            addItemToComboBox();
        }

        public void addItemToComboBox()
        {
            List<SamplingModel> samplingModel = loadSamplingData();
            foreach (SamplingModel each_data in samplingModel) {
                sampling_combobox.Items.Add(each_data.method);
            }
        }


        public List<SamplingModel> loadSamplingData()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var queryResult = cnn.Query<SamplingModel>("select * from sampling_table", new DynamicParameters());
                return queryResult.ToList();
            }
        }

        public void saveAlert()
        {
            MessageBox.Show("Data Saved !!");
        }

        public void cleanForm()
        {
            product_name.Text = "";
            sampling_combobox.Text = "";
            purity.Text = "";
            
        }

        public void saveProductData(ProductModel productModel)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Product_table (purity, sampling_method, product_name)" +
                    "values (@purity, @sampling_method, @product_name)", productModel);

                cleanForm();
                saveAlert();
            }
        }

        private static String LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            List<SamplingModel> sampleList = loadSamplingData();

            String selectedSample = sampling_combobox.Text;

            foreach(SamplingModel eachItem in sampleList)
            {
                if (String.Equals(eachItem.method, selectedSample))
                {
                    productModel.sampling_method = eachItem.ID;
                    break;
                }
            }
            productModel.purity = purity.Text;
            productModel.product_name = product_name.Text;

            saveProductData(productModel);


        }
    }
}
