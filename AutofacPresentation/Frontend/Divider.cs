namespace AutofacPresentation.Frontend
{
    public class DivideHelper
    {
        public int Divide(int value1, int value2)
        {
            return value1/value2;
        }
    }

    public class Divider
    {
        private readonly DivideHelper _helper;
        private readonly int _value2;

        public Divider(int value2, DivideHelper helper)
        {
            _value2 = value2;
            _helper = helper;
        }

        public int Divide()
        {
            return _helper.Divide(100, _value2);
        }
    }
}