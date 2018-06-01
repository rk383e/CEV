using CustomerEnvironmentViewer.Helpers;
using FluentFTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace CustomerEnvironmentViewer.View
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            LoginInitialize();
        }

        private void BannerCanvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                base.OnMouseLeftButtonDown(e);
                this.DragMove();
            }
            else
            {
                Point outputPoint = this.PointToScreen(new Point());
                System.Drawing.Point newPoint = new System.Drawing.Point((int)outputPoint.X, (int)outputPoint.Y);
                Screen currentScreen = Screen.FromPoint(newPoint);

                this.Width = 1500;
                this.Height = 800;
                this.Left = currentScreen.Bounds.X;
                this.Top = currentScreen.Bounds.Y;
                this.WindowStartupLocation = WindowStartupLocation.Manual;
                this.WindowState = WindowState.Normal;
                base.OnMouseLeftButtonDown(e);
                this.DragMove();
            }
            e.Handled = true;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoginInitialize()
        {
            loadingGrid.Start();
            new WorkerThread(Login_DoWork, Login_Completed, null);
        }

        private void Login_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = FtpHandler.GetServerDirectories("Customers");
            }
            catch (SocketException se)
            {
                if (se.Message == "No such host is known")
                    e.Result = new Exception("Cannot connect to the host FTP, please make sure you are connected to the company VPN");
                else
                    e.Result = new Exception(se.Message);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void Login_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingGrid.Stop();
            if (e.Result.GetType() == typeof(List<string>))
            {
                List<string> items = (List<string>)e.Result;
                mainContent.Content = new CustomerDetailView(items);
            }
            else if (e.Result.GetType() == typeof(Exception))
            {
                ErrorView errorView = new ErrorView();
                errorView.errorBlock.Text = ((Exception)e.Result).Message;
                mainContent.Content = errorView;
            }            
        }
    }
}
