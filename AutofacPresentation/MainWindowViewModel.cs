namespace AutofacPresentation
{
    public class MainWindowViewModel
    {
        private readonly HeaderViewModel _headerViewModel;

        public MainWindowViewModel(IShowChildWindowCommand showChildWindowCommand, HeaderViewModel headerViewModel)
        {
            _headerViewModel = headerViewModel;
            ShowChildWindowCommand = showChildWindowCommand;
        }

        public IShowChildWindowCommand ShowChildWindowCommand { get; }

        public HeaderViewModel Header => _headerViewModel;
    }
}