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
    /// Interaction logic for TestingView.xaml
    /// </summary>
    public partial class TestingView : UserControl
    {

        private TestingModel testingModel = new TestingModel();
        public TestingView()
        {
            InitializeComponent();
        }

        public void showSaveAlert()
        {
            MessageBox.Show("Data Saved !!");
        }

        public void showAlert()
        {
            MessageBox.Show("* Marked Options are requried !!");        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (testing_name.Text == " " || testing_code.Text == " " || testing_rate.Text == " "
                || string.IsNullOrEmpty(testing_name.Text) || string.IsNullOrEmpty(testing_code.Text)
                || string.IsNullOrEmpty(testing_rate.Text))
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.showAlert));
            }
            else
            {
                testingModel.name = testing_name.Text;
                testingModel.code = testing_code.Text;
                testingModel.rate = testing_rate.Text;

                saveTestingData(testingModel);
                clearForm();
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.showSaveAlert));
            }
        }

        private void clearForm()
        {
            testing_name.Text = "";
            testing_code.Text = "";
            testing_rate.Text = "";
        }

        private void saveTestingData(TestingModel testingModel)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Testing_table (code,name,rate) values (@code,@name,@rate)", testingModel);
            }
        }

        private static String LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
