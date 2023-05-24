using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MonsterSpawnerUsedSpawningDataTemplete
{
    [field: SerializeField] public int PhaseNumber { get; set; }
    [field: SerializeField] public int MonsterShouldBeInArea { get; set; }
    [field: SerializeField] public bool WillKappaSpawn { get; set; }
    [field: SerializeField] public bool WillKamaitachiSpawn { get; set; }
    [field: SerializeField] public bool WillUmbrellaSpawn { get; set; }
    [field: SerializeField] public bool WillYukiSpawn { get; set; }
    [field: SerializeField] public bool WillTenguSpawn { get; set; }
    [field: SerializeField] public bool WillWheelSpawn { get; set; }
    [field: SerializeField] public int BossSpawnAmount { get; set; }
    [field: SerializeField] public int HowManyMonsterAFrame { get; set; }
    public MonsterSpawnerUsedSpawningDataTemplete()
    {

    }
    public MonsterSpawnerUsedSpawningDataTemplete Clone()
    {
        var result = new MonsterSpawnerUsedSpawningDataTemplete()
        {
            PhaseNumber = PhaseNumber,
            MonsterShouldBeInArea = MonsterShouldBeInArea,
            WillKappaSpawn = WillKappaSpawn,
            WillKamaitachiSpawn = WillKamaitachiSpawn,
            WillTenguSpawn = WillTenguSpawn,
            WillUmbrellaSpawn = WillUmbrellaSpawn,
            WillWheelSpawn = WillWheelSpawn,
            WillYukiSpawn = WillYukiSpawn,
            BossSpawnAmount = BossSpawnAmount,
            HowManyMonsterAFrame = HowManyMonsterAFrame,
        };
        
        return result;
    }
}
