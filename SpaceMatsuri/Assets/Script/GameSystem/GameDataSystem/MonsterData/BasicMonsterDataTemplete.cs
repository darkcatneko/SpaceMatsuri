﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class BasicMonsterDataTemplete
{
    [field: SerializeField] public string Name { get; private set; } = "Basic";
    [field: SerializeField] public int MonsterTemplete_ID { get; private set; } = 0;
    [field: SerializeField] public int MonsterLevel { get; set; } = 0;
    [field: SerializeField] public float MonsterMovementSpeed { get; set; } = 2;
    [field: SerializeField] public float MaxHealthPoint { get; set; } = 100;
    [field: SerializeField] public float Now_MonsterHealthPoint { get; set; }
    [field: SerializeField] public float MonsterAttack { get; set; } = 5;
    [field: SerializeField] public GameObject MonsterPrefab { get; set; }
    [field:SerializeField] public float DropChance { get; set; }
    public BasicMonsterDataTemplete Clone()
    {
        var clone = new BasicMonsterDataTemplete()
        {
            Name = Name,
            MonsterTemplete_ID = MonsterTemplete_ID,
            MonsterLevel = MonsterLevel,
            MonsterMovementSpeed = MonsterMovementSpeed,
            MaxHealthPoint = MaxHealthPoint,
            Now_MonsterHealthPoint = Now_MonsterHealthPoint,
            MonsterAttack = MonsterAttack,
            MonsterPrefab = MonsterPrefab,
            DropChance = DropChance,
        };
        //要複製的東西
        return clone;
    }
    public BasicMonsterDataTemplete()
    {

    }   
    public void ThisMonsterLevelChange(int level)
    {
        MonsterLevel = level;
        MaxHealthPoint *= level*0.5f;
        Now_MonsterHealthPoint *= level* 0.5f;
    }
}
