using Assets.Patterns.DZ_3_4;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Specialization
{
    protected CharacterStats _characterStats;

    public abstract string Name { get; }

    protected Specialization(CharacterStats characterStats)
    {
        _characterStats = characterStats;
    }
}
