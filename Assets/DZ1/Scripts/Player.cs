using UnityEngine;

public class Player : MonoBehaviour, IShooter
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
    }

    public void Shoot()
    {
        _gun.Shoot();
    }

    public void SwitchGun()
    {
        _gun.SetShootStratagy(_gunSwitcher.ChangeGun());
    }
}
