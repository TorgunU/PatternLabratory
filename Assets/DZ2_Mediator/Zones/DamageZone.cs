using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Patterns.DZ2_Mediator
{
    public class DamageZone : MonoBehaviour
    {
        private float _damage = 20;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(_damage);
            }
        }
    }
}