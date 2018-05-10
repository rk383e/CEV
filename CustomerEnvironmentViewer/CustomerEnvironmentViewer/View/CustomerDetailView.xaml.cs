using FluentFTP;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomerEnvironmentViewer.View
{
    /// <summary>
    /// Interaction logic for CustomerDetailView.xaml
    /// </summary>
    public partial class CustomerDetailView : UserControl
    {
        private List<string> _dirList;
        private List<string> _subDirList;

        public CustomerDetailView(List<string> context)
        {
            InitializeComponent();
            _dirList = context;
            customerListBox.ItemsSource = _dirList;
        }

        private void CustomerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object selectedCustomer = e.AddedItems[0];
            string subDirectory = string.Format("Customers/{0}", selectedCustomer.ToString());
            _subDirList = FtpHandler.GetServerDirectories(subDirectory);
            environmentListBox.ItemsSource = _subDirList;
        }
    }
}
