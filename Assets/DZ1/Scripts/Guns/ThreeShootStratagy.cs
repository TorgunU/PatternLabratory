using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ThreeShootStratagy : ShootStratagy, IDelay, IReloadable
{
    private const int ShotExpenditure = 3;

    public Magazine Magazine { get; set; }

    public float Delay { get; set; }
    public bool IsReseted { get; set; }

    public ThreeShootStratagy(BulletPool bulletPool, float bulletSpeed, int magazineSize, float shootDelay)
        : base(bulletPool, bulletSpeed)
    {
        bulletPool.SetSpeed(bulletSpeed);
        Magazine = new Magazine(magazineSize);
        Delay = shootDelay;
        IsReseted = true;
    }

    public override void Shoot()
    {
        if (IsReseted == false
            || Magazine.TryReduceAmmo() == false)
        {
            // play audio clip and etc
            return;
        }

        SetBulletPosition(PoolAmmo(), 0);
        SetBulletPosition(PoolAmmo(), 1);
        SetBulletPosition(PoolAmmo(), 2);
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
            currentLifeTime += Time.deltaTime;
            return currentLifeTime <= Delay;
        });
        ResetDelay();
    }

    private void SetBulletPosition(Bullet bullet, int xPos)
    {
        bullet.transform.position = bullet.transform.position + new Vector3(xPos, 0);
    }
}