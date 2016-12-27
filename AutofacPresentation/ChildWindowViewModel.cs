namespace AutofacPresentation
{
    public delegate ChildWindowViewModel GoodChildWindowViewModelFactory(SpeakerType speakerType);

    public delegate ChildWindowViewModel BadChildWindowViewModelFactory(ISpeaker speaker);

    public class ChildWindowViewModel
    {
        private readonly HeaderViewModel _headerViewModel;

        public ChildWindowViewModel(ISpeaker speaker, HeaderViewModel headerViewModel)
        {
            _headerViewModel = headerViewModel;
            Text = speaker.Say();
        }

        public string Text { get; }

        public HeaderViewModel Header => _headerViewModel;
    }
}