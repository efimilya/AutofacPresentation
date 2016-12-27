using System;
using System.Windows.Input;

namespace AutofacPresentation
{
    public class BadShowChildWindowCommand : IShowChildWindowCommand
    {
        private readonly BadChildWindowViewModelFactory _childWindowViewModelFactory;

        public BadShowChildWindowCommand(BadChildWindowViewModelFactory childWindowViewModelFactory)
        {
            _childWindowViewModelFactory = childWindowViewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            new ChildWindowView { DataContext = _childWindowViewModelFactory((SpeakerType)parameter) }.ShowDialog();
        }

        public event EventHandler CanExecuteChanged;

        
    }
}