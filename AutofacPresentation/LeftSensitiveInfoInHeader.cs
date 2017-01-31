namespace AutofacPresentation
{
    public class LeftSensitiveInfoInHeader : IFormatHeaderStrategy
    {
        public string Format(string header)
        {
            return header.Replace("Общая информация. ", "");            
        }
    }
}