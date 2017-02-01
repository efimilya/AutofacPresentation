namespace AutofacPresentation.Backend
{
    public class SecondStepAggregator
    {
        private readonly CustomerHandler _customerHandler;
        private readonly OperationHandler _operationHandler;
        private readonly ProgramHandler _programHandler;

        public SecondStepAggregator(CustomerHandler customerHandler,
            OperationHandler operationHandler,
            ProgramHandler programHandler)
        {
            _customerHandler = customerHandler;
            _operationHandler = operationHandler;
            _programHandler = programHandler;
        }

        public int Aggregate()
        {
            return _customerHandler.Handle()*2 +
                   _programHandler.Handle()*2 +
                   _operationHandler.Handle()*2;
        }
    }
}