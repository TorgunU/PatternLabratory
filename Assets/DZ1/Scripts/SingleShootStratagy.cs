using System.Collections;
using UnityEngine;

public class SingleShootStratagy : ShootStratagy, IDelay, IReloadable
{
    public Magazine Magazine { get; set; }

    public float Delay { get; set; }
    public bool IsReseted { get; set; }

    public SingleShootStratagy(BulletPool bulletPool, float bulletSpeed, int magazineSize, float shootDelay)
        : base(bulletPool, bulletSpeed)
    {
        Magazine = new Magazine(magazineSize);
        Delay = shootDelay;
        IsReseted = true;
        BulletPool.SetSpeed(bulletSpeed);
    }

    public override void Shoot()
    {
        if (IsReseted == false 
            || Magazine.TryReduceAmmo() == false)
        {
            // play audio clip and etc
            return;
        }

        PoolAmmo();
    }

    public void Reload()
    {
        Magazine.ResetAmmo();
    }

    public void ResetDelay()
    {
        IsReseted = true;
    }

    public IEnumerator CalculatingDelay(float deltaTime)
    {
        IsReseted = false;
        float currentLifeTime = 0;
        yield return new WaitWhile(() =>
        {
            currentLifeTime += deltaTime;
            return currentLifeTime <= Delay;
        });
        ResetDelay();
    }
}
