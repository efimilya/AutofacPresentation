namespace AutofacPresentation.Backend
{
    public class CalculateData
    {
        public readonly Customer Customer;
        public readonly Operation Operation;
        public readonly Program Program;

        public CalculateData(Operation operation, Program program, Customer customer)
        {
            Operation = operation;
            Program = program;
            Customer = customer;
        }
    }
}