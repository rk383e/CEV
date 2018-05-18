using System.Collections.Generic;
using System.Windows.Controls;

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
