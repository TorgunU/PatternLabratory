using Assets.Patterns.DZ2_Mediator;
using UnityEngine;
using Zenject;

public class GameplayMediatorInstaller : MonoInstaller
{
    [SerializeField] private RestartPanel _restartPanel;

    public override void InstallBindings()
    {
        InstallRestartPanel();
        InstallMediator();
    }

    public void InstallRestartPanel()
    {
        Container.Bind<RestartPanel>().FromInstance(_restartPanel).AsSingle();
    }

    public void InstallMediator()
    {
        Container.BindInterfacesAndSelfTo<GameplayMediator>().AsSingle().NonLazy();
    }
}
