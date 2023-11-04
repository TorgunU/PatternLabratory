using UnityEngine;

namespace Assets.Patterns.DZ_3_1
{
    public abstract class ResourcesFactory : ScriptableObject
    {
        public abstract CoinViewer CreateCoinViewer(RectTransform coinRectTransform);
        public abstract EnergyViewer CreateEnergyViewer(RectTransform energyRectTransform);
    }
}