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
            new ChildWindowView { DataContext = _childWindowViewModelFactory(GetSpeaker((SpeakerType)parameter)) }.ShowDialog();
        }

        public event EventHandler CanExecuteChanged;

        private static ISpeaker GetSpeaker(SpeakerType speakerType)
        {
            switch (speakerType)
            {
                case SpeakerType.Good:
                    return new GoodSpeaker();
                case SpeakerType.Bad:
                    return new BadSpeaker();
                default:
                    throw new ArgumentOutOfRangeException(nameof(speakerType), speakerType, null);
            }
        }
    }
}