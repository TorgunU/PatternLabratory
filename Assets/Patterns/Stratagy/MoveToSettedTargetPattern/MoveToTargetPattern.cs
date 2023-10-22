using UnityEngine;


namespace Assets.Patterns.Stratagy.Example
{
    public class MoveToTargetPattern : IMover
    {
        private Transform _target;
        private IMoveable _moveable;
        private bool _isMoving;

        public MoveToTargetPattern(Transform target, IMoveable moveable)
        {
            _target = target;
            _moveable = moveable;
        }

        public void StartMove() => _isMoving = true;

        public void StopMove() => _isMoving = false;

        public void UpdateTarget(float deltaTime)
        {
            if (_isMoving == false)
                return;

            Vector2 direction = _target.position - _moveable.Transform.position;
            _moveable.Transform.Translate(_moveable.Speed * deltaTime * direction.normalized);
        }
    }
}