using Mono.Cecil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //private WeaponDataBase weaponDataBase = new WeaponDataBase();
    private WeaponDataBase weaponDataBase => DataBaseCenter.Instance.WeaponDataBase;
    public ObjectPoolClass WaterGunPool;
    public ObjectPoolClass HanabiPool;
    public ObjectPoolClass HanabiParticalPool;
    private GameObject hanabiPrefab_;
    private GameObject kitsunePrefab_;
    public async Task WeaponManagerInit()
    {
        //await weaponDataBase.ReadCsv();
        WaterGunPool = this.gameObject.AddComponent<ObjectPoolClass>();
        HanabiPool = this.gameObject.AddComponent<ObjectPoolClass>();
        HanabiParticalPool = this.gameObject.AddComponent<ObjectPoolClass>();
        hanabiPrefab_ = await AddressableSearcher.GetAddressableAssetAsync<GameObject>("Prefab/HanabiTama");
        kitsunePrefab_ = await AddressableSearcher.GetAddressableAssetAsync<GameObject>("Prefab/KitsunePartical");
        GameManager.Instance.M_MainGameEvent.CallWeaponSpawn.AddListener(TrySpawnWeapon);
        GameManager.Instance.M_MainGameEvent.GameStartEvent.AddListener(TestAddWeaponToPlayer);
        GameManager.Instance.M_MainGameEvent.CallFireworkSpawnEvent.AddListener(SpawnHanabiTama);
        GameManager.Instance.M_MainGameEvent.ExitFeverTimeEvent.AddListener(callSpawnKitsunePartical);
    }
    private void Start()
    {
        Debug.Log("123");
        //GameManager.Instance.M_MainGameEvent.CallWeaponSpawn.AddListener(TrySpawnWeapon);
        //GameManager.Instance.M_MainGameEvent.GameStartEvent.AddListener(TestAddWeaponToPlayer);
        //GameManager.Instance.M_MainGameEvent.CallFireworkSpawnEvent.AddListener(SpawnHanabiTama);
        //GameManager.Instance.M_MainGameEvent.ExitFeverTimeEvent.AddListener(callSpawnKitsunePartical);
    }
    public async void TrySpawnWeapon(Weapon weapon)
    {
        Debug.Log("Time" +  Time.timeSinceLevelLoad);
        if (Time.timeSinceLevelLoad > weapon.NextFireTime)
        {
            weapon.NextFireTime += weapon.AttackFrequence*GameManager.Instance.IngamePlayerData.AttackFrequence;
            for (int i = 0; i < weapon.BasicProjectileBasicCount+GameManager.Instance.IngamePlayerData.AttackProjectileBasicCount; i++)
            {
                SpawnWeapon(weapon);
                await Task.Delay(10);
            }            
        }
       
    }
    private void SpawnWeapon(Weapon weapon)
    {
        switch (weapon.Id)
        {
            case 1:
                SpawnWaterGun(weapon, GameManager.Instance.PlayerObject.transform.position);
                return;
        }
    }
    public void SpawnWaterGun(Weapon weapon,Vector3 originPoint)
    {
        var waterGunPrefab = weapon.WeaponPrefab;
        //var thisWeaponBasicData = weaponDataBase.GetWeaponByID(1).Clone();
        var thisWeaponBasicData = weapon.Clone();
        var randomSpawnPoint = new Vector3(UnityEngine.Random.Range(0.5f, 2), UnityEngine.Random.Range(0.5f, 2), 0);
        var spawnPoint = randomSpawnPoint + originPoint;
        var waterGunObject = WaterGunPool.GetGameObject(waterGunPrefab, spawnPoint, Quaternion.identity);
        waterGunObject.transform.localScale = thisWeaponBasicData.WeaponPrefab.transform.localScale* GameManager.Instance.IngamePlayerData.AttackProjectileScale * thisWeaponBasicData.BasicProjectileScale;
        var waterGunMover = waterGunObject.GetComponent<WaterGunProjectileMovement>();
        waterGunMover.ThisProjectileData = thisWeaponBasicData;
        var target = GetANearestMonster();
        waterGunMover.TargetLock(target);
        var destroyer = waterGunObject.GetComponent<PoolObjectDestroyer>();
        destroyer.Pool = WaterGunPool;//加入自毀器
        
    }
    public void SpawnHanabiTama()
    {
        Debug.Log("call prefab");
        var spawnPoint = GameManager.Instance.PlayerObject.transform.position;
        var hanabiObject = HanabiPool.GetGameObject(hanabiPrefab_, spawnPoint, Quaternion.identity);
        if (!hanabiObject.activeSelf)
        {
            Debug.LogError("U sure?");
        }
        var hanabiMover = hanabiObject.GetComponent<FireworkBehavior>();
        hanabiMover.HanabiParticalPool = HanabiParticalPool;
        hanabiMover.ThisProjectileData = weaponDataBase.GetWeaponByID(99).Clone();
        var target = GetANearestMonster();
        hanabiMover.TargetLock(target);
        var destroyer = hanabiObject.GetComponent<PoolObjectDestroyer>();
        destroyer.Pool = HanabiPool;//加入自毀器
    }
    public Transform GetANearestMonster()
    {
        var nearesrDistance = 100f;
        var allMonster = GameObject.FindGameObjectsWithTag("Monster").ToList<GameObject>();
        if(GameObject.FindGameObjectWithTag("Boss")!=null) allMonster.Add(GameObject.FindGameObjectWithTag("Boss"));
        if (allMonster.Count>0)
        {
            var targerTransform = allMonster[0].transform;
            for (int i = 0; i < allMonster.Count; i++)
            {
                if ((allMonster[i].transform.position - GameManager.Instance.PlayerObject.transform.position).magnitude < nearesrDistance)
                {
                    targerTransform = allMonster[i].transform;
                    nearesrDistance = (allMonster[i].transform.position - GameManager.Instance.PlayerObject.transform.position).magnitude;
                }
            }
            return targerTransform;
        }
        else
        {
            var gameobject = new GameObject();
            return gameobject.transform;
        }
        
    }
    private void callSpawnKitsunePartical()
    {
        
        var obj = Instantiate(kitsunePrefab_, GameManager.Instance.PlayerObject.transform.position, quaternion.identity);
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        Vector2 worldCenter = Camera.main.ScreenToWorldPoint(screenCenter);
        obj.transform.position = worldCenter;
        var destroyer = obj.GetComponent<PoolObjectDestroyer>();
        destroyer.StartDestroyTimer(1.5f);
    }
    public void TestAddWeaponToPlayer()
    {
        GameManager.Instance.M_PlayerDataManager.WeaponPacks.Add(weaponDataBase.GetWeaponByID(1).Clone());
        GameManager.Instance.PlayerUpgrate();
    }
   
}
