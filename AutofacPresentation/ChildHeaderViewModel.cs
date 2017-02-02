using System;

namespace AutofacPresentation
{
    public class ChildHeaderViewModel: IHeaderViewModel, IDisposable
    {
        public ChildHeaderViewModel(HeaderTextFormatter headerTextFormatter, HeaderTextProvider headerTextProvider)
        {
            Text = headerTextFormatter.Format(headerTextProvider.Text);
        }

        public string Text { get; }
        public void Dispose()
        {
            
        }
    }
}