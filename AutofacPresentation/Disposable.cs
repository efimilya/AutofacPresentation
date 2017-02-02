using System;

namespace AutofacPresentation
{
    public class Disposable : IDisposable
    {
        private readonly Action _disposeAction;

        public Disposable(Action disposeAction)
        {
            _disposeAction = disposeAction;
        }

        public void Dispose()
        {
            _disposeAction();
        }
    }

    public class Disposable<T> : IDisposable
    {
        public readonly T Value;
        private readonly Action _disposeAction;

        public Disposable(T value, Action disposeAction)
        {
            Value = value;
            _disposeAction = disposeAction;
        }

        public void Dispose()
        {
            _disposeAction();
        }
    }
}