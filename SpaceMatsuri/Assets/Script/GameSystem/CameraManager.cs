using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

[Serializable]
public class CameraManager
{
    [SerializeField]private CinemachineVirtualCamera _cam;
    public void PairPlayerObjectWithCamera()
    {
        var playerObject = GameManager.Instance.PlayerObject;
        _cam.Follow = playerObject.transform;
        _cam.LookAt = playerObject.transform;
    }
}
