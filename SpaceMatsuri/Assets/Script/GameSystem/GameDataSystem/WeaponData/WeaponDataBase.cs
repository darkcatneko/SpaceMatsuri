using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WeaponDataBase
{
    public List<Weapon> M_WeaponDataBase = new List<Weapon>();
    public async Task ReadCsv()
    {
        var textAsset = await AddressableSearcher.GetAddressableAssetAsync<TextAsset>("Excel/SpaceMatsuriWeaponSheet");
        var classArray = await CSVClassGenerator.GenClassArrayByCSV<Weapon>(textAsset);
        addDataIntoDataBase(classArray);
        Debug.Log("");
    }
    private void addDataIntoDataBase(Weapon[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            M_WeaponDataBase.Add(data[i]);
        }
    }
    public Weapon GetWeaponByID(int id)
    {
        var result = new Weapon();
        for (int i = 0; i < M_WeaponDataBase.Count; i++)
        {
            if (M_WeaponDataBase[i].Id == id)
            {
                return M_WeaponDataBase[i];
            }
        }
        return result;
    }
}
