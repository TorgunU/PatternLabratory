using System;
using UnityEngine;

public class Player : MonoBehaviour, IShooter, ITradeable
{
    private GunSwitcher _gunSwitcher;
    private Gun _gun;

    public void Init(Gun gun, GunSwitcher gunBelt)
    {
        _gun = gun;
        _gunSwitcher = gunBelt;
    }

    private void Start()
    {
        SwitchGun();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchGun();
        }

        Request();
    }

    public void Shoot()
    {
        _gun.Shoot();
    }

    public void SwitchGun()
    {
        _gun.SetShootStratagy(_gunSwitcher.ChangeGun());
    }

    public void Request()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RequestTrade?.Invoke(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RequestTrade?.Invoke(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            RequestTrade?.Invoke(3);
        }
    }

    public event Action<int> RequestTrade;
}
