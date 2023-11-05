namespace Assets.Patterns.DZ_3_4
{
    public class Agility : Stat
    {
        private Stat _stat;

        public Agility(int value) : base(value)
        {
        }

        public override string Name => "Ловкость";
    }
}