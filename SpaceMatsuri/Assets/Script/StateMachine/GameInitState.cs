using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitState : StateBase
{
    public GameInitState(StageManager m) : base(m)
    {
    }

    public override async void OnEnter()
    {
        var initializer = new GameObject();
        initializer.name = "InitializedDataObject";
        var playerSpawner = initializer.AddComponent<PlayerSpawner>();
        var enemySpawner = initializer.AddComponent<EnemySpawner>();
        var weaponManager = initializer.AddComponent<WeaponManager>();
        Debug.Log("GameIniting");
        await playerSpawner.spawnPlayerPrefab();
        await enemySpawner.monsterDataBaseInit();
        await weaponManager.WeaponManagerInit();
        Debug.Log("GameFinishIniting");
        GameManager.Instance.M_StageManager.TransitionState(State_Enum.Game_Start_State);
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
       
    }
}
