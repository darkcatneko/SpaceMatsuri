using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DropItemSystem : MonoBehaviour
{
    private GameObject tamashiPrefab_;
    public ObjectPoolClass TamashiPool;
    public async Task DropItemSystemInit()
    {
        tamashiPrefab_ = await AddressableSearcher.GetAddressableAssetAsync<GameObject>("");
    }
}
