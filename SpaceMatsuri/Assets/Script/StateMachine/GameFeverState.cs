using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameFeverState : StateBase
{
    public float FeverStateEndTime;
    public GameFeverState(StageManager m) : base(m)
    {
        FeverStateEndTime = GameManager.Instance.IngamePlayerData.FeverTimeLastTime+Time.time;
    }

    public override void OnEnter()
    {
        Debug.Log("Into Fever!");
        GameManager.Instance.EnterFevertime();
    }

    public override void OnExit()
    {
        excuteAllMonster();
        excuteAllDropItem();
        GameManager.Instance.ChangePlayerTension(0);
        GameManager.Instance.M_PlayerDataManager.UpdateWeaponNextFireTime();
        //Debug.Log("Out Fever");
        GameManager.Instance.ExitFeverTime();
    }

    public override void OnUpdate()
    {
        if (Time.time> FeverStateEndTime)
        {
            GameManager.Instance.M_StageManager.TransitionState(State_Enum.Game_FreePlay_State);
        }
        GameManager.Instance.FeverStateUpdateFunction();
        //Debug.Log("FevertimeUpdating");
    }
    private void excuteAllMonster()
    {
        var monsters = GameObject.FindGameObjectsWithTag("Monster");
        foreach (var monster in monsters)
        {
            monster.GetComponent<MonsterBehavior>().ThisObjectBeenAttack(9999,false);
        }
    }
    private void excuteAllDropItem()
    {
        var dropItems = GameObject.FindGameObjectsWithTag("DropItem");
        foreach (var dropItem in dropItems)
        {
            dropItem.GetComponent<PoolObjectDestroyer>().ReleaseThisObject();
        }
    }
}
