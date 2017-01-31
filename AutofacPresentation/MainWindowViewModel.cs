namespace AutofacPresentation
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(ShowChildWindowCommand showChildWindowCommand, IHeaderViewModel headerViewModel)
        {
            Header = headerViewModel;
            ShowChildWindowCommand = showChildWindowCommand;
        }

        public ShowChildWindowCommand ShowChildWindowCommand { get; }

        public IHeaderViewModel Header { get; }
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