namespace AutofacPresentation.Backend
{
    public class ProgramHandler
    {
        private readonly CalculateData _data;

        public ProgramHandler(CalculateData data)
        {
            _data = data;
        }

        public int Handle()
        {
            return _data.Program.Value;
        }
    }
}