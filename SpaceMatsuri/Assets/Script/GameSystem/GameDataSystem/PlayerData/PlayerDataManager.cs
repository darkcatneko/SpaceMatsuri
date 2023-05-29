using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerDataManager
{
    [SerializeField]public InGamePlayerData M_InGamePlayerData;
    private PlayerTempleteDataBase playerTempleteDataBase_ = new PlayerTempleteDataBase();
    //public Weapon[] WeaponPacks = new Weapon[3];//改成List
    public List<Weapon> WeaponPacks = new List<Weapon>();
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
    }
}
