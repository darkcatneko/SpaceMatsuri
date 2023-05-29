using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private WeaponDataBase weaponDataBase = new WeaponDataBase();
    public ObjectPoolClass waterGunPool;
    public async Task WeaponManagerInit()
    {
        await weaponDataBase.ReadCsv();
        waterGunPool = this.gameObject.AddComponent<ObjectPoolClass>();
    }
    private void Start()
    {
        GameManager.Instance.M_MainGameEvent.CallWeaponSpawn.AddListener(TrySpawnWeapon);
        GameManager.Instance.M_MainGameEvent.GameStartEvent.AddListener(TestAddWeaponToPlayer);
    }
    public void TrySpawnWeapon(Weapon weapon)
    {
        if (Time.time>weapon.NextFireTime)
        {
            weapon.NextFireTime += weapon.AttackFrequence;
            SpawnWeapon(weapon);
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
        var waterGunObject = waterGunPool.GetGameObject(waterGunPrefab, originPoint, Quaternion.identity);
        var waterGunMover = waterGunObject.GetComponent<WaterGunProjectileMovement>();
        var target = GetANearestMonster();
        waterGunMover.ThisProjectileData = weaponDataBase.GetWeaponByID(1).Clone();
        waterGunMover.TargetLock(target);
        var destroyer = waterGunObject.GetComponent<PoolObjectDestroyer>();
        destroyer.Pool = waterGunPool;//加入自毀器
        
    }
    public Transform GetANearestMonster()
    {
        var nearesrDistance = 100f;
        var allMonster = GameObject.FindGameObjectsWithTag("Monster");
        var targerTransform = allMonster[0].transform;
        for (int i = 0; i < allMonster.Length; i++)
        {
            if ((allMonster[i].transform.position - GameManager.Instance.PlayerObject.transform.position).magnitude < nearesrDistance)
            {
                targerTransform = allMonster[i].transform;
                nearesrDistance = (allMonster[i].transform.position - GameManager.Instance.PlayerObject.transform.position).magnitude;
            }
        }
        return targerTransform;
    }
    public void TestAddWeaponToPlayer()
    {
        GameManager.Instance.M_PlayerDataManager.WeaponPacks.Add(weaponDataBase.GetWeaponByID(1).Clone());
    }
}
