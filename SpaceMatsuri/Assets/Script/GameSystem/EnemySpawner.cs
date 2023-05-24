using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.AddressableAssets.GUI;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private MonsterTempleteDataBase monsterTempleteData = new MonsterTempleteDataBase();
    private MonsterSpawningDataDataBase SpawnerDataBase = new MonsterSpawningDataDataBase();
    private float monsterSpawnerTimer_ = 0;
    private void Start()
    {      
        GameManager.Instance.M_MainGameEvent.GameStartEvent.AddListener(enemySpawnTest);
    }
    public async Task monsterDataBaseInit()
    {
        await monsterTempleteData.ReadCsv();
        await SpawnerDataBase.ReadCsv();
    }
    private void enemySpawnerFreeGameUpdateEvent()
    {
        if (gameStart_)
        {

        }
    }

    public void enemySpawnTest()
    {
        var monsterPrefab = monsterTempleteData.GetMonsterDataByID(1).MonsterPrefab;       
        var Enemy = Instantiate(monsterPrefab, new Vector3(0,5,0), Quaternion.identity);
        Enemy.GetComponent<MonsterBehavior>().ThisMonsterData = monsterTempleteData.GetMonsterDataByID(1).Clone();
    }
}
