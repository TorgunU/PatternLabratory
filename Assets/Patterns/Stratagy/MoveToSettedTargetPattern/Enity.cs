using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Patterns.Stratagy.Example
{
    public abstract class Enity : MonoBehaviour
    {
        private IEnityFinder _enityFinder;

        private bool _isInit;

        public void Init(IEnityFinder enityFinder)
        {
            _enityFinder = enityFinder;
            _isInit = true;
        }

        private void Update()
        {
            if (_isInit == false)
            {
                throw new InvalidOperationException(nameof(_isInit));
            }

            IEnumerable<Enity> enities = _enityFinder.Find();

            if (enities != null)
            {
                Affect(enities);
            }
        }

        protected abstract void Affect(IEnumerable<Enity> enities);
    }
}