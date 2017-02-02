using System;

namespace AutofacPresentation
{
    public class HeaderTextProvider: IDisposable 
    {
        public string Text => "          Общая информация. Секретная информация          ";
        public void Dispose()
        {
            
        }
    }
}