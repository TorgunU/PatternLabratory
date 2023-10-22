using System.Collections.Generic;
using UnityEngine;

namespace Assets.Patterns.Stratagy.Example
{
    public class PointByPointMover : IMover
    {
        private const float MinDistanceToTarget = 0.05f;

        private IMoveable _moveable;
        private Queue<Vector3> _targets;
        private Vector3 _currentTarget;
        private bool _isMoving;

        public PointByPointMover(IMoveable moveable, IEnumerable<Vector3> targets)
        {
            _moveable = moveable;
            _targets = new Queue<Vector3>(targets);
        }

        public void StartMove() => _isMoving = true;
        public void StopMove() => _isMoving = false;

        public void UpdateTarget(float deltaTime)
        {
            if (_isMoving == false)
            {
                return;
            }

            Vector3 direction = _currentTarget - _moveable.Transform.position;
            _moveable.Transform.Translate(_moveable.Speed * deltaTime * direction.normalized);

            if (direction.magnitude <= MinDistanceToTarget)
            {
                SwitchTarget();
            }
        }

        private void SwitchTarget()
        {
            if (_currentTarget != null)
            {
                _targets.Enqueue(_currentTarget);
            }

            _currentTarget = _targets.Dequeue();
        }
    }
}