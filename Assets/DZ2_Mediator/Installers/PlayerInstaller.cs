using UnityEngine;
using Zenject;

namespace Assets.Patterns.DZ4_3
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Dekstop _dekstop;
        [SerializeField] private DZ2_Mediator.Player _prefab;

        private DZ2_Mediator.Player _player;

        public override void InstallBindings()
        {
            InstallPlayerInput();
            InstallPlayer();
        }

        private void InstallPlayer()
        {
            _player = Container.InstantiatePrefabForComponent<DZ2_Mediator.Player>(_prefab);
            Container.BindInterfacesAndSelfTo<DZ2_Mediator.Player>().FromInstance(_player).AsSingle();
        }

        private void InstallPlayerInput()
        {
            Container.BindInstance(new InputActions()).AsSingle().NonLazy();
            Dekstop dekstop = Container.InstantiatePrefabForComponent<Dekstop>(_dekstop);
            Container.BindInterfacesAndSelfTo<Dekstop>().FromInstance(dekstop).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerMovement>().AsSingle();
        }
    }
}