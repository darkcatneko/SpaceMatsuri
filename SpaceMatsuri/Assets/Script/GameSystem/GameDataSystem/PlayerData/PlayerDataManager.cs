using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerDataManager
{
    [SerializeField]public InGamePlayerData M_InGamePlayerData;
    private PlayerTempleteDataBase playerTempleteDataBase_ = new PlayerTempleteDataBase();
    public Weapon[] weaponPacks = new Weapon[3];
    //呼叫所有武器

    public void PlayerDataManagerInit()
    {
        playerTempleteDataBase_.PlayerTempleteDataBaseInit();
    }
    
    public void PlayerDataInit(int initPlayerID)
    {
        M_InGamePlayerData = new InGamePlayerData(playerTempleteDataBase_.GetBasicPlayerDataByID(initPlayerID));
    }
}
