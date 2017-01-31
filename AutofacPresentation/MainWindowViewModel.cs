namespace AutofacPresentation
{
    public class MainWindowViewModel
    {
        private readonly HeaderViewModel _headerViewModel;

        public MainWindowViewModel(ShowChildWindowCommand showChildWindowCommand, HeaderViewModel headerViewModel)
        {
            _headerViewModel = headerViewModel;
            ShowChildWindowCommand = showChildWindowCommand;
        }

        public ShowChildWindowCommand ShowChildWindowCommand { get; }

        public HeaderViewModel Header => _headerViewModel;
    }
}