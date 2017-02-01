namespace AutofacPresentation.Frontend
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
}