namespace AutofacPresentation.Backend
{
    public class OperationHandler
    {
        private readonly CalculateData _data;

        public OperationHandler(CalculateData data)
        {
            _data = data;
        }

        public int Handle()
        {
            return _data.Operation.Value;
        }
    }
}