
using Assets.Patterns.TemplateMethod.CoinExample;
using UnityEngine;

public class SilverCoin : Coin
{
    protected override void AddCoins(ICoinPicker coinPicker)
    {
        coinPicker.AddCoins(Value);
    }

    protected override void PlayAnimation()
    {
        Debug.Log("Play coin animation");
    }

    protected override void PlayAudioClip()
    {
        Debug.Log("Play pick coin audio");
    }
}
