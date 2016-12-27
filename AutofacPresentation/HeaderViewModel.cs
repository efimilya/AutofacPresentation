namespace AutofacPresentation
{

    public class HeaderTextFormatter
    {
        private readonly IFormatHeaderStrategy _formatHeaderStrategy;

        public HeaderTextFormatter(IFormatHeaderStrategy formatHeaderStrategy)
        {
            _formatHeaderStrategy = formatHeaderStrategy;
        }

        public string Format(string text)
        {
            text = text.Trim();
            return _formatHeaderStrategy.Format(text);
        }
    }

    public class HeaderTextProvider
    {
        public string Text => "          Общая информация. Секретная информация          ";
    }

    public class HeaderViewModel: IHeaderViewModel
    {
        public HeaderViewModel(HeaderTextFormatter headerTextFormatter, HeaderTextProvider headerTextProvider)
        {
            Text = headerTextFormatter.Format(headerTextProvider.Text);
        }

        public string Text { get; }
    }
}