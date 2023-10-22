using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Magazine
{
    private readonly int Capacity;

    private int _ammo;

    public int Ammo { get => _ammo; }

    public Magazine(int capacity)
    {
        Capacity = capacity;
        _ammo = Capacity;
    }

    public void ResetAmmo()
    {
        _ammo = Capacity;
    }

    public bool IsAmmoLeft()
    {
        return _ammo > 0;
    }

    public bool IsAmmoLeft(int value)
    {
        return _ammo - value > 0;
    }

    public bool TryReduceAmmo()
    {
        if (IsAmmoLeft() == false)
        {
            Debug.Log("No ammo");
            return false;
        }
        _ammo--;
        return true;
    }

    public bool TryReduceAmmo(int value)
    {
        if (IsAmmoLeft(value) == false)
        {
            Debug.Log("No ammo");
            return false;
        }
        _ammo -= value;
        return true;
    }
}
