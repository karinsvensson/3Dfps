using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Projectile
{
    public override void Init(Vector3 aSpawnPosition, Vector3 anAimPosition)
    {
        base.Init(aSpawnPosition, anAimPosition);
    }
    public override void Update()
    {
        base.Update();
        transform.position += AimDirection.normalized * MovementSpeed * Time.deltaTime;
        
    }
}
