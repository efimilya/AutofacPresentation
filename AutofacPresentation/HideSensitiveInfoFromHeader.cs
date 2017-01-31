using System.Linq;

namespace AutofacPresentation
{
    public class HideSensitiveInfoFromHeader : IFormatHeaderStrategy
    {
        public string Format(string header)
        {
            return header.Replace("Секретная информация", "");
        }
    }
}