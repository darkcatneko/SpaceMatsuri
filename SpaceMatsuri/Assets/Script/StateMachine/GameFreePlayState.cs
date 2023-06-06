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
        if (GameManager.Instance.IngamePlayerData.Now_TensionBar >(100+ 100 * GameManager.Instance.FeverCount)) 
        {
            GameManager.Instance.M_StageManager.TransitionState(State_Enum.Game_Fever_State);
        }
        GameManager.Instance.FreeGamePlayUpdater();        
    }
}
