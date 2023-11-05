using Assets.Patterns.DZ_3_4;

public class CharacterStats
{
    public Strength Strength { get; private set; }
    public Agility Agility { get; private set; }
    public Intelligent Intelligent { get; private set; }

    public CharacterStats(Strength strength, Agility agility, Intelligent intelligent)
    {
        Strength = strength;
        Agility = agility;
        Intelligent = intelligent;
    }

    public override string ToString()
    {
        return $"Strength: {Strength.Value}. " +
            $"Agility: {Agility.Value}. " +
            $"Intelligent: {Intelligent.Value}";
    }
}
