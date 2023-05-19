using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class CSVClassGenerator
{

    public static T[] GenClassArrayByCSV<T>(TextAsset textAsset) where T : new()
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
            SetClassData<T>(result, tempdata[i]);
            resultArray[i-1] = result;
        }
        return resultArray;
    }
    public static void SetClassData<T>(T DataBeSet, string[] dataText)
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
        }
    }
}
