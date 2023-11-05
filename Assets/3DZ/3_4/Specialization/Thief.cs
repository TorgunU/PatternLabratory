using Assets.Patterns.DZ_3_4;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Specialization
{
    public override string Name => "Вор";

    public Thief(CharacterStats characterStats) : base(characterStats)
    {

    }
}
