using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Patterns.DZ_3_4
{
    public interface IStatCalculator
    {
        void Increase(int value);
        void Multiply(int value);
    }
}