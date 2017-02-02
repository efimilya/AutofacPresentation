using System;
using Autofac.Util;

namespace AutofacPresentation
{
    public delegate Disposable<ChildWindowViewModel> ChildWindowViewModelFactory(SpeakerType speakerType);    

    public class ChildWindowViewModel : IDisposable
    {        
        private CompositeDisposable _lifetime = new CompositeDisposable();

        public ChildWindowViewModel(ISpeaker speaker, IHeaderViewModel headerViewModel, MainWindowViewModel mainWindowViewModel)
        {
            Header = headerViewModel;
            Text = speaker.Say();
            mainWindowViewModel.SomeAction += OnSomeAction;
            _lifetime.Add(()=> mainWindowViewModel.SomeAction -= OnSomeAction);
        }

        private void OnSomeAction()
        {
            
        }

        public string Text { get; }
        public IHeaderViewModel Header { get; }
        public void Dispose()
        {
            _lifetime.Dispose();
        }
    }
}