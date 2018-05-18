using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    /// <summary>
    /// Interaction logic for LoadingControl.xaml
    /// </summary>
    public partial class LoadingGrid : UserControl
    {        
        public LoadingGrid()
        {
            InitializeComponent();
        }

        public void Start()
        {
            this.Visibility = Visibility.Visible;
            loadingIcon.Spin = true;
        }

        public void Stop()
        {
            loadingIcon.Spin = false;
            this.Visibility = Visibility.Collapsed;
        }
    }
}
