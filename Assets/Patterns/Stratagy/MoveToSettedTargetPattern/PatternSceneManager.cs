using Assets.Patterns.Stratagy.Example;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Patterns.Stratagy.Example
{
    public class PatternSceneManager : MonoBehaviour
    {
        [SerializeField] private DetectionEnity _detectionEnity;
        [SerializeField] private Transform _target;
        [SerializeField] private List<Transform> _patrolPoints;

        private void Awake()
        {
            _detectionEnity.SetMover(new NoMovePattern());
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                Debug.Log("Остановка");
                _detectionEnity.SetMover(new NoMovePattern());
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                Debug.Log("Патруль Города");
                _detectionEnity.SetMover(
                    new PointByPointMover(
                        _detectionEnity,
                        _patrolPoints.Select(point => point.position)));
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                Debug.Log("Преследую преступника");
                _detectionEnity.SetMover(new MoveToTargetPattern(
                    _target,
                    _detectionEnity));
            }
        }

    }
}