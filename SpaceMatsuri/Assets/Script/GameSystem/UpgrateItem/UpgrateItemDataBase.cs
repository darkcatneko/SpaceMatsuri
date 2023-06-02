using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class UpgrateItemDataBase
{
    public List<UpgrateItem> M_UpgrateItemDataBase = new List<UpgrateItem>();
    public async Task ReadCsv()
    {
        var textAsset = await AddressableSearcher.GetAddressableAssetAsync<TextAsset>("Excel/SpaceMatsuriUpgrateItemSheet");
        var classArray = await CSVClassGenerator.GenClassArrayByCSV<UpgrateItem>(textAsset);
        addDataIntoDataBase(classArray);
    }
    private void addDataIntoDataBase(UpgrateItem[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            M_UpgrateItemDataBase.Add(data[i]);
        }
    }
    public UpgrateItem GetUpgrateItemDataByID(int id)
    {
        var result = new UpgrateItem();
        for (int i = 0; i < M_UpgrateItemDataBase.Count; i++)
        {
            if (M_UpgrateItemDataBase[i].Id == id)
            {
                return M_UpgrateItemDataBase[i];
            }
        }
        return result;
    }
}
