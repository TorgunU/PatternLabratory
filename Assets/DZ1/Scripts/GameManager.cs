using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _transform;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Gun _gun;

    private GunSwitcher _gunSwitcher;

    private void Awake()
    {
        _gunSwitcher = new GunSwitcher(_bulletPool);
        _gun.Init(10, 50, 5, _gunSwitcher.ChangeGun());
        _player.Init(_gun, _gunSwitcher);
    }
}
