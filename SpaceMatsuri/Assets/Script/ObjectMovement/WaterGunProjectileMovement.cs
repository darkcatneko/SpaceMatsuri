using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunProjectileMovement : ObjectMovementAbstract
{
    public Weapon ThisProjectileData;

    public void TargetLock(Transform monster)
    {
        thisObject_.transform.LookAt(monster);
    }

    private void Update()
    {
        ThisObjectMove(transform.forward, ThisProjectileData.MovementSpeed);
    }
}
