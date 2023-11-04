using Assets.Patterns.DZ_3_1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Patterns.DZ_3_1
{
    [CreateAssetMenu(fileName = "ShopResourcesFactory", menuName = "SO/Resources/ShopResourcesFactory")]
    public class ShopResourcesFactory : ResourcesFactory
    {
        [SerializeField] protected CoinViewer CoinViewer;
        [SerializeField] protected EnergyViewer EnergyViewer;

        public override CoinViewer CreateCoinViewer(RectTransform coinRectTransform)
        {
            CoinViewer viewer = Instantiate(CoinViewer, coinRectTransform);
            viewer.transform.position = coinRectTransform.position;
            return viewer;
        }

        public override EnergyViewer CreateEnergyViewer(RectTransform energyRectTransform)
        {
            EnergyViewer viewer = Instantiate(EnergyViewer, energyRectTransform);
            viewer.transform.position = energyRectTransform.position;
            return viewer;
        }
    }
}