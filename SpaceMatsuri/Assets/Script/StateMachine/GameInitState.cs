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
        var dropItemSystem = initializer.AddComponent<DropItemSystem>();
        var upgrateSystem = initializer.AddComponent<UpgrateItemManager>();
        Debug.Log("GameIniting");
        await playerSpawner.spawnPlayerPrefab();
        await enemySpawner.monsterDataBaseInit();
        await weaponManager.WeaponManagerInit();
        await dropItemSystem.DropItemSystemInit();
        //await upgrateSystem.UpgrateItemManagerInit();
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
