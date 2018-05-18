﻿using CustomerEnvironmentViewer.Helpers;
using FluentFTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            e.Result = FtpHandler.GetServerDirectories("Customers");
        }

        private void Login_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingGrid.Stop();
            List<string> items = (List<string>)e.Result;                      
            mainContent.Content = new CustomerDetailView(items);
        }
    }
}
