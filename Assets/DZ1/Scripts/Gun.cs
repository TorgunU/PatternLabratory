using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] protected BulletPool BulletPool;
    [SerializeField] protected Transform FirePoint;
    protected ShootStratagy ShootStratagy;

    public void Init(int poolSize, int maxPoolSize, float bulletSpeed,
        ShootStratagy shootStratagy)
    {
        BulletPool.Init(poolSize, maxPoolSize, bulletSpeed, FirePoint);
        ShootStratagy = shootStratagy;
    }

    public void Shoot()
    {
        ShootStratagy.Shoot();
        StartDelay();
    }

    public void Reload()
    {
        if(ShootStratagy is IReloadable reloadable)
        {
            reloadable.Reload();
        }
    }

    public void StartDelay()
    {
        if (ShootStratagy is IDelay delay)
        {
            if(delay.IsReseted == true)
            {
                StartCoroutine(delay.CalculatingDelay(Time.deltaTime));
            }
        }
    }

    public void SetShootStratagy(ShootStratagy shootStratagy)
    {
        ShootStratagy = shootStratagy;
    }
}
