using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Config", menuName = "SO/Bullets")]
public class BulletConfig : ScriptableObject
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _speed;

    public Bullet Prefab => _prefab;
    public float Speed => _speed; 
}
