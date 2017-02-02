using System;
using System.Collections.Generic;

namespace AutofacPresentation
{
    public class CompositeDisposable : IDisposable
    {
        private readonly List<IDisposable> _disposables;

        public CompositeDisposable(params IDisposable[] disposables)
        {
            _disposables = new List<IDisposable>(disposables);
        }

        public void Dispose()
        {
            if (IsDisposed)
                return;

            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }

            IsDisposed = true;
        }

        public bool IsDisposed { get; private set; }

        public int Count
        {
            get { return _disposables.Count; }
        }

        public void Add(IDisposable disposable)
        {
            _disposables.Add(disposable);
        }

        public void Add(Action disposeAction)
        {
            _disposables.Add(new Disposable(disposeAction));
        }
    }
}