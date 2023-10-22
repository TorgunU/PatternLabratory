using System;
using System.Collections;
using UnityEditor.Search;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float lifeTime = 60;

    private float _speed;

    public void Init(float speed, Action<Bullet> OnCollided)
    {
        _speed = speed;
        Collided += OnCollided;
    }

    public void StartFlying()
    {
        StartCoroutine(Flying());
    }

    private IEnumerator Flying()
    {
        float currentLifeTime = 0;
        yield return new WaitWhile(() =>
        {
            Vector2 newPosition = transform.position + transform.right * (Time.deltaTime * _speed);
            transform.position = newPosition;
            currentLifeTime += Time.deltaTime;
            return currentLifeTime <= lifeTime;
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Wall wall))
        {
            StopCoroutine(Flying());
            Collided?.Invoke(this);
        }
    }

    internal void ResetSpeed()
    {
        StopCoroutine(Flying());
        _speed = 0;
    }

    public event Action<Bullet> Collided;
}
