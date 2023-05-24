using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

[Serializable]
public class CameraManager
{
    private CinemachineVirtualCamera _cam;
    public void PairPlayerObjectWithCamera()
    {
        _cam = Camera.main.GetComponentInChildren<CinemachineVirtualCamera>();
        var playerObject = GameManager.Instance.PlayerObject;
        _cam.Follow = playerObject.transform;
        _cam.LookAt = playerObject.transform;
    }
}
