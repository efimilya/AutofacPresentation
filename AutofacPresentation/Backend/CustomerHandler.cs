namespace AutofacPresentation.Backend
{
    public class CustomerHandler
    {
        private readonly CalculateData _data;

        public CustomerHandler(CalculateData data)
        {
            _data = data;
        }

        public int Handle()
        {
            return _data.Customer.Value;
        }
    }
}