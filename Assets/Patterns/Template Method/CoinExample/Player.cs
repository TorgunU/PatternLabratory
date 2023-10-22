using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Patterns.TemplateMethod.CoinExample
{
    public class Player : MonoBehaviour, ICoinPicker
    {
        public int Coins { get; private set; }

        public void AddCoins(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            Coins += value;
            Debug.Log(Coins);
        }
    }
}