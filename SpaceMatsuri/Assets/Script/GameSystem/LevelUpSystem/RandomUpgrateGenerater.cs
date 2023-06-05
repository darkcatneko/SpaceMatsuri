using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUpgrateGenerater
{
    public static List<UpgrateStruct> RandomThreeUpgrateItem()
    {
        var upgrateItemPool = getUpgrateItemPool();
        var randomResults = new List<UpgrateStruct>();
        for (int i = 0; i < 3; i++)
        {
            var randomNum = UnityEngine.Random.Range(0, upgrateItemPool.Count);
            randomResults.Add(upgrateItemPool[randomNum]);
            upgrateItemPool.Remove(upgrateItemPool[randomNum]);
        }
        return randomResults;
       
    }
    private static List<UpgrateStruct> getUpgrateItemPool()
    {
        var upgrateItemPool = new List<UpgrateStruct>();
        if (GameManager.Instance.M_PlayerDataManager.WeaponPacks.Count < 3)
        {
            for (int i = 0; i < DataBaseCenter.Instance.WeaponDataBase.M_WeaponDataBase.Count; i++)
            {
                var weapon = DataBaseCenter.Instance.WeaponDataBase.M_WeaponDataBase[i];
                var weaponInPack = GameManager.Instance.M_PlayerDataManager.GetWeaponInPackById(weapon.Id);
                if (weapon.Id != 99)
                {
                    if (weaponInPack != null)
                    {
                        if (weaponInPack.NowLevel != 10)
                        {
                            upgrateItemPool.Add(new UpgrateStruct(UpgrateType.Weapon, weapon.Id));
                        }
                    }
                    else
                    {
                        upgrateItemPool.Add(new UpgrateStruct(UpgrateType.Weapon, weapon.Id));
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < DataBaseCenter.Instance.WeaponDataBase.M_WeaponDataBase.Count; i++)
            {
                var weapon = DataBaseCenter.Instance.WeaponDataBase.M_WeaponDataBase[i];
                var weaponInPack = GameManager.Instance.M_PlayerDataManager.GetWeaponInPackById(weapon.Id);
                if (weapon.Id != 99)
                {
                    if (weaponInPack != null)
                    {
                        if (weaponInPack.NowLevel != 10)
                        {
                            upgrateItemPool.Add(new UpgrateStruct(UpgrateType.Weapon, weapon.Id));
                        }
                    }
                }
            }
        }

        if (GameManager.Instance.M_PlayerDataManager.UpgrateItems.Count < 3)
        {
            for (int i = 0; i < DataBaseCenter.Instance.UpgrateItemDataBase.M_UpgrateItemDataBase.Count; i++)
            {
                var upgrateItem = DataBaseCenter.Instance.UpgrateItemDataBase.M_UpgrateItemDataBase[i];
                var upgrateItemInPack = GameManager.Instance.M_PlayerDataManager.GetUpgrateItemInPackById(upgrateItem.Id);
                if (upgrateItemInPack != null)
                {
                    if (upgrateItemInPack.NowLevel != upgrateItem.MaxCanGetLevel)
                    {
                        upgrateItemPool.Add(new UpgrateStruct(UpgrateType.BuffItem, upgrateItem.Id));
                    }
                }
                else
                {
                    upgrateItemPool.Add(new UpgrateStruct(UpgrateType.BuffItem, upgrateItem.Id));
                }
            }
        }
        else
        {
            for (int i = 0; i < DataBaseCenter.Instance.UpgrateItemDataBase.M_UpgrateItemDataBase.Count; i++)
            {
                var upgrateItem = DataBaseCenter.Instance.UpgrateItemDataBase.M_UpgrateItemDataBase[i];
                var upgrateItemInPack = GameManager.Instance.M_PlayerDataManager.GetUpgrateItemInPackById(upgrateItem.Id);
                if (upgrateItemInPack != null)
                {
                    if (upgrateItemInPack.NowLevel != upgrateItem.MaxCanGetLevel)
                    {
                        upgrateItemPool.Add(new UpgrateStruct(UpgrateType.BuffItem, upgrateItem.Id));
                    }
                }
            }
        }
        return upgrateItemPool;
    }
}

[Serializable]
public struct UpgrateStruct
{
    public UpgrateType UpgrateType;
    public int ThisUpgrateId;
    public UpgrateStruct(UpgrateType type, int id)
    {
        UpgrateType = type;
        ThisUpgrateId = id;
    }
}
public enum UpgrateType
{
    Weapon, BuffItem,
}
