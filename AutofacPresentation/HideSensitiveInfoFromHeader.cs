using System.Linq;

namespace AutofacPresentation
{
    public interface IFormatHeaderStrategy
    {
        string Format(string header);
    }


    public class HideSensitiveInfoFromHeader : IFormatHeaderStrategy
    {
        public string Format(string header)
        {
            return header.Replace("Секретная информация", "");
        }
    }

    public class LeftSensitiveInfoInHeader : IFormatHeaderStrategy
    {
        public string Format(string header)
        {
            return header.Replace("Общая информация. ", "");            
        }
    }
}