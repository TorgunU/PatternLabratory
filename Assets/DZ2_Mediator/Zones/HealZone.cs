using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Patterns.DZ2_Mediator
{
    public class HealZone : MonoBehaviour
    {
        private float _heal = 20;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IHealable healable))
            {
                healable.Heal(_heal);
            }
        }
    }
}