namespace AutofacPresentation
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(IShowChildWindowCommand showChildWindowCommand, IHeaderViewModel headerViewModel)
        {
            Header = headerViewModel;
            ShowChildWindowCommand = showChildWindowCommand;
        }

        public IShowChildWindowCommand ShowChildWindowCommand { get; }

        public IHeaderViewModel Header { get; }
    }

    public class SimpleHeaderViewModel : IHeaderViewModel
    {
        public string Text => "Простой заголовок";
    }

    public interface IHeaderViewModel
    {
        string Text { get; }
    }
}