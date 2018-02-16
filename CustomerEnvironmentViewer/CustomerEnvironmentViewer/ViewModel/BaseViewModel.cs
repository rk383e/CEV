using Prism.Mvvm;

namespace CustomerEnvironmentViewer.ViewModel
{
    public class BaseViewModel : BindableBase
    {
        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                SetProperty(ref _isBusy, value);
                RaisePropertyChanged();
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                SetProperty(ref _status, value);
                RaisePropertyChanged();
            }
        }
    }
}
