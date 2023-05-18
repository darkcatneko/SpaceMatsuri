using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SettingButtonEvent : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField_;
    public void StartBattleButton()
    {
        var choosenPlayerId = -1;
        var testString = "1";
        var inputText = inputField_.textComponent.text;
        var typeingRightTest_ = int.TryParse(inputText, out choosenPlayerId);
        var typeingRight = int.TryParse(testString, out choosenPlayerId);
        if (typeingRight)GameManager.Instance.M_PlayerDataManager.PlayerDataInit(choosenPlayerId);
    }
    public void StartBattleByIDButton()
    {
        var choosenPlayerId = 1;
        GameManager.Instance.M_PlayerDataManager.PlayerDataInit(choosenPlayerId);
    }
}
