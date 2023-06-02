using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgrateItemDataBase
{
    public List<UpgrateItem> M_UpgrateItemDataBase = new List<UpgrateItem>();
    public void UpgrateItemDataBaseInit()
    {

    }
    public async void ReadCsv()
    {
        var textAsset = await AddressableSearcher.GetAddressableAssetAsync<TextAsset>("");
    }
}
