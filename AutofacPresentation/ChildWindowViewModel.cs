namespace AutofacPresentation
{
    public delegate ChildWindowViewModel ChildWindowViewModelFactory(SpeakerType speakerType);

    public class ChildWindowViewModel
    {
        public ChildWindowViewModel(ISpeaker speaker)
        {
            Text = speaker.Say();
        }

        public string Text { get; }
    }
}