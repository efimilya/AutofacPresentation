using System;
using System.Windows.Input;

namespace AutofacPresentation
{
    public class ShowChildWindowCommand : ICommand
    {
        private readonly ChildWindowViewModelFactory _childWindowViewModelFactory;

        public ShowChildWindowCommand(ChildWindowViewModelFactory childWindowViewModelFactory)
        {
            _childWindowViewModelFactory = childWindowViewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var childWindowViewModel = _childWindowViewModelFactory((SpeakerType) parameter);
            new ChildWindowView {DataContext = childWindowViewModel.Value}.ShowDialog();
            childWindowViewModel.Dispose();
        }

        public event EventHandler CanExecuteChanged;
    }
}