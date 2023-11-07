using System;
using UnityEngine;

namespace Assets.Patterns.DZ1.Balls
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private BallType _ballType;

        public BallType BallType { get => _ballType; set => _ballType = value; }
        public bool IsBursted { get; private set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out DZ2_Mediator.Player player))
            {
                Burst();
            }
        }

        private void Burst()
        {
            IsBursted = true;
            gameObject.SetActive(false);
            Bursted.Invoke(this);
        }

        public event Action<Ball> Bursted;
    }
}