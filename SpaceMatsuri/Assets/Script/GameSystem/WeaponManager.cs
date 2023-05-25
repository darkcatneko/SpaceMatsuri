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
    public void TrySpawnWeapon(Weapon weapon,Transform target)
    {
        if (Time.time>weapon.NextFireTime)
        {
            weapon.NextFireTime += weapon.AttackFrequence;
            SpawnWeapon(weapon, target);
        }
       
    }
    private void SpawnWeapon(Weapon weapon, Transform target)
    {
        switch (weapon.Id)
        {
            case 1:
                SpawnWaterGun(weapon, target, GameManager.Instance.PlayerObject.transform.position);
                return;
        }
    }
    public void SpawnWaterGun(Weapon weapon, Transform targetTransform,Vector3 originPoint)
    {
        var waterGunPrefab = weapon.WeaponPrefab;
        var waterGunObject = waterGunPool.GetGameObject(waterGunPrefab, originPoint, Quaternion.identity);
        var waterGunMover = waterGunObject.GetComponent<WaterGunProjectileMovement>();
        waterGunMover.ThisProjectileData = weaponDataBase.GetWeaponByID(1).Clone();
        waterGunMover.TargetLock(targetTransform);
    }
}
