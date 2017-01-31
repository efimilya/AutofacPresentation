namespace AutofacPresentation
{
    public delegate ChildWindowViewModel ChildWindowViewModelFactory(SpeakerType speakerType);

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