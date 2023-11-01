using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Pool Factory", menuName = "SO/Factories")]
public class BulletFactory : ScriptableObject
{
    [SerializeField] private BulletConfig _bulletConfig;

    public Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(_bulletConfig.Prefab);
        bullet.Init(_bulletConfig.Speed);
        return bullet;
    }
}
