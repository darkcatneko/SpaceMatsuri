using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class BasicPlayerDataTemplate
{
    [field: SerializeField] public string Name { get; private set; } = "Basic";
    [field:SerializeField] public int PlayerTemplete_ID { get; private set; } = 1;
    [field: SerializeField] public int PlayerLevel { get; set; } = 0;
    [field: SerializeField] public float LevelBar { get; set; } = 0;
    [field: SerializeField] public float PlayerMovementSpeed { get; set; } = 2;
    [field: SerializeField] public float MaxHealthPoint { get; set; } = 100;
    [field: SerializeField] public float Now_PlayerHealthPoint { get; set; }
    [field: SerializeField] public float PlayerAttack { get; set; } = 5;
    [field: SerializeField] public float FeverTimeLastTime { get; set; } = 5;
    [field: SerializeField] public float Now_TensionBar { get; set; } = 0;//FeverBar
    [field: SerializeField] public float MatsuriTenshenChargeSpeed { get; set; } = 1;
    [field: SerializeField] public float AttackProjectileScale { get; set; } = 1;
    [field: SerializeField] public int AttackProjectileBasicCount { get; set; } = 1;
    [field: SerializeField] public float AttackFrequence { get; set; } = 1;
    [field: SerializeField] public string PlayerPrefabPath { get; set; } = "Prefab/matsuriPlayer";

    public BasicPlayerDataTemplate Clone()
    {
        var clone = new BasicPlayerDataTemplate()
        {
            Name = Name,
            PlayerTemplete_ID = PlayerTemplete_ID,
            PlayerLevel = PlayerLevel,
            LevelBar = LevelBar,
            PlayerMovementSpeed = PlayerMovementSpeed, 
            MaxHealthPoint = MaxHealthPoint,
            Now_PlayerHealthPoint = Now_PlayerHealthPoint,
            PlayerAttack = PlayerAttack,
            FeverTimeLastTime = FeverTimeLastTime,
            Now_TensionBar =    Now_TensionBar,
            MatsuriTenshenChargeSpeed = MatsuriTenshenChargeSpeed,
            AttackFrequence = AttackFrequence,
            AttackProjectileBasicCount = AttackProjectileBasicCount,
            AttackProjectileScale = AttackProjectileScale,
            PlayerPrefabPath = PlayerPrefabPath,
        };
        //要複製的東西
        return clone;        
    }
    public BasicPlayerDataTemplate()
    {

    }   
}
