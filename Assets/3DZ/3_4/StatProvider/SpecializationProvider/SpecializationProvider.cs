public class SpecializationProvider : IStatProvider
{
    private IStatProvider _statProvider;
    private SpecializationType _specializationType;

    public SpecializationProvider(IStatProvider statProvider, SpecializationType specializationType)
    {
        _statProvider = statProvider;
        _specializationType = specializationType;
    }

    public CharacterStats GetCharacterStats()
    {
        switch (_specializationType)
        {
            case SpecializationType.Thief:
                ProvideThief();
                break;

            case SpecializationType.Barbar:
                ProvideBarbar();
                break;

            case SpecializationType.Mage:
                ProvideMage();
                break;
        }

        return _statProvider.GetCharacterStats();
    }

    private void ProvideThief()
    {
        CharacterStats stats = _statProvider.GetCharacterStats();
        stats.Strength.Increase(2);
        stats.Agility.Multiply(2);
    }

    private void ProvideBarbar()
    {
        CharacterStats stats = _statProvider.GetCharacterStats();
        stats.Strength.Increase(2);
        stats.Agility.Increase(2);
    }

    private void ProvideMage()
    {
        CharacterStats stats = _statProvider.GetCharacterStats();
        stats.Intelligent.Multiply(2);
    }
}
