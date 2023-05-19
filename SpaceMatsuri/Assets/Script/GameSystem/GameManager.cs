using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : ToSingletonMonoBehavior<GameManager>
{
    public MainGameEvent M_MainGameEvent = new MainGameEvent();
    public PlayerDataManager M_PlayerDataManager = new PlayerDataManager();
    protected override void init()
    {
        M_PlayerDataManager.PlayerDataManagerInit();
    }
    void Start()
    {

    }
    void Update()
    {

    }
    #region  GameEvents
    public void GameStart()
    {
        M_MainGameEvent.GameStartEvent.Invoke();
    }

    #endregion
    
}
