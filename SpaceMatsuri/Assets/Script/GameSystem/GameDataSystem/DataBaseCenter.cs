using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DataBaseCenter : ToSingletonMonoBehavior<DataBaseCenter>
{
    public WeaponDataBase WeaponDataBase = new WeaponDataBase();
    public UpgrateItemDataBase UpgrateItemDataBase = new UpgrateItemDataBase();
    protected async override void init()
    {
        await WeaponDataBase.ReadCsv();
        await UpgrateItemDataBase.ReadCsv();
    }

}
