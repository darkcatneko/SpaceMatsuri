using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviorBase : ObjectMovementAbstract
{
    public Weapon ThisProjectileData;
    public Transform FaceTarget;
    public Vector3 FowardDirection;
    public bool IsBeenRelease = false;   
    public virtual void ReleaseThisObject()
    {
        if (!IsBeenRelease)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            FaceTarget = null;
            FowardDirection = Vector3.zero;
            IsBeenRelease = true;
            this.gameObject.GetComponent<PoolObjectDestroyer>().ReleaseThisObject();
        }       
    }
}
