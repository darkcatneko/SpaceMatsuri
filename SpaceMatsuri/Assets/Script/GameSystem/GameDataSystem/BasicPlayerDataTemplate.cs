using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BasicPlayerDataTemplate
{
    [field:SerializeField] public virtual int PlayerTemplete_ID { get; private set; } = 1;
    [field: SerializeField] public virtual string Name { get; private set; } = "Basic";
    [field: SerializeField] public virtual int PlayerLevel { get; set; } = 0;
    [field: SerializeField] public virtual float LevelBar { get; set; } = 0;
    [field: SerializeField] public virtual float PlayerMovementSpeed { get; set; } = 2;
    [field: SerializeField] public virtual int MaxHealthPoint { get; set; } = 100;
    [field: SerializeField] public virtual int Now_PlayerHealthPoint { get; set; }
    [field: SerializeField] public virtual float PlayerAttack { get; set; } = 5;
    [field: SerializeField] public virtual float FeverTimeLastTime { get; set; } = 5;
    [field: SerializeField] public virtual float Now_TensionBar { get; set; } = 0;
    [field: SerializeField] public virtual float MatsuriTenshenChargeSpeed { get; set; } = 1;
    [field: SerializeField] public virtual float AttackProjectileScale { get; set; } = 1;
    [field: SerializeField] public virtual int AttackProjectileBasicCount { get; set; } = 1;
    [field: SerializeField] public virtual int AttackFrequence { get; set; } = 1;

    public BasicPlayerDataTemplate Clone()
    {
        var clone = new BasicPlayerDataTemplate()
        {
            PlayerTemplete_ID = PlayerTemplete_ID,
        };
        //要複製的東西
        return clone;        
    }
}
