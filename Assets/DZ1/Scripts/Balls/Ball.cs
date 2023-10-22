using System;
using UnityEngine;

public abstract class Ball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Bursted != null && collision.TryGetComponent(out Bullet bullet))
        {
            Burst();
        }
    }

    protected void Burst()
    {
        Bursted?.Invoke(this);
        gameObject.SetActive(false);
    }

    public event Action<Ball> Bursted;
}
