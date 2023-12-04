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
    [Header("Unarmed = Element 0 \n" + 
        "Hitscan = Element 1 \n" +
        "Projectile = Element 2")]
    public Weapon[] AvailableWeapons = new Weapon[(int)WeaponState.Total];
    public Weapon CurrentWeapon = null;

    public float ScrollWheelBreakpoint = 1f;
    private float ScrollWheelDelta = 0f;


    public void Update()
    {
        HandleWeaponSwap();

        if (Input.GetMouseButtonUp(0) && CurrentWeapon != null)
        {
            CurrentWeapon.Fire();
        }
    }

    private void HandleWeaponSwap()
    {

        ScrollWheelDelta += Input.mouseScrollDelta.y;
        if (Mathf.Abs(ScrollWheelDelta) > ScrollWheelBreakpoint)
        {
            int swapDirection = (int)Mathf.Sign(ScrollWheelDelta);
            ScrollWheelDelta = 0.0f;

            int currentWeaponIndex = (int)CurrentWeapon.WeaponType;
            currentWeaponIndex += swapDirection;

            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = (int)WeaponState.Total + -1;
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

}
