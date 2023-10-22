using System.Collections.Generic;
using UnityEngine;

namespace Assets.Patterns.Stratagy.Example
{
    public class FrontSearchPattern : IEnityFinder
    {
        private float _viewingRange;
        private Transform _center;

        public FrontSearchPattern(float viewingRange, Transform center)
        {
            _viewingRange = viewingRange;
            _center = center;
        }

        public IEnumerable<Enity> Find()
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(_center.position, _center.forward, _viewingRange);

            List<Enity> findedEnities = new List<Enity>();

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.TryGetComponent(out Enity enity))
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