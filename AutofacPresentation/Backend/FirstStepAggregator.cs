namespace AutofacPresentation.Backend
{
    public class FirstStepAggregator
    {
        private readonly CustomerHandler _customerHandler;
        private readonly OperationHandler _operationHandler;
        private readonly ProgramHandler _programHandler;
        private readonly GlobalServiceData _globalServiceData;

        public FirstStepAggregator(CustomerHandler customerHandler,
            OperationHandler operationHandler,
            ProgramHandler programHandler,
            GlobalServiceData globalServiceData)
        {
            _customerHandler = customerHandler;
            _operationHandler = operationHandler;
            _programHandler = programHandler;
            _globalServiceData = globalServiceData;
        }

        public int Aggregate()
        {
            return (_customerHandler.Handle() +
                   _programHandler.Handle() +
                   _operationHandler.Handle()) * _globalServiceData.Value;
        }
    }
}