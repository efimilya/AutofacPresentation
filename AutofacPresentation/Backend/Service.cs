namespace AutofacPresentation.Backend
{
    public class Service : IService
    {
        private readonly FirstStepAggregator _firstStepAggregator;
        private readonly SecondStepAggregator _secondStepAggregator;

        public Service(
            FirstStepAggregator firstStepAggregator,
            SecondStepAggregator secondStepAggregator)
        {
            _firstStepAggregator = firstStepAggregator;
            _secondStepAggregator = secondStepAggregator;
        }

        public int Calculate()
        {
            return _firstStepAggregator.Aggregate() +
                   _secondStepAggregator.Aggregate();
        }
    }
}