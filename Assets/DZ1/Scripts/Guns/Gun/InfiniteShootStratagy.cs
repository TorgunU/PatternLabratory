using UnityEngine;

public class InfiniteShootStratagy : ShootStratagy
{
    public InfiniteShootStratagy(BulletPool bulletPool) : base(bulletPool)
    { }

    public override void Shoot()
    {
        PullBullet();
    }
}
