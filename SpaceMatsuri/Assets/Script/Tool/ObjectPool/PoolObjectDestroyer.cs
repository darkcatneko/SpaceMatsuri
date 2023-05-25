using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class PoolObjectDestroyer : MonoBehaviour
{
    public ObjectPoolClass Pool { get; set; }

    public void ReleaseThisObject()
    {
        Pool.ReleaseGameObject(gameObject);
    }
}
