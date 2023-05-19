using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerChoosingButton : MonoBehaviour
{
    [SerializeField] private int thisButtonPlayerId;
    public void StartBattleByIDButton()
    {
        GameManager.Instance.M_PlayerDataManager.PlayerDataInit(thisButtonPlayerId);
        SceneManager.LoadScene(1);
    }
}
