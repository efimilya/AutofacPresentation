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

        public int Aggregate(Customer customer, Program program, Operation operation)
        {
            return _customerHandler.Handle(customer)*2 +
                   _programHandler.Handle(program)*2 +
                   _operationHandler.Handle(operation)*2;
        }
    }
}