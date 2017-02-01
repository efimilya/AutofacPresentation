using System.ComponentModel;
using System.Runtime.CompilerServices;
using AutofacPresentation.Backend;
using AutofacPresentation.Properties;

namespace AutofacPresentation.Frontend
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel(IHeaderViewModel headerViewModel)
        {
            Header = headerViewModel;
            RelayCommand = new RelayCommand(ExecuteService);
        }

        public RelayCommand RelayCommand { get; }

        public IHeaderViewModel Header { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        private void ExecuteService(object obj)
        {
            ServiceResult = BackendCompositionRoot.CreateService(1,1,"").Calculate();
            OnPropertyChanged(nameof(ServiceResult));
        }

        public int ServiceResult { get; set; }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MainHeaderViewModel : IHeaderViewModel
    {
        public string Text => "Простой заголовок";
    }

    public interface IHeaderViewModel
    {
        string Text { get; }
    }
}