namespace Assets.Patterns.DZ_3_4
{
    public abstract class Stat : IStatCalculator
    {
        public int Value { get; protected set; }

        public abstract string Name { get; }

        public Stat(int value)
        {
            Value = value;
        }

        public void Increase(int value)
        {
            Value += value;
        }

        public void Multiply(int value)
        {
            Value *= value;
        }
    }
}