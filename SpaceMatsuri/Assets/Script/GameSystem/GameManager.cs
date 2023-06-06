using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : ToSingletonMonoBehavior<GameManager>
{
    public MainGameEvent M_MainGameEvent = new MainGameEvent();
    public PlayerDataManager M_PlayerDataManager = new PlayerDataManager();
    public BasicPlayerDataTemplate IngamePlayerData => M_PlayerDataManager.M_InGamePlayerData.InGameUsedCurrentData;
    public float NowPlayerLevelPercentage => this.IngamePlayerData.LevelBar / M_PlayerDataManager.NextLevelNeededExp;
    public GameObject PlayerObject;
    public StageManager M_StageManager = new StageManager();//小概念
    public int FeverCount = 0;
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
    }
    public void GameStart()
    {
        M_MainGameEvent.GameStartEvent.Invoke();
    }
    public void PlayerMovement(Vector3 dir, float speed)
    {
        M_MainGameEvent.PlayerMovement.Invoke(dir, speed);
    }
    public void FreeGamePlayUpdater()
    {
        M_MainGameEvent.FreeGamePlayUpdateEvent.Invoke();
        M_PlayerDataManager.CheckAllAllWeaponCoolDown();
    }
    public void ReleaseMonster()
    {
        M_MainGameEvent.MonsterBeenReleaseEvent.Invoke();
    }
    public void FeverStateUpdateFunction()
    {
        M_MainGameEvent.FeverTimeOnUpdateEvent.Invoke();
    }
    public void CallSpawnFirework()
    {
        M_MainGameEvent.CallFireworkSpawnEvent.Invoke();
    }
    public void CallWeaponSpawn(Weapon weapon)
    {
        M_MainGameEvent.CallWeaponSpawn.Invoke(weapon);
    }
    public void EnterFevertime()
    {
        FeverCount++;
        M_MainGameEvent.EnterFeverTimeEvent.Invoke();
    }
    public void ExitFeverTime()
    {
        M_MainGameEvent.ExitFeverTimeEvent.Invoke();
    }
    #endregion
    public void ChangePlayerTension(float result)
    {
        IngamePlayerData.Now_TensionBar = result;
        M_MainGameEvent.TensionBarChangeEvent.Invoke(IngamePlayerData.Now_TensionBar);
    }
    public void MonsterBeenKilledByFirework()
    {
        M_MainGameEvent.MonsterBeenKillByFireworkEvent.Invoke();
    }
    public void PlayerGetDamage(float damage)
    {
        IngamePlayerData.Now_PlayerHealthPoint -= damage;
        if (IngamePlayerData.Now_PlayerHealthPoint<=0)
        {
            M_StageManager.TransitionState(State_Enum.Game_Over_State,StageData.GetGameOverStageData(false));
        }
        M_MainGameEvent.PlayerGetAttackEvent.Invoke();
    }
    public void PlayerGainExperience(float amount)
    {
        M_PlayerDataManager.PlayerGainExp(amount);
    }
    public void CallSpawnDropItem(Vector3 spawnPosition,float chance)
    {
        M_MainGameEvent.CallSpawnDropItem.Invoke(spawnPosition,chance);
    }
    public void PlayerLevelUpEvent()
    {
        M_PlayerDataManager.PlayerLevelUp();
        M_MainGameEvent.PlayerLevelUpEvent.Invoke();
    }
    public void PlayerUpgrate()
    {
        M_MainGameEvent.PlayerUpgrateEvent.Invoke();
    }
    public void PlayerGameOver(bool IsWinning)
    {
        M_MainGameEvent.PlayerGameOverEvent.Invoke(IsWinning);
    }
}
