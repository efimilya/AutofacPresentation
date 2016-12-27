namespace AutofacPresentation
{
    public delegate ChildWindowViewModel GoodChildWindowViewModelFactory(SpeakerType speakerType);

    public delegate ChildWindowViewModel BadChildWindowViewModelFactory(SpeakerType speakerType);

    public class ChildWindowViewModel
    {        

        public ChildWindowViewModel(ISpeaker speaker, IHeaderViewModel headerViewModel)
        {
            Header = headerViewModel;
            Text = speaker.Say();
        }

        public string Text { get; }

        public IHeaderViewModel Header { get; }
    }
}