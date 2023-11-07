using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Patterns.DZ2_Mediator
{
    public class MediatorBoostrapper : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private GameplayMediator _gameplayMediator;
        [SerializeField] private RestartPanel _restartPanel;

        //private void Awake()
        //{
        //    InitPlayer();
        //    InitMediator();
        //    InitRestartPanel();
        //}

        //private void InitPlayer()
        //{
        //    _playerMovement.Init(_playerInput);
        //}

        //private void InitMediator()
        //{
        //    _gameplayMediator.Init(_player);
        //}

        //private void InitRestartPanel()
        //{
        //    _restartPanel.Init(_gameplayMediator);
        //}
    }
}