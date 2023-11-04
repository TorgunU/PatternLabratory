using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Patterns.DZ2_Mediator
{
    public class MediatorBoostrapper : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private PlayerMovement _playerMovement;

        private void Awake()
        {
            InitPlayer();
        }

        private void InitPlayer()
        {
            _playerMovement.Init(_playerInput);
        }

    }
}