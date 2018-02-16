using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerEnvironmentViewer.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private BaseViewModel _activeViewModel = new LoginViewModel();
        public BaseViewModel ActiveViewModel
        {
            get { return _activeViewModel; }
            set
            {
                SetProperty(ref _activeViewModel, value);
                RaisePropertyChanged();
            }
        }
    }
}
