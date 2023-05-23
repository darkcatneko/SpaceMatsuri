using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : ToSingletonMonoBehavior<GameManager>
{
    public MainGameEvent M_MainGameEvent = new MainGameEvent();
    public PlayerDataManager M_PlayerDataManager = new PlayerDataManager();
    public BasicPlayerDataTemplate IngamePlayerData => M_PlayerDataManager.M_InGamePlayerData.inGameUsedCurrentData;
    public GameObject PlayerObject;
    public StageManager M_StageManager = new StageManager();//小概念
    protected override void init()
    {
        M_PlayerDataManager.PlayerDataManagerInit();
    }
    void Start()
    {

    }
    void Update()
    {
        M_StageManager.StageManagerUpdate();
    }
    #region  GameEvents
    public void GameInit()
    {
        M_StageManager.StageManagerInit();
        M_MainGameEvent.GameInitEvent.Invoke();
        Debug.Log("GameInit");
    }
    public void GameStart()
    {
        M_MainGameEvent.GameStartEvent.Invoke();
    }
    public void PlayerMovement(Vector3 dir,float speed)
    {
        M_MainGameEvent.PlayerMovement.Invoke(dir,speed);
    }

    #endregion
    
}
