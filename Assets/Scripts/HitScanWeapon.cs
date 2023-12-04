using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScanWeapon : Weapon
{
    public ParticleSystem HitParticle = null;
    

    public override bool Fire()
    {
        if (base.Fire() == false)
        {
            return false;
        }
        HitScan();
        return true;
    }

    private void HitScan()
    {
        Ray weaponRay = new Ray(CameraController.myCamera.transform.position, CameraController.myCamera.transform.forward);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(weaponRay, out hit, WeaponRange, HitMask))
        {
            HitParticle.transform.position = hit.point;
            HitParticle.Play();
            //DoHitStuff()
        }
    }
}