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
        var textAsset = await AddressableSearcher.GetAddressableAsset<TextAsset>("Excel/SpaceMatsuriCharacterSheet");
        //string[] data = textAsset.text.Split(new string[] { "\r\n" }, System.StringSplitOptions.None);
        //string[][] tempdata = new string[data.Length][];
        //for (int i = 0; i < data.Length; i++)
        //{
        //    string[] datastring = data[i].Split(new string[] { "," }, System.StringSplitOptions.None);
        //    tempdata[i] = datastring;
        //}
        var classArray = CSVClassGenerator.GenClassArrayByCSV<BasicPlayerDataTemplate>(textAsset);
        addDataIntoDataBase(classArray);
    }    
    //private void addDataIntoDataBase(string[][] data)
    //{
    //    for (int i = 1; i < data.Length; i++)
    //    {
    //        M_PlayerTempleteDataBase.Add(new BasicPlayerDataTemplate(data[i]));
    //    }
    //}
    private void addDataIntoDataBase(BasicPlayerDataTemplate[] data)
    {
        for (int i = 1; i < data.Length; i++)
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
