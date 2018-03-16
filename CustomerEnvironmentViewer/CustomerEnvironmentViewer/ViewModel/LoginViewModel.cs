using CustomerEnvironmentViewer.Model;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;

namespace CustomerEnvironmentViewer.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public DelegateCommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            //FtpHandler.GetServerData("Customers");
        }
    }
}
