using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Patterns.TemplateMethod.CoinExample
{
    public abstract class Coin : MonoBehaviour
    {
        [SerializeField, Range(0, 50)] protected int Value;

        public event Action<Coin> PickedUp;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ICoinPicker coinPicker))
            {
                PlayAudioClip();
                PlayAnimation();
                AddCoins(coinPicker);
                PickedUp.Invoke(this);
            }
        }

        protected abstract void PlayAudioClip();
        protected abstract void PlayAnimation();
        protected abstract void AddCoins(ICoinPicker coinPicker);
    }
}