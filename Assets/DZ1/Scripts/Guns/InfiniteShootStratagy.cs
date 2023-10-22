using UnityEngine;

public class InfiniteShootStratagy : ShootStratagy
{
    public InfiniteShootStratagy(BulletPool bulletPool, float bulletSpeed) : base(bulletPool, bulletSpeed)
    {
        bulletPool.SetSpeed(bulletSpeed);
    }

    public override void Shoot()
    {
        PoolAmmo();
    }
}
