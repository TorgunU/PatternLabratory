public abstract class ShootStratagy : IShooteable
{
    protected BulletPool BulletPool;

    public ShootStratagy(BulletPool bulletPool, float bulletSpeed)
    {
        BulletPool = bulletPool;
        BulletPool.SetSpeed(bulletSpeed);
    }

    public abstract void Shoot();

    protected virtual Bullet PoolAmmo()
    {
        return BulletPool.PoolBullet();
    }
}
