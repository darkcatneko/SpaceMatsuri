﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.AddressableAssets.GUI;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemySpawner : MonoBehaviour
{
    [Header("DataBase")]
    private MonsterTempleteDataBase monsterTempleteData = new MonsterTempleteDataBase();
    private MonsterSpawningDataDataBase SpawnerDataBase = new MonsterSpawningDataDataBase();
    [Header("SpawnerData")]
    [SerializeField]
    private MonsterSpawnerUsedSpawningDataTemplete nowSpawningDataTemplete;
    private int nowSpawnerPhase = 0;
    private float monsterSpawnerTimer_ = 0;
    private int monsterInPlayableArea_ = 0;
    [Header("ObjectPools")]
    private ObjectPoolClass monsterObjectPool = new ObjectPoolClass();
    private void Start()
    {
        //GameManager.Instance.M_MainGameEvent.GameStartEvent.AddListener(enemySpawnTest);
    }
    public async Task monsterDataBaseInit()
    {
        await monsterTempleteData.ReadCsv();
        await SpawnerDataBase.ReadCsv();
        changeSpawnerPhase();
    }
    private void enemySpawnerFreeGameUpdateEvent()
    {
        monsterSpawnerTimer_ += Time.deltaTime;
        tryToChangePhase();
        for (int i = 0; i < nowSpawningDataTemplete.HowManyMonsterAFrame; i++)
        {
            checkIfNeedToSpawnNewMonster();
        }
    }
    private void tryToChangePhase()
    {
        if (monsterSpawnerTimer_ >= 60f)
        {
            monsterSpawnerTimer_ = 0f;
            changeSpawnerPhase();
        }
    }
    private void checkIfNeedToSpawnNewMonster()
    {
        if (monsterInPlayableArea_ <= nowSpawningDataTemplete.MonsterShouldBeInArea)
        {
            var monsterId = getARandomMonsterIdByPhase();
        }
    }
    private int getARandomMonsterIdByPhase()
    {
        var monsterPool = new List<int>();
        if (nowSpawningDataTemplete.WillKappaSpawn) monsterPool.Add(1);
        if (nowSpawningDataTemplete.WillKamaitachiSpawn) monsterPool.Add(2);
        if (nowSpawningDataTemplete.WillUmbrellaSpawn) monsterPool.Add(3);
        if (nowSpawningDataTemplete.WillYukiSpawn) monsterPool.Add(4);
        if (nowSpawningDataTemplete.WillTenguSpawn) monsterPool.Add(5);
        if (nowSpawningDataTemplete.WillWheelSpawn) monsterPool.Add(6);
        var result = UnityEngine.Random.Range(0, monsterPool.Count);
        return result;
    }
    private void spawnAObjectByMonsterId(int monsterId,Vector3 position)
    {
        var monsterPrefab = monsterTempleteData.GetMonsterDataByID(monsterId).MonsterPrefab;
        var spawnedMonster = monsterObjectPool.GetGameObject(monsterPrefab, position, Quaternion.identity);
        //加入物件池
        //加入自毀器
    }
    private Vector3 randomASpawnPosition()
    {
        var RightOrLeft = (rightOrleft)UnityEngine.Random.Range(0, 2);
        var randomY = UnityEngine.Random.Range(16f, -16f);
        switch (RightOrLeft)
        {
            case rightOrleft.right:
                return new Vector3(32, randomY, 0);
            case rightOrleft.left:
                return new Vector3(-32, randomY, 0);
        }
        return Vector3.zero;
    }
    private enum rightOrleft
    {
        right, left,
    }
    private void changeSpawnerPhase()
    {
        nowSpawnerPhase = Mathf.Clamp(nowSpawnerPhase++, 0, SpawnerDataBase.M_MonsterSpawningDataDataBase.Count);
        nowSpawningDataTemplete = SpawnerDataBase.GetSpawnerDataByPhase(nowSpawnerPhase);
    }
    //public void enemySpawnTest()
    //{
    //    var monsterPrefab = monsterTempleteData.GetMonsterDataByID(1).MonsterPrefab;       
    //    var Enemy = Instantiate(monsterPrefab, new Vector3(0,5,0), Quaternion.identity);
    //    Enemy.GetComponent<MonsterBehavior>().ThisMonsterData = monsterTempleteData.GetMonsterDataByID(1).Clone();
    //}

}