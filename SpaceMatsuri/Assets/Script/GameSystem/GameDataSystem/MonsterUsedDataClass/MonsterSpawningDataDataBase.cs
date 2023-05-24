using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MonsterSpawningDataDataBase
{
    public List<MonsterSpawnerUsedSpawningDataTemplete> M_MonsterSpawningDataDataBase = new List<MonsterSpawnerUsedSpawningDataTemplete>();
    public async Task ReadCsv()
    {
        var textAsset = await AddressableSearcher.GetAddressableAssetAsync<TextAsset>("Excel/SpaceMatsuriMonsterSpawnDataSheet");
        var classArray = await CSVClassGenerator.GenClassArrayByCSV<MonsterSpawnerUsedSpawningDataTemplete>(textAsset);
        addDataIntoDataBase(classArray);
    }
    private void addDataIntoDataBase(MonsterSpawnerUsedSpawningDataTemplete[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            M_MonsterSpawningDataDataBase.Add(data[i]);
        }
    }
    public MonsterSpawnerUsedSpawningDataTemplete GetSpawnerDataByPhase(int phase)
    {
        var result = new MonsterSpawnerUsedSpawningDataTemplete();
        for (int i = 0; i < M_MonsterSpawningDataDataBase.Count; i++)
        {
            if (M_MonsterSpawningDataDataBase[i].PhaseNumber == phase)
            {
                return M_MonsterSpawningDataDataBase[i];
            }
        }
        return result;
    }
}
