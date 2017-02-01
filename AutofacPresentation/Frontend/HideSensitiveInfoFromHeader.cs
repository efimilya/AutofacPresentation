namespace AutofacPresentation.Frontend
{
    public class HideSensitiveInfoFromHeader : IFormatHeaderStrategy
    {
        public string Format(string header)
        {
            return header.Replace("Секретная информация", "");
        }
    }
}