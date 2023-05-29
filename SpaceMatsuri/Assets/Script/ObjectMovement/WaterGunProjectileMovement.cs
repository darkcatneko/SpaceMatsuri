using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WaterGunProjectileMovement : WeaponBehaviorBase
{
    //public Weapon ThisProjectileData;

    protected override void ThisObjectStartInit()
    {
        //TargetLock(FaceTarget);
    }
    //protected override void Start()
    //{
    //    base.Start();
    //}
    public void TargetLock(Transform monster)
    {
        IsBeenRelease = false;
        FowardDirection = (monster.position - this.gameObject.transform.position).normalized;
        float angle = Vector3.SignedAngle(new Vector3(1,0,0), FowardDirection,Vector3.forward);
        this.gameObject.transform.Rotate(new Vector3(0,0,angle));
    }

    private void Update()
    {
        ThisObjectMove(FowardDirection, ThisProjectileData.MovementSpeed);
    }
    
}
