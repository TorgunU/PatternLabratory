using System;
using System.Diagnostics;

public class GunSwitcher
{
    private int _slotIndex = 0;
    private BulletPool _bulletPool;

    public GunSwitcher (BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public ShootStratagy ChangeGun()
    {
        _slotIndex = _slotIndex == 2 ? 0 : ++_slotIndex;
        switch (_slotIndex)
        {
            case 0:
                return new SingleShootStratagy(_bulletPool, 5, 10, 1);
            case 1:
                return new InfiniteShootStratagy(_bulletPool, 10);
            case 2:
                return new ThreeShootStratagy(_bulletPool, 20, 30, 1.5f);
            default:
                throw new Exception("Gun could't be created");
        }
    }
}
