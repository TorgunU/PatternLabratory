using UnityEngine;

namespace Assets.Patterns.Stratagy.Example
{
    public interface IMoveable
    {
        Transform Transform { get; }
        float Speed { get; }
    }
}