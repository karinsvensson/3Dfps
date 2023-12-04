using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Ammunition;
    public WeaponState WeaponType = WeaponState.Total;
    
    public float WeaponRange = 100f;
    public LayerMask IgnoreHitMask = 0;

    protected Camera MainCam = null;

    protected void Start()
    {
        MainCam = Camera.main;
    }
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
