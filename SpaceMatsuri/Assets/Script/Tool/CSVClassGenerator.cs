using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

public class CSVClassGenerator
{

    public  static async Task<T[]> GenClassArrayByCSV<T>(TextAsset textAsset) where T : new()
    {               
        string[] data = textAsset.text.Split(new string[] { "\r\n" }, System.StringSplitOptions.None);
        string[][] tempdata = new string[data.Length][];
        for (int i = 0; i < data.Length; i++)
        {
            string[] datastring = data[i].Split(new string[] { "," }, System.StringSplitOptions.None);
            tempdata[i] = datastring;
        }
        var resultArray = new T[tempdata.Length-1];
        for (int i = 1; i < tempdata.Length; i++)
        {
            var result = new T();
            await SetClassData<T>(result, tempdata[i]);
            resultArray[i-1] = result;
        }
        return resultArray;
    }
    public static async Task SetClassData<T>(T DataBeSet, string[] dataText)
    {
        PropertyInfo[] propertyInfo = typeof(T).GetProperties();
        for (int i = 0; i < propertyInfo.Length; i++)
        {
            if (propertyInfo[i].PropertyType == typeof(string))
            {
                propertyInfo[i].SetValue(DataBeSet, dataText[i].ToString());
            }
            else if (propertyInfo[i].PropertyType == typeof(int))
            {
                propertyInfo[i].SetValue(DataBeSet,int.Parse(dataText[i]));
            }
            else if (propertyInfo[i].PropertyType == typeof(float))
            {
                propertyInfo[i].SetValue(DataBeSet, float.Parse(dataText[i]));
            }
            else if (propertyInfo[i].PropertyType == typeof(GameObject))
            {
                var gameobjectPrefab = await AddressableSearcher.GetAddressableAssetAsync<GameObject>(dataText[i]);
                propertyInfo[i].SetValue(DataBeSet, gameobjectPrefab);
            }
            else if (propertyInfo[i].PropertyType == typeof(bool))
            {
                if (dataText[i].ToString()=="TRUE")
                {
                    propertyInfo[i].SetValue(DataBeSet, true);
                }
                else if (dataText[i].ToString() == "FALSE")
                {
                    propertyInfo[i].SetValue(DataBeSet, false);
                }
            }
        }
    }
}
