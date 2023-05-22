using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectMovementAbstract : MonoBehaviour
{
    private GameObject thisObject_;
    private Rigidbody2D thisRigidbody_;
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
        thisRigidbody_.velocity=(direction*speed * Time.deltaTime);
    }
}
