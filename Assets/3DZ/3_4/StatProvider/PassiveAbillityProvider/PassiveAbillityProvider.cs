using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAbillityProvider : IStatProvider
{
    private IStatProvider _statProvider;
    private PassiveAbillityType _abillityType;

    public PassiveAbillityProvider(IStatProvider statProvider, PassiveAbillityType abillityType)
    {
        _statProvider = statProvider;
        _abillityType = abillityType;
    }

    public CharacterStats GetCharacterStats()
    {
        switch (_abillityType)
        {
            case PassiveAbillityType.IncreaseAgility:
                ProvideAgilityIncreased();
                break;

            case PassiveAbillityType.DistributePower:
                ProvideDistributionStats();
                break;

            case PassiveAbillityType.MultiplyIntelligent:
                ProvideIntelligentMultiplication();
                break;
        }
        return _statProvider.GetCharacterStats();
    }

    private void ProvideAgilityIncreased()
    {
        CharacterStats stats = _statProvider.GetCharacterStats();
        stats.Strength.Increase(2);
        stats.Agility.Multiply(2);
    }

    private void ProvideDistributionStats()
    {
        CharacterStats stats = _statProvider.GetCharacterStats();
        stats.Strength.Increase(2);
        stats.Agility.Increase(2);
        stats.Intelligent.Increase(2);
    }

    private void ProvideIntelligentMultiplication()
    {
        CharacterStats stats = _statProvider.GetCharacterStats();
        stats.Intelligent.Multiply(2);
    }
}
