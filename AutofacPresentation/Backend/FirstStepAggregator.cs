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

        public int Aggregate(Customer customer, Program program, Operation operation)
        {
            return (_customerHandler.Handle(customer) +
                   _programHandler.Handle(program) +
                   _operationHandler.Handle(operation)) * _globalServiceData.Value;
        }
    }
}