namespace AutofacPresentation.Backend
{
    public class CalculateContext
    {
        public readonly int CustomerId;
        public readonly int ProgramId;
        public readonly string OperationName;

        public CalculateContext(int customerId, int programId, string operationName)
        {
            CustomerId = customerId;
            ProgramId = programId;
            OperationName = operationName;
        }
    }
}