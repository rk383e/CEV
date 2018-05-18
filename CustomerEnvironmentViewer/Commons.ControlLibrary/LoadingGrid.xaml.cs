using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    /// <summary>
    /// Interaction logic for LoadingControl.xaml
    /// </summary>
    public partial class LoadingGrid : UserControl
    {
        public static readonly DependencyProperty ActiveSpinProperty = DependencyProperty.Register("ActiveSpin", typeof(bool), typeof(LoadingGrid), new PropertyMetadata(null));

        public bool ActiveSpin { get; set; }

        public LoadingGrid()
        {
            InitializeComponent();
        }
    }
}
