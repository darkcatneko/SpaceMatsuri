using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UIElements;

public class PlayerTempleteDataBase
{
    public List<BasicPlayerDataTemplate> M_PlayerTempleteDataBase = new List<BasicPlayerDataTemplate>();
    public void PlayerTempleteDataBaseInit() 
    {
        ReadCsv();
    }
    public async void ReadCsv()
    {
        var textAsset = await AddressableSearcher.GetAddressableAssetAsync<TextAsset>("Excel/SpaceMatsuriCharacterSheet");        
        var classArray = await CSVClassGenerator.GenClassArrayByCSV<BasicPlayerDataTemplate>(textAsset);
        addDataIntoDataBase(classArray);
        Debug.Log("");
    }      
    private void addDataIntoDataBase(BasicPlayerDataTemplate[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            M_PlayerTempleteDataBase.Add(data[i]);
        }
    }
    public BasicPlayerDataTemplate GetBasicPlayerDataByID(int id)
    {
        var result = new BasicPlayerDataTemplate();
        for (int i = 0; i < M_PlayerTempleteDataBase.Count; i++)
        {
            if (M_PlayerTempleteDataBase[i].PlayerTemplete_ID == id)
            {
                return M_PlayerTempleteDataBase[i];
            }
        }
        return result;
    }
}
