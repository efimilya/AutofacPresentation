namespace AutofacPresentation.Backend
{
    public class Service : IService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly FirstStepAggregator _firstStepAggregator;
        private readonly OperationRepository _operationRepository;
        private readonly ProgramRepository _programRepository;
        private readonly SecondStepAggregator _secondStepAggregator;

        public Service(CustomerRepository customerRepository,
            ProgramRepository programRepository,
            OperationRepository operationRepository,
            FirstStepAggregator firstStepAggregator,
            SecondStepAggregator secondStepAggregator)
        {
            _customerRepository = customerRepository;
            _programRepository = programRepository;
            _operationRepository = operationRepository;
            _firstStepAggregator = firstStepAggregator;
            _secondStepAggregator = secondStepAggregator;
        }

        public int Calculate(int customerId, int programId, string operationName)
        {
            var customer = _customerRepository.Get(customerId);
            var program = _programRepository.Get(programId);
            var operation = _operationRepository.Get(operationName);

            return _firstStepAggregator.Aggregate(customer, program, operation) +
                   _secondStepAggregator.Aggregate(customer, program, operation);
        }
    }
}