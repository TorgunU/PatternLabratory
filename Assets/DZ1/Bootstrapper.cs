using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Gun _playerGun;
    [SerializeField] private Transform _shotTranform;
    [SerializeField] private BulletFactory _bulletFactory;
    [SerializeField] private BulletPool _bulletPool;

    private GunSwitcher _gunSwitcher;

    private void Awake()
    {
        InitPlayerGun();
        InitPlayer();
    }

    private void InitPlayerGun()
    {
        _bulletPool.Init(_bulletFactory, _shotTranform);
        _gunSwitcher = new GunSwitcher(_bulletPool);
        _playerGun.Init(_gunSwitcher.ChangeGun());
    }

    private void InitPlayer()
    {
        _playerMovement.Init(_playerInput);
        _player.Init(_playerInput, _playerGun, _gunSwitcher);
    }
}
