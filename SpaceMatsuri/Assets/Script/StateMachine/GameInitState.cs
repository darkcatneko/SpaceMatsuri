using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitState : StateBase
{
    public GameInitState(StageManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("123");
    }

    public override void OnExit()
    {
        Debug.Log("GameFinishIniting");
    }

    public override void OnUpdate()
    {
        Debug.Log("GameIniting");
        if (GameManager.Instance.PlayerObject!=null)
        {
            GameManager.Instance.M_StageManager.TransitionState(State_Enum.Game_Start_State);
        }
    }
}
