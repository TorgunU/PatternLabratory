public class RaceProvider : IStatProvider
{
    private RaceType _raceType;
    private CharacterStats _stats;

    public RaceProvider(CharacterStats stats, RaceType raceType)
    {
        _stats = stats;
        _raceType = raceType;
    }

    public CharacterStats GetCharacterStats()
    {
        switch (_raceType)
        {
            case RaceType.Ork:
                ProvideOrk();
                break;

            case RaceType.Human:
                ProvideHuman();
                break;

            case RaceType.Elf:
                ProvideElf();
                break;
        }
        return _stats;
    }

    private void ProvideOrk()
    {
        _stats.Strength.Multiply(2);
    }

    private void ProvideHuman()
    {
        _stats.Strength.Increase(2);
        _stats.Intelligent.Increase(2);
        _stats.Agility.Increase(2);
    }

    private void ProvideElf()
    {
        _stats.Intelligent.Multiply(2);
        _stats.Agility.Increase(1);
    }
}
