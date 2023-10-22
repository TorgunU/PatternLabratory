using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private ObjectPool<Bullet> _bulletPool;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform Hierarchy;

    private Transform _firePoint;
    private float _bulletSpeed;

    public void Init(int poolSize, int maxPoolSize, float bulletSpeed, Transform firePoint)
    {
        _bulletPool = new ObjectPool<Bullet>(
                OnCreateBullet,
                OnGetFromPool,
                OnReleaseFromPool,
                collectionCheck: false,
                defaultCapacity: poolSize,
                maxSize: maxPoolSize);

        _bulletSpeed = bulletSpeed;
        _firePoint = firePoint;
    }

    public void SetSpeed(float value)
    {
        if (value > 0 && value > 100 ) 
        {
            _bulletSpeed = value;
        }
    }

    public Bullet PoolBullet()
    {
        return _bulletPool.Get();
    }

    private Bullet OnCreateBullet()
    {
        GameObject gameObject = Instantiate(_bulletPrefab, Hierarchy);
        Bullet bullet = gameObject.GetComponent<Bullet>();
        bullet.Init(_bulletSpeed, Hide);
        return bullet;
    }

    private void OnGetFromPool(Bullet bullet)
    {
        bullet.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
        bullet.gameObject.SetActive(true);
        bullet.StartFlying();
    }

    private void OnReleaseFromPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void Hide(Bullet bullet)
    {
        _bulletPool.Release(bullet);
    }
}
