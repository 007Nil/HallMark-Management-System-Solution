using HallMark_Management_System.ViewModels;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HallMark_Management_System.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
            DataContext = new BlankViewModel();
        }

        private void MenuItem_Company_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CompanyViewModel();
;        }

        private void MenuItem_Party_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Click Measter");
            DataContext = new PartyViewModel();
        }

        private void MenuItem_Product_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ProductViewModel();
        }

        private void MenuItem_Testing_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new TestingViewModel();
        }

        private void Fund_Entry_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new FundEntryViewModel();
        }

        private void Receipt_Entry_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ReceiptEntryViewModel();
        }
    }
}
