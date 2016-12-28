using System;

namespace AutofacPresentation
{
    public class BadShowChildWindowCommand : IShowChildWindowCommand
    {
        private readonly ChildWindowViewModelFactory _childWindowViewModelFactory;

        public BadShowChildWindowCommand(ChildWindowViewModelFactory childWindowViewModelFactory)
        {
            _childWindowViewModelFactory = childWindowViewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            new ChildWindowView {DataContext = _childWindowViewModelFactory((SpeakerType) parameter)}.ShowDialog();
        }

        public event EventHandler CanExecuteChanged;
    }
}