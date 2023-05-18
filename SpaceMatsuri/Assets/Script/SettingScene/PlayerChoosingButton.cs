using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoosingButton : MonoBehaviour
{
    [SerializeField] private int thisButtonPlayerId;
    public void StartBattleByIDButton()
    {
        GameManager.Instance.M_PlayerDataManager.PlayerDataInit(thisButtonPlayerId);
    }
}
