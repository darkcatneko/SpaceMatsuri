using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameUIManager : MonoBehaviour
{
    [SerializeField] UIBarScript TensionBarUI;
    [SerializeField] GameObject FeverTimerObject;
    private void Start()
    {
        GameManager.Instance.M_MainGameEvent.TensionBarChangeEvent.AddListener(updateTenshinBar);   
    }
    private void updateTenshinBar(float result)
    {
        TensionBarUI.UpdateValue( Mathf.RoundToInt(result), 100);
    }
}
