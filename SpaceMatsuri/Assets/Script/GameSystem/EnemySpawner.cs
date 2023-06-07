using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class EnemySpawner : MonoBehaviour
{
    [Header("DataBase")]
    private MonsterTempleteDataBase monsterTempleteData = new MonsterTempleteDataBase();
    private MonsterSpawningDataDataBase SpawnerDataBase = new MonsterSpawningDataDataBase();
    [Header("SpawnerData")]
    [SerializeField]
    private MonsterSpawnerUsedSpawningDataTemplete nowSpawningDataTemplete;
    [SerializeField]
    private int nowSpawnerPhase = 0;
    [SerializeField]
    private float monsterSpawnerTimer_ = 0;
    private int monsterInPlayableArea_ = 0;
    [Header("ObjectPools")]
    private ObjectPoolClass[] monsterObjectPool = new ObjectPoolClass[6];
    private bool isBossSpawned = false;
    private void Start()
    {       
        for (int i = 0; i < 6; i++)
        {
            monsterObjectPool[i] = this.gameObject.AddComponent<ObjectPoolClass>();
        }
        GameManager.Instance.M_MainGameEvent.FreeGamePlayUpdateEvent.AddListener(enemySpawnerFreeGameUpdateEvent);
        GameManager.Instance.M_MainGameEvent.MonsterBeenReleaseEvent.AddListener(releaseMonster);
        GameManager.Instance.M_MainGameEvent.EnterFeverTimeEvent.AddListener(intoFeverTime);
        GameManager.Instance.M_MainGameEvent.ExitFeverTimeEvent.AddListener(outFeverTime);
        GameManager.Instance.M_MainGameEvent.FeverTimeOnUpdateEvent.AddListener(enemySpawnerFeverTimeUpdateEvent);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            monsterSpawnerTimer_ = 29;
        }
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
        if (monsterSpawnerTimer_ >= 30f)
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
            var monsterPosition = getARandomSpawnPosition();
            var monsterObject = spawnAObjectByMonsterId(monsterId, monsterPosition);
            //Debug.Log(monsterInPlayableArea_);
        }
        else
        {
            //Debug.Log("FullOfMonster");
        }
    }
    private void checkIfNeedToSpawnNewFasterMonster()
    {
        if (monsterInPlayableArea_ <= nowSpawningDataTemplete.MonsterShouldBeInArea)
        {
            var monsterId = getARandomMonsterIdByPhase();
            var monsterPosition = getARandomSpawnPosition();
            var monsterObject = spawnAFasterObjectByMonsterId(monsterId, monsterPosition);
            //Debug.Log(monsterInPlayableArea_);
        }
        else
        {
            //Debug.Log("FullOfMonster");
        }
    }
    private int getARandomMonsterIdByPhase()
    {
        var monsterPool = new List<SpawmUsedMonsterStruct>();
        if (nowSpawningDataTemplete.WillKappaSpawn>0) monsterPool.Add(new SpawmUsedMonsterStruct(1, nowSpawningDataTemplete.WillKappaSpawn));
        if (nowSpawningDataTemplete.WillKamaitachiSpawn > 0) monsterPool.Add(new SpawmUsedMonsterStruct(2, nowSpawningDataTemplete.WillKamaitachiSpawn));
        if (nowSpawningDataTemplete.WillUmbrellaSpawn>0) monsterPool.Add(new SpawmUsedMonsterStruct(3, nowSpawningDataTemplete.WillUmbrellaSpawn));
        if (nowSpawningDataTemplete.WillYukiSpawn>0) monsterPool.Add(new SpawmUsedMonsterStruct(4, nowSpawningDataTemplete.WillYukiSpawn));
        if (nowSpawningDataTemplete.WillTenguSpawn>0) monsterPool.Add(new SpawmUsedMonsterStruct(5, nowSpawningDataTemplete.WillTenguSpawn));
        if (nowSpawningDataTemplete.WillWheelSpawn > 0) monsterPool.Add(new SpawmUsedMonsterStruct(6, nowSpawningDataTemplete.WillWheelSpawn));
        var randomResult = UnityEngine.Random.value;
        foreach(var monster in monsterPool)
        {
            if (randomResult < monster.Chance)
            {
                return monster.monsterId;  // 選擇該物品
            }

            randomResult -= monster.Chance;
        }
        return 1;
    }
    private GameObject spawnAObjectByMonsterId(int monsterId, Vector3 position)
    {
        var monsterPrefab = monsterTempleteData.GetMonsterDataByID(monsterId).MonsterPrefab;
        var spawnedMonster = monsterObjectPool[monsterId-1].GetGameObject(monsterPrefab, position, Quaternion.identity);//加入物件池
        var thisMonsterData = monsterTempleteData.GetMonsterDataByID(monsterId).Clone();
        thisMonsterData.ThisMonsterLevelChange(GameManager.Instance.IngamePlayerData.PlayerLevel);
        spawnedMonster.GetComponent<MonsterBehavior>().InitMonsterData(thisMonsterData);
        var destroyer = spawnedMonster.GetComponent<PoolObjectDestroyer>();
        destroyer.Pool = monsterObjectPool[monsterId - 1];//加入自毀器
        monsterInPlayableArea_++;
        return spawnedMonster;
    }
    private GameObject spawnAFasterObjectByMonsterId(int monsterId, Vector3 position)
    {
        var monsterPrefab = monsterTempleteData.GetMonsterDataByID(monsterId).MonsterPrefab;
        var spawnedMonster = monsterObjectPool[monsterId - 1].GetGameObject(monsterPrefab, position, Quaternion.identity);//加入物件池
        var monsterData = monsterTempleteData.GetMonsterDataByID(monsterId).Clone();
        monsterData.ThisMonsterLevelChange(GameManager.Instance.IngamePlayerData.PlayerLevel);
        monsterData.MonsterMovementSpeed *= 2.5f;
        spawnedMonster.GetComponent<MonsterBehavior>().InitMonsterData(monsterData);
        var destroyer = spawnedMonster.GetComponent<PoolObjectDestroyer>();
        destroyer.Pool = monsterObjectPool[monsterId - 1];//加入自毀器
        monsterInPlayableArea_++;
        return spawnedMonster;
    }
    private Vector3 getARandomSpawnPosition()
    {
        var RightOrLeft = (rightOrleft)UnityEngine.Random.Range(0, 2);
        var randomY = UnityEngine.Random.Range(16f, -16f);
        var playerPosition = GameManager.Instance.PlayerObject.transform.position;
        switch (RightOrLeft)
        {
            case rightOrleft.right:
                return new Vector3(32+ playerPosition.x, playerPosition.y+randomY, 0);
            case rightOrleft.left:
                return new Vector3(-32+playerPosition.x, playerPosition.y+randomY, 0);
        }
        return Vector3.zero;
    }
    private enum rightOrleft
    {
        right, left,
    }
    private void changeSpawnerPhase()
    {
        nowSpawnerPhase = Mathf.Clamp(nowSpawnerPhase+=1, 0, SpawnerDataBase.M_MonsterSpawningDataDataBase.Count);
        nowSpawningDataTemplete = SpawnerDataBase.GetSpawnerDataByPhase(nowSpawnerPhase);
        if (isBossSpawned == false)
        {
            checkIfSpawnBoss(nowSpawningDataTemplete);
        }
       
    }
    private void checkIfSpawnBoss(MonsterSpawnerUsedSpawningDataTemplete templete)
    {
        if (templete.BossSpawnAmount>0)
        {
            var monsterPrefab = monsterTempleteData.GetMonsterDataByID(99).MonsterPrefab;
            //var monsterPosition = GameManager.Instance.PlayerObject.transform.position +new Vector3(0, 100, 0);
            var monsterPosition = new Vector3(GameManager.Instance.PlayerObject.transform.position.x, 77, 0);
           var spawnedMonster = Instantiate(monsterPrefab, monsterPosition, Quaternion.identity);
            var thisMonsterData = monsterTempleteData.GetMonsterDataByID(99).Clone();
            spawnedMonster.GetComponent<BossBehavior>().InitMonsterData(thisMonsterData);
            isBossSpawned = true;
        }
    }
    #region FeverTimeEnemySpawner
    private void intoFeverTime()
    {
        var feverSpawnData = SpawnerDataBase.GetSpawnerDataByPhase(nowSpawnerPhase).Clone();
        feverSpawnData.MonsterShouldBeInArea = 150;
        feverSpawnData.HowManyMonsterAFrame = 20;
        nowSpawningDataTemplete = feverSpawnData.Clone();
    }
    private void outFeverTime()
    {
        nowSpawningDataTemplete = SpawnerDataBase.GetSpawnerDataByPhase(nowSpawnerPhase).Clone();
    }
    private void enemySpawnerFeverTimeUpdateEvent()
    {       
        for (int i = 0; i < nowSpawningDataTemplete.HowManyMonsterAFrame; i++)
        {
            checkIfNeedToSpawnNewFasterMonster();
        }
    }
    #endregion
    private void releaseMonster()
    {
        monsterInPlayableArea_ -= 1;
    }
}
public struct SpawmUsedMonsterStruct
{
    public int monsterId;
    public float Chance;
    public SpawmUsedMonsterStruct(int id,float chance)
    {
        monsterId = id;
        Chance = chance;
    }
}
