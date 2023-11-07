using Assets.Patterns.DZ2_Mediator;
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private HealthViewer _healthViewer;
    [SerializeField] private LevelViewer _levelViewer;

    public override void InstallBindings()
    {
        InstallHealthViewer();
        InstalLevelViewer();
    }

    public void InstallHealthViewer()
    {
        Container.Bind<HealthViewer>().FromInstance(_healthViewer).AsSingle().NonLazy();
    }

    public void InstalLevelViewer()
    {
        Container.Bind<LevelViewer>().FromInstance(_levelViewer).AsSingle().NonLazy();
    }
}