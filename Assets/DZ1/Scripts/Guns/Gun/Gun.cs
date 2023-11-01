using UnityEngine;

public class Gun : MonoBehaviour
{
    private ShootStratagy ShootStratagy;

    public void Init(ShootStratagy shootStratagy)
    {
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
