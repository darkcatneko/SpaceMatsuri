using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InGamePlayerData
{
    private BasicPlayerDataTemplate thisPlayerDataInit_;
    [SerializeField] public BasicPlayerDataTemplate inGameUsedCurrentData;

    public InGamePlayerData(BasicPlayerDataTemplate basicPlayerDataTemplate)
    {
        thisPlayerDataInit_ = basicPlayerDataTemplate.Clone();
        inGameUsedCurrentData = basicPlayerDataTemplate.Clone();
        inGameUsedCurrentData.Now_PlayerHealthPoint = inGameUsedCurrentData.MaxHealthPoint;
    }
}
