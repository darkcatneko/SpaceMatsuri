using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InGamePlayerData
{
    private BasicPlayerDataTemplate thisPlayerDataInit_;
    [SerializeField] public BasicPlayerDataTemplate InGameUsedCurrentData;

    public InGamePlayerData(BasicPlayerDataTemplate basicPlayerDataTemplate)
    {
        thisPlayerDataInit_ = basicPlayerDataTemplate.Clone();
        InGameUsedCurrentData = basicPlayerDataTemplate.Clone();
        InGameUsedCurrentData.Now_PlayerHealthPoint = InGameUsedCurrentData.MaxHealthPoint;
    }
    
}
