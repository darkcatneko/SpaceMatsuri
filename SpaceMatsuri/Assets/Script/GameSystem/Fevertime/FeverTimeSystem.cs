using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverTimeSystem : MonoBehaviour
{
    private GameObject hanabiPrefab;
    private async void Start()
    {
        hanabiPrefab = await AddressableSearcher.GetAddressableAssetAsync<GameObject>("Prefab/HanabiTama");
    }
    private void shootHanabi()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
}
