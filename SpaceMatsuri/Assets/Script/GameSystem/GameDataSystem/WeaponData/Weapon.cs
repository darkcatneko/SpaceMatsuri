using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[Serializable]
public class Weapon
{
    [field: SerializeField] public string Name { get; private set; } = "WaterGun";
    [field: SerializeField] public int Id { get; private set; } = 0;
    [field: SerializeField] public int NowLevel { get; set; } = 0;
    [field: SerializeField] public float MovementSpeed { get; set; }
    [field: SerializeField] public float BasicAttack {get;set; }
    [field: SerializeField] public float BasicProjectileScale { get; set; } = 1;
    [field: SerializeField] public int BasicProjectileBasicCount { get; set; } = 1;
    [field: SerializeField] public float AttackFrequence { get; set; } = 1;
    [field: SerializeField] public GameObject WeaponPrefab { get; set; } 
    [field: SerializeField] public float NextFireTime { get; set; } = 1;
    [field: SerializeField] public Sprite WeaponSprite { get; set; }
    public Weapon Clone()
    {
        var clone = new Weapon()
        {
            Name = Name,
            Id = Id,
            NowLevel = NowLevel,
            MovementSpeed = MovementSpeed,
            BasicAttack = BasicAttack,
            BasicProjectileScale = BasicProjectileScale,
            BasicProjectileBasicCount = BasicProjectileBasicCount,
            AttackFrequence = AttackFrequence,
            WeaponPrefab = WeaponPrefab,
            NextFireTime= NextFireTime,
            WeaponSprite = WeaponSprite,
        };
        return clone;
    }
    public Weapon()
    {

    }
    public void ThisWeaponLevelUp()
    {
        if (NowLevel<=5)
        {
            NowLevel += 1;
            BasicAttack += 5;
            BasicProjectileBasicCount += 1;
        }
        else
        {
            NowLevel += 1;
            BasicProjectileScale += 0.1f;
            BasicAttack += 10;
        }
    }
}
