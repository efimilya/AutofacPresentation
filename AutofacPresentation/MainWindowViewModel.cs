namespace AutofacPresentation
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(ShowChildWindowCommand showChildWindowCommand)
        {
            ShowChildWindowCommand = showChildWindowCommand;
        }

        public ShowChildWindowCommand ShowChildWindowCommand { get; }
    }
}