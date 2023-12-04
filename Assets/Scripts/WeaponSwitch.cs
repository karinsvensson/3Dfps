using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState
{
    Unarmed,
    HitScan,
    Projectile,
    Total
}
public class WeaponSwitch : MonoBehaviour
{
    public Weapon[] AvailableWeapons = new Weapon[(int)WeaponState.Total];
    public Weapon CurrentWeapon = null;

    public float ScrollWheelBreakpoint = 1f;
    private float ScrollWheelDelta = 0f;
    

    public void Update()
    {
        HandleWeaponSwap();

        if (Input.GetMouseButton(0))
        {
            FireHeldWeapon();
        }
    }

    private void HandleWeaponSwap()
    {
        ScrollWheelDelta += Input.mouseScrollDelta.y;
        if (Mathf.Abs(ScrollWheelDelta) > ScrollWheelBreakpoint)
        {
            int swapDirectionNumber = (int)Mathf.Sign(ScrollWheelDelta);
            ScrollWheelDelta -= Mathf.Sign(ScrollWheelDelta) * ScrollWheelBreakpoint;

            int currentWeaponIndex = (int)CurrentWeapon.WeaponType;
            currentWeaponIndex += swapDirectionNumber;

            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = (int)WeaponState.Total + currentWeaponIndex;
            }
            if (currentWeaponIndex >= (int)WeaponState.Total)
            {
                currentWeaponIndex = 0;
            }
            WeaponSwapAnimation(currentWeaponIndex);
        }
    }

    private void WeaponSwapAnimation(int currentWeaponIndex)
    {
        CurrentWeapon.gameObject.SetActive(false);
        CurrentWeapon = AvailableWeapons[currentWeaponIndex];
        CurrentWeapon.gameObject.SetActive(true);
    }

    public void FireHeldWeapon()
    {
        if(CurrentWeapon != null)
        {
            CurrentWeapon.Fire();
        }
    }
}
