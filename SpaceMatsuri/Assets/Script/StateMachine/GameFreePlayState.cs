using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFreePlayState : StateBase
{
     public GameFreePlayState(StageManager m) : base(m)
    {
    }

    public override void OnEnter()
    {

    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        GameManager.Instance.FreeGamePlayUpdater();
    }
}
