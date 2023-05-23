using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTempleteDataBase
{
    public List<BasicMonsterDataTemplete> M_MonsterTempleteDataBase = new List<BasicMonsterDataTemplete>();
    public async void ReadCsv()
    {
        var textAsset = await AddressableSearcher.GetAddressableAssetAsync<TextAsset>("Excel/SpaceMatsuriMonsterSheet");
        var classArray = CSVClassGenerator.GenClassArrayByCSV<BasicMonsterDataTemplete>(textAsset);
        addDataIntoDataBase(classArray);
    }
    private void addDataIntoDataBase(BasicMonsterDataTemplete[] data)
    {
        for (int i = 1; i < data.Length; i++)
        {
            M_MonsterTempleteDataBase.Add(data[i]);
        }
    }
    public BasicMonsterDataTemplete GetMonsterDataByID(int id)
    {
        var result = new BasicMonsterDataTemplete();
        for (int i = 0; i < M_MonsterTempleteDataBase.Count; i++)
        {
            if (M_MonsterTempleteDataBase[i].MonsterTemplete_ID == id)
            {
                return M_MonsterTempleteDataBase[i];
            }
        }
        return result;
    }
}
