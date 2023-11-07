using Assets.Patterns.DZ2_Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Dekstop _dekstop;
    [SerializeField] private Assets.Patterns.DZ2_Mediator.Player _player;

    public override void InstallBindings()
    {
        BindPlayerInput();
        BindPlayer();
    }

    private void BindPlayerInput()
    {
        Container.BindInstance(new InputActions());
        Dekstop dekstop = Container.InstantiatePrefabForComponent<Dekstop>(_dekstop,
            FindObjectOfType<PlayerMovement>().transform);
        Container.BindInterfacesAndSelfTo<PlayerInput>().FromInstance(dekstop).AsSingle();
    }

    private void BindPlayer()
    {
        Container.BindInterfacesAndSelfTo<Assets.Patterns.DZ2_Mediator.Player>()
            .FromInstance(_player).AsSingle();
    }
}
