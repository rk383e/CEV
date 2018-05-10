using FluentFTP;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CustomerEnvironmentViewer.View
{

    public partial class LoginView : UserControl
    {
        public event EventHandler<List<string>> LoginSuccessful;

        public LoginView()
        {
            InitializeComponent();
        }

        private void FtpLoginBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            List<string> items = FtpHandler.GetServerDirectories("Customers");
            LoginSuccessful(null, items);
        }
    }
}
