using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectMovementAbstract : MonoBehaviour
{
    protected GameObject thisObject_;
    protected Rigidbody2D thisRigidbody_;
    protected virtual void Start()
    {
        thisObject_ = this.gameObject;
        thisRigidbody_ = thisObject_.GetComponent<Rigidbody2D>();
        ThisObjectStartInit();
    }
    protected virtual void ThisObjectStartInit()
    {
      
    }
    protected virtual void ThisObjectMove(Vector3 direction, float speed)
    {
        var objectRigibody = (direction * speed);
        thisRigidbody_.velocity = objectRigibody;
    }
    protected virtual void ThisObjectBeenAttack(float damage)
    {

    }
}
