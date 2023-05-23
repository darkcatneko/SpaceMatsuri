using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private CameraManager cameraManager_;
    private GameObject playerObjectPrefab_;

    private void Start()
    {
        GameManager.Instance.M_MainGameEvent.GameInitEvent.AddListener(spawnPlayerPrefab);
    }
    private async void spawnPlayerPrefab()
    {
        playerObjectPrefab_ = await AddressableSearcher.GetAddressableAssetAsync<GameObject>(GameManager.Instance.IngamePlayerData.PlayerPrefabPath);
        var playerObject = Instantiate(playerObjectPrefab_, Vector3.zero, Quaternion.identity);
        GameManager.Instance.PlayerObject = playerObject;
        cameraManager_.PairPlayerObjectWithCamera();        
    }
    
}
