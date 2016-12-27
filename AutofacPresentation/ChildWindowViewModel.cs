namespace AutofacPresentation
{
    public delegate ChildWindowViewModel GoodChildWindowViewModelFactory(SpeakerType speakerType);

    public delegate ChildWindowViewModel BadChildWindowViewModelFactory(SpeakerType speakerType);

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