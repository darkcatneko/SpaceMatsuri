using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

public class UpgrateItemManager : MonoBehaviour
{
    private UpgrateItemDataBase upgrateItemDataBase_ => DataBaseCenter.Instance.UpgrateItemDataBase;

    //public async Task UpgrateItemManagerInit()
    //{
    //    await upgrateItemDataBase_.ReadCsv();
    //}
}
