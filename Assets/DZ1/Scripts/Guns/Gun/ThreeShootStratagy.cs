using System.Collections;
using UnityEngine;

public class ThreeShootStratagy : ShootStratagy, IDelay, IReloadable
{
    private const int ShotCount = 3;
    private const float Spacing = 0.3f;

    public Magazine Magazine { get; set; }

    public float Delay { get; set; }
    public bool IsReseted { get; set; }

    public ThreeShootStratagy(BulletPool bulletPool, int magazineSize, float shootDelay)
        : base(bulletPool)
    {
        Magazine = new Magazine(magazineSize);
        Delay = shootDelay;
        IsReseted = true;
    }

    public override void Shoot()
    {
        for (int i = 0; i < ShotCount; i++)
        {
            if (IsReseted == false || Magazine.TryReduceAmmo() == false)
            {
                // play audio clip and etc
                return;
            }

            Bullet bullet = PullBullet();
            SetBulletSpacing(bullet.transform, i);
        }
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

    private void SetBulletSpacing(Transform bulletTransform, int iteration)
    {
        bulletTransform.position += new Vector3(Spacing * iteration, 0);
    }
}