using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFeverState : StateBase
{
    public GameFeverState(StageManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("Into Fever!");
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }
}
