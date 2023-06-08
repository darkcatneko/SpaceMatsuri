using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class SoundEffectDataBase
{
    public List<SoundEffect> M_SoundEffectDataBase = new List<SoundEffect>();
    public async Task ReadCsv()
    {
        var textAsset = await AddressableSearcher.GetAddressableAssetAsync<TextAsset>("Excel/SpaceMatsuriSoundEffectSheet");
        var classArray = await CSVClassGenerator.GenClassArrayByCSV<SoundEffect>(textAsset);
        addDataIntoDataBase(classArray);
        Debug.Log("");
    }
    private void addDataIntoDataBase(SoundEffect[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            M_SoundEffectDataBase.Add(data[i]);
        }
    }
    public SoundEffect GetSoundEffectByID(int id)
    {
        var result = new SoundEffect();
        for (int i = 0; i < M_SoundEffectDataBase.Count; i++)
        {
            if (M_SoundEffectDataBase[i].Id == id)
            {
                return M_SoundEffectDataBase[i];
            }
        }
        return result;
    }
}
public class SoundEffect
{
    public string ClipName { get; set; }
    public int Id { get; set; }
    public AudioClip Clip { get; set; }
}

