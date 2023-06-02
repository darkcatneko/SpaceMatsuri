using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DropItemSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject tamashiPrefab_;
    public ObjectPoolClass TamashiPool;
    public async Task DropItemSystemInit()
    {
        tamashiPrefab_ = await AddressableSearcher.GetAddressableAssetAsync<GameObject>("Prefab/tamashi");
        TamashiPool = this.gameObject.AddComponent<ObjectPoolClass>();
    }
    private void Start()
    {
        GameManager.Instance.M_MainGameEvent.CallSpawnDropItem.AddListener(spawnADropItem);
    }
    private void spawnADropItem(Vector3 spawnPosition)
    {
        // Instantiate(tamashiPrefab_, spawnPosition, Quaternion.identity);
        var DropItem = TamashiPool.GetGameObject(tamashiPrefab_, spawnPosition, Quaternion.identity);
        var destroyer = DropItem.GetComponent<PoolObjectDestroyer>();
        destroyer.Pool = TamashiPool;//加入自毀器
    }
}
