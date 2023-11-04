using Assets.Patterns.TemplateMethod.CoinExample;
using UnityEngine;

public class GoldCoin : Coin
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
