using System;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IShooter, ITradeable
{
    private GunSwitcher _gunSwitcher;
    private Gun _gun;
    private IAttackEvents _attackEvents;

    [Inject]
    public void Construct(IAttackEvents attackEvents, Gun gun, GunSwitcher gunBelt)
    {
        _attackEvents = attackEvents;
        _gun = gun;
        _gunSwitcher = gunBelt;
        _attackEvents.AttackPressed += OnAttackPressed;
    }

    private void OnDisable()
    {
        _attackEvents.AttackPressed -= OnAttackPressed;
    }

    private void Start()
    {
        SwitchGun();
    }

    private void OnAttackPressed()
    {
        Shoot();
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
