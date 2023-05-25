using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Events;

public class Weapon
{
    [field: SerializeField] public string Name { get; private set; } = "WaterGun";
    [field: SerializeField] public int Id { get; private set; } = 0;
    [field: SerializeField] public int NowLevel { get; set; } = 0;
    [field: SerializeField] public float MovementSpeed { get; set; }
    [field: SerializeField] public float BasicAttack {get;set; }
    [field: SerializeField] public float BasicProjectileScale { get; set; } = 1;
    [field: SerializeField] public int BasicProjectileBasicCount { get; set; } = 1;
    [field: SerializeField] public int AttackFrequence { get; set; } = 1;
    [field: SerializeField] public GameObject WeaponPrefab { get; set; }
    [field: SerializeField] public float NextFireTime { get; set; } = 0;
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
        };
        return clone;
    }
    public Weapon()
    {

    }
}