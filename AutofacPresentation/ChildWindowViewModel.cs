namespace AutofacPresentation
{
    public delegate ChildWindowViewModel ChildWindowViewModelFactory(SpeakerType speakerType);    

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