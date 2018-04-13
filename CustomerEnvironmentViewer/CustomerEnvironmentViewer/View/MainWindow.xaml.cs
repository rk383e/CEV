using FluentFTP;
using System;
using System.Windows;
using System.Windows.Forms;

namespace CustomerEnvironmentViewer.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            loginView.LoginSuccessful += new EventHandler<FtpListItem[]>(OnLoginSuccessful);
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

        private void OnLoginSuccessful(object sender, FtpListItem[] directoryCollection)
        {

        }
    }
}
