using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AutofacPresentation.Backend;
using AutofacPresentation.Properties;

namespace AutofacPresentation.Frontend
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly Func<int, Divider> _dividerFactory;

        public MainWindowViewModel(IHeaderViewModel headerViewModel, Func<int, Divider> dividerFactory)
        {
            _dividerFactory = dividerFactory;
            Header = headerViewModel;
            RelayCommand = new RelayCommand(ExecuteService);
            DivideCommand = new RelayCommand(Divide);
            DivideValue = 10;
        }

        private void Divide(object obj)
        {
            DivideResult = _dividerFactory(DivideValue).Divide().ToString();
            OnPropertyChanged(nameof(DivideResult));
        }

        public RelayCommand RelayCommand { get; }
        public RelayCommand DivideCommand { get; }

        public IHeaderViewModel Header { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        private void ExecuteService(object obj)
        {
            ServiceResult = BackendCompositionRoot.CreateService(1,1,"").Calculate();
            OnPropertyChanged(nameof(ServiceResult));
        }

        public int ServiceResult { get; set; }

        public int DivideValue { get; set; }

        public string DivideResult { get; set; }

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