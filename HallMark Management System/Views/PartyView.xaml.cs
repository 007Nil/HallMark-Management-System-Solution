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
    /// Interaction logic for PartyView.xaml
    /// </summary>
    public partial class PartyView : UserControl
    {

        private PartyModel partyModel = new PartyModel();
        public PartyView()
        {
            InitializeComponent();
        }

        private void New_Button_Click(object sender, RoutedEventArgs e)
        {
            clearForm();
        }

        private void clearForm()
        {
            logo.Text = "";
            igst.IsChecked = false;
            jewller_name.Text = "";
            cml_no.Text = "";
            date.Text = "";
            address.Text = "";
            mobile.Text = "";
            state.Text = "";
            place_of_supply.Text = "";
            state_code.Text = "";
            phone_1.Text = "";
            phone_2.Text = "";
            phone_3.Text = "";
            cin_no.Text = "";
            email.Text = "";
            contact_person.Text = "";
            gst_no.Text = "";
            pan_no.Text = "";
        }

        private void ShowAlert()
        {
            MessageBox.Show("* Marked Options are requried !!");
        }

        private void SaveDoneAlert()
        {
            MessageBox.Show("Data Saved !!");
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {

            if (jewller_name.Text == " " || logo.Text == " " || cml_no.Text == " " || address.Text == ""
                || date.Text == " " || state.Text == " " || state_code.Text == " "
                || string.IsNullOrEmpty(jewller_name.Text) || string.IsNullOrEmpty(logo.Text) || string.IsNullOrEmpty(cml_no.Text)
                || string.IsNullOrEmpty(cml_no.Text) || string.IsNullOrEmpty(state.Text) || string.IsNullOrEmpty(state_code.Text))
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.ShowAlert));
            }
            else
            {
                partyModel.jewller_name = jewller_name.Text;
                partyModel.igst = (bool)igst.IsChecked;
                partyModel.logo = logo.Text;
                partyModel.cml_no = cml_no.Text;
                partyModel.date = date.Text;
                partyModel.place_of_supply = place_of_supply.Text;
                partyModel.address = address.Text;
                partyModel.mobile = mobile.Text;
                partyModel.state = state.Text;
                partyModel.state_code = state_code.Text;
                partyModel.phone_1 = phone_1.Text;
                partyModel.phone_2 = phone_2.Text;
                partyModel.phone_3 = phone_3.Text;
                partyModel.cin_no = cin_no.Text;
                partyModel.email = email.Text;
                partyModel.contact_person = contact_person.Text;
                partyModel.gst_no = gst_no.Text;
                partyModel.pan_no = pan_no.Text;

                savePartyDetails(partyModel);
                clearForm();
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.SaveDoneAlert));
            }
        }

        private void savePartyDetails(PartyModel partyModel)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Party_table (logo,igst,jewller_name,cml_no,date,address,mobile,state,place_of_supply" +
                    ",state_code,phone_1,phone_2,phone_3,cin_no,email,contact_person,gst_no,pan_no)" +
                    "values" +
                    "(@logo,@igst,@jewller_name,@cml_no,@date,@address,@mobile,@state,@place_of_supply," +
                    "@state_code,@phone_1,@phone_2,@phone_3,@cin_no,@email,@contact_person,@gst_no,@pan_no)", partyModel);
            }
        }

        private static String LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
