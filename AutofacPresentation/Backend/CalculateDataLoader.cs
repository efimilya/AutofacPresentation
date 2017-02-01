using System.Threading.Tasks;

namespace AutofacPresentation.Backend
{
    public class CalculateDataLoader
    {
        private readonly OperationRepository _operationRepository;
        private readonly ProgramRepository _programRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly CalculateContext _context;

        public CalculateDataLoader(OperationRepository operationRepository, ProgramRepository programRepository, CustomerRepository customerRepository, CalculateContext context)
        {
            _operationRepository = operationRepository;
            _programRepository = programRepository;
            _customerRepository = customerRepository;
            _context = context;
        }

        public CalculateData Load()
        {
            var getOperation = Task.Run(() => _operationRepository.Get(_context.OperationName));
            var getProgram = Task.Run(() => _programRepository.Get(_context.ProgramId));
            var getCustomer = Task.Run(() => _customerRepository.Get(_context.CustomerId));
            Task.WaitAll(getOperation, getProgram, getCustomer);

            return new CalculateData(getOperation.Result, getProgram.Result, getCustomer.Result);
        }
    }
}