using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Patterns.Stratagy.Example
{
    public class SearchGroundPattern : IEnityFinder
    {
        private Transform _center;
        private float _radius;

        public SearchGroundPattern(Transform center, float radius)
        {
            _center = center;
            _radius = radius;
        }

        public IEnumerable<Enity> Find()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_center.position, _radius);

            List<Enity> findedEnities = new List<Enity>();

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out Enity enity))
                {
                    if (enity.transform != _center)
                    {
                        findedEnities.Add(enity);
                    }
                }
            }
            return findedEnities;
        }
    }
}