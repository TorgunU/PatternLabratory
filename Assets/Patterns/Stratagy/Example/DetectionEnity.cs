using UnityEngine;

namespace Assets.Patterns.Stratagy.Example
{
    public class DetectionEnity : MonoBehaviour, IMoveable
    {
        [SerializeField] private float _speed;

        private IMover _mover;

        public float Speed { get => _speed; private set => _speed = value; }

        public Transform Transform => transform;

        private void Update()
        {
            _mover.UpdateTarget(Time.deltaTime);
        }

        public void SetMover(IMover mover)
        {
            _mover?.StopMove();
            _mover = mover;
            _mover.StartMove();
        }
    }
}