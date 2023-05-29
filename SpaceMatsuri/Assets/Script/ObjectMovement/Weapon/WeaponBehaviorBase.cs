using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviorBase : ObjectMovementAbstract
{
    public Weapon ThisProjectileData;
    public Transform FaceTarget;
    public Vector3 FowardDirection;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            FaceTarget = null;
            FowardDirection = Vector3.zero;
            this.gameObject.GetComponent<PoolObjectDestroyer>().ReleaseThisObject();
        }
    }
}
