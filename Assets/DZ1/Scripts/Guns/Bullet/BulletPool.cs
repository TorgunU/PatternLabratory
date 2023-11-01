using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    private BulletFactory _bulletFactory;
    private Transform _shotTranform;
    private ObjectPool<Bullet> _pool;

    public void Init(BulletFactory bulletFactory, Transform shotTransform)
    {
        _bulletFactory = bulletFactory;
        _shotTranform = shotTransform;
        _pool = new ObjectPool<Bullet>(OnCreateBullet, OnGetFromPool, OnReleaseFromPool,
            OnBulletDestroy);
        CreateStartCount();
    }

    public Bullet PullBullet()
    {
        return _pool.Get();
    }

    private void CreateStartCount()
    {
        Bullet bullet;
        for (int i = 0; i < 6; i++)
        {
            bullet = _pool.Get();
            _pool.Release(bullet);
        }
    }

    private Bullet OnCreateBullet()
    {
        Bullet bullet = _bulletFactory.CreateBullet();
        bullet.transform.SetParent(transform);
        bullet.Collided += OnBulletCollided;
        return bullet;
    }

    private void OnGetFromPool(Bullet bullet)
    {
        bullet.transform.SetPositionAndRotation(_shotTranform.position, _shotTranform.rotation);
        bullet.gameObject.SetActive(true);
        bullet.StartFlying();
    }

    private void OnReleaseFromPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnBulletCollided(Bullet bullet)
    {
        _pool.Release(bullet);
    }

    private void OnBulletDestroy(Bullet bullet)
    {
        bullet.Collided -= OnBulletCollided;
    }
}
