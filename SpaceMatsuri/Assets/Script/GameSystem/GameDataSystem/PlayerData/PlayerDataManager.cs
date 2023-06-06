using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerDataManager
{
    [SerializeField]public InGamePlayerData M_InGamePlayerData;
    [field: SerializeField] public int NextLevelNeededExp { get; private set; } 
    private PlayerTempleteDataBase playerTempleteDataBase_ = new PlayerTempleteDataBase();
    //public Weapon[] WeaponPacks = new Weapon[3];//改成List
    public List<Weapon> WeaponPacks = new List<Weapon>();
    public List<UpgrateItem> UpgrateItems = new List<UpgrateItem>();
    //呼叫所有武器
    public void CheckAllAllWeaponCoolDown()
    {
        for (int i = 0; i < WeaponPacks.Count; i++)
        {
            if (WeaponPacks[i]!=null)
            {
                GameManager.Instance.CallWeaponSpawn(WeaponPacks[i]);
            }
        }
    }

    public void PlayerDataManagerInit()
    {
        playerTempleteDataBase_.PlayerTempleteDataBaseInit();
    }
    
    public void PlayerDataInit(int initPlayerID)
    {
        M_InGamePlayerData = new InGamePlayerData(playerTempleteDataBase_.GetBasicPlayerDataByID(initPlayerID));
        setNeededExpByLevel(M_InGamePlayerData.InGameUsedCurrentData.PlayerLevel + 1);
    }
    public void PlayerGainExp(float amount)
    {
        M_InGamePlayerData.InGameUsedCurrentData.LevelBar += amount;
        if (M_InGamePlayerData.InGameUsedCurrentData.LevelBar>=NextLevelNeededExp)
        {
            M_InGamePlayerData.InGameUsedCurrentData.LevelBar = 0;
            //觸發升級事件
            GameManager.Instance.PlayerLevelUpEvent();
        }
    }
    private void setNeededExpByLevel(int nextLevel)
    {
        NextLevelNeededExp = getNeededExpByLevel(nextLevel);
    }
    private int getNeededExpByLevel(int nextLevel)
    {
        if (nextLevel <= 25)
        {
            var result = 20 * (nextLevel - 1) + 50;
            return result;
        }
        else
        {
            var result = 40 * (nextLevel - 1) + 100;
            return result;
        }
    }
    public void PlayerLevelUp()
    {
        M_InGamePlayerData.InGameUsedCurrentData.PlayerLevel += 1;
        setNeededExpByLevel(M_InGamePlayerData.InGameUsedCurrentData.PlayerLevel + 1);
    }
    public Weapon GetWeaponInPackById(int id)
    {
        for (int i = 0; i < WeaponPacks.Count; i++)
        {
            if (WeaponPacks[i].Id == id)
            {
                return WeaponPacks[i];
            }
        }
        return null;
    }
    public UpgrateItem GetUpgrateItemInPackById(int id)
    {
        for (int i = 0; i < UpgrateItems.Count; i++)
        {
            if (UpgrateItems[i].Id == id)
            {
                return UpgrateItems[i];
            }
        }
        return null;
    }
}
