public abstract class ShootStratagy : IShooteable
{
    protected BulletPool BulletPool;

    public ShootStratagy(BulletPool bulletPool)
    {
        BulletPool = bulletPool;
    }

    public abstract void Shoot();

    protected virtual Bullet PullBullet()
    {
        return BulletPool.PullBullet();
    }
}
