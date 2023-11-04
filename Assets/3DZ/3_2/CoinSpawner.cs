using Assets.Patterns.TemplateMethod.CoinExample;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.UI;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{ 
    [SerializeField] private Transform _coinsParent;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private CoinFactory _coinFactory;

    private List<Coin> _coins;
    private List<Transform> _freePoints;

    private void Start()
    {
        _coins = new List<Coin>(_points.Capacity);
        _freePoints = new List<Transform>(_points);
        Spawn();
    }

    public void OnPickedUp(Coin coin)
    {
        _coins.Remove(coin);
        Destroy(coin.gameObject);
    }

    public void Spawn()
    {
        for (int i = 0; i < _points.Count; i++)
        {
            Coin coin = GetRandomCoin();
            coin.PickedUp += OnPickedUp;          

            Transform coinTransform = GetRandomPointPosition();
            coin.transform.position = coinTransform.position;
            _freePoints.Remove(coinTransform);
            _coins.Add(coin);
        }
    }

    private Coin GetRandomCoin()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                return _coinFactory.CreateBlackCoin(_coinsParent);

            case 1:
                return _coinFactory.CreateRedCoin(_coinsParent);

            case 2:
                return _coinFactory.CreateGoldCoin(_coinsParent);

            default:
                throw new System.Exception();
        }
    }

    private Transform GetRandomPointPosition()
    {
        return _freePoints[Random.Range(0, _freePoints.Count)];
    }
}
