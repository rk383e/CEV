using FluentFTP;
using System;
using System.Windows.Controls;

namespace CustomerEnvironmentViewer.View
{

    public partial class LoginView : UserControl
    {
        public event EventHandler<FtpListItem[]> LoginSuccessful;

        public LoginView()
        {
            InitializeComponent();
        }

        private void FtpLoginBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FtpListItem[] items = FtpHandler.GetServerDirectories("Customers");
            OnLoginSuccessful(items);
        }
        
        protected virtual void OnLoginSuccessful(FtpListItem[] directories)
        {
            EventHandler<FtpListItem[]> loginEvent = LoginSuccessful;
            loginEvent(true, directories);
        }
    }
}
