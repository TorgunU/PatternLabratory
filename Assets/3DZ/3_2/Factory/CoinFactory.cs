using UnityEngine;

[CreateAssetMenu(fileName = "CoinFactory", menuName = "SO/Coins/CoinFactory")]
public class CoinFactory : ScriptableObject
{
    [SerializeField] private RedCoin _redCoin;
    [SerializeField] private BlackCoin _blackCoin;
    [SerializeField] private GoldCoin _goldCoin;

    public RedCoin CreateRedCoin(Transform parent)
    {
        return Instantiate(_redCoin, parent);
    }

    public BlackCoin CreateBlackCoin(Transform parent)
    {
        return Instantiate(_blackCoin, parent);
    }

    public GoldCoin CreateGoldCoin(Transform parent)
    {
        return Instantiate(_goldCoin, parent);
    }

}
