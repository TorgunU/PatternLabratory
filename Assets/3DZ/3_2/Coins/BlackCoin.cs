using UnityEngine;
using Assets.Patterns.TemplateMethod.CoinExample;

public class BlackCoin : Coin
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
