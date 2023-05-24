using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{  
    private CameraManager cameraManager_ = new CameraManager();

    public async Task spawnPlayerPrefab()
    {
        var playerObjectPrefab_ = await AddressableSearcher.GetAddressableAssetAsync<GameObject>(GameManager.Instance.IngamePlayerData.PlayerPrefabPath);
        var playerObject = Instantiate(playerObjectPrefab_, Vector3.zero, Quaternion.identity);
        GameManager.Instance.PlayerObject = playerObject;
        cameraManager_.PairPlayerObjectWithCamera();        
    }
    
}
