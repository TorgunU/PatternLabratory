using UnityEngine;

namespace Assets.Patterns.DZ_3_1
{
    public class ResourcesExample : MonoBehaviour
    {
        [SerializeField] private RectTransform _coinViewerSlot;
        [SerializeField] private RectTransform _energyViewerSlot;
        [SerializeField] private MenuResourcesFactory _menuResourcesFactory;
        [SerializeField] private ShopResourcesFactory _shopResourcesFactory;

        [SerializeField] private FactoryType _factoryType;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CreateIcons();
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                Clean();
            }
        }

        private ResourcesFactory GetFactory(FactoryType factoryType)
        {
            switch (factoryType)
            {
                case FactoryType.Shop:
                    return _shopResourcesFactory;

                case FactoryType.Menu:
                    return _menuResourcesFactory;

                default:
                    throw new System.Exception();
            }
        }

        private void CreateIcons()
        {
            ResourcesFactory factory = GetFactory(_factoryType);
            factory.CreateEnergyViewer(_energyViewerSlot);
            factory.CreateCoinViewer(_coinViewerSlot);
        }

        private void Clean()
        {
            Destroy(_coinViewerSlot.GetComponentInChildren<CoinViewer>().gameObject);
            Destroy(_energyViewerSlot.GetComponentInChildren<EnergyViewer>().gameObject);
        }
    }
}