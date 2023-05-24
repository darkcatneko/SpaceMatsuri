using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class MainGameEvent
{
    public UnityEvent GameInitEvent = new UnityEvent();
    public UnityEvent GameStartEvent = new UnityEvent();
    public UnityEvent<Vector3, float> PlayerMovement = new UnityEvent<Vector3, float>();
}
