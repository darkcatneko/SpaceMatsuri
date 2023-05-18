using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ToSingletonMonoBehavior<GameManager>
{
    public MainGameEvent M_MainGameEvent = new MainGameEvent();
    [SerializeField] public PlayerDataManager M_PlayerDataManager = new PlayerDataManager();
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
