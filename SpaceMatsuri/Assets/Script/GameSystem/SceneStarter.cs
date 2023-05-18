using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStarter : MonoBehaviour
{    
    void Start()
    {
        GameManager.Instance.GameStart();
    }       
}
