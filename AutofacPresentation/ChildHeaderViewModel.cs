namespace AutofacPresentation
{
    public class ChildHeaderViewModel: IHeaderViewModel
    {
        public ChildHeaderViewModel(HeaderTextFormatter headerTextFormatter, HeaderTextProvider headerTextProvider)
        {
            Text = headerTextFormatter.Format(headerTextProvider.Text);
        }

        public string Text { get; }
    }
}