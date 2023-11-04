using Assets.Patterns.TemplateMethod.CoinExample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCoin : Coin
{
    protected override void AddCoins(ICoinPicker coinPicker)
    {
        coinPicker.AddCoins(Value);
    }

    protected override void PlayAnimation()
    {
        Debug.Log(GetType());
    }

    protected override void PlayAudioClip()
    {
        
    }
}
