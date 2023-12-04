using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Ammunition;
    public WeaponState WeaponType = WeaponState.Total;
    public float WeaponRange = 100f;
    public LayerMask HitMask = 0;

    public virtual bool Fire()
    {
        if (Ammunition < 1)
        {
            return false;
        }
        Ammunition--;
        return true;
    }
}
