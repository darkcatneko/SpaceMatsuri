using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartState : StateBase
{
    public GameStartState(StageManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        
        GameManager.Instance.GameStart();
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }
}
