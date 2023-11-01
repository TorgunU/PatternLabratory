using System;

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
                return new SingleShootStratagy(_bulletPool, 10, 1);
            case 1:
                return new InfiniteShootStratagy(_bulletPool);
            case 2:
                return new ThreeShootStratagy(_bulletPool, 7, 1.5f);
            default:
                throw new Exception("Gun could't be created");
        }
    }
}
