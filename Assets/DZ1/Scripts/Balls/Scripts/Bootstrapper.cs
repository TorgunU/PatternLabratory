using System.Collections.Generic;
using UnityEngine;

namespace Assets.Patterns.DZ1.Balls
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private DZ2_Mediator.Player _player;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private List<Ball> _balls;
        [SerializeField] private Level _level;

        private void Awake()
        {
            InitPlayer();

            InitLevel();
        }

        private void InitPlayer()
        {
            //_playerMovement.Init(_playerInput);
        }

        private void InitLevel()
        {
            _level.Init(new OneTypeVictoryCondition(_balls, BallType.Green));
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                Debug.Log("”ничтожить все зеленые шары");
                _level.SetVictoryStratagy(new OneTypeVictoryCondition(_balls, BallType.Red));
            }
            else if (Input.GetKey(KeyCode.R))
            {
                Debug.Log("”ничтожить все шары");
                _level.SetVictoryStratagy(new AllBurstedCondition(_balls));
            }
        }
    }
}
