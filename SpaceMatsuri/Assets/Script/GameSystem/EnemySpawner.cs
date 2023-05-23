using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private MonsterTempleteDataBase monsterTempleteData = new MonsterTempleteDataBase();
    private void Start()
    {
        GameManager.Instance.M_MainGameEvent.GameInitEvent.AddListener(monsterDataBaseInit);
        GameManager.Instance.M_MainGameEvent.GameStartEvent.AddListener(enemySpawnTest);
    }
    private void monsterDataBaseInit()
    {
        monsterTempleteData.ReadCsv();
    }

    private async void enemySpawnTest()
    {
        var monsterPrefabPath = monsterTempleteData.GetMonsterDataByID(1).MonsterPrefabPath;
        var gameobject = await AddressableSearcher.GetAddressableAssetAsync<GameObject>(monsterPrefabPath);
        Instantiate(gameobject, Vector3.zero, Quaternion.identity);
    }
}
