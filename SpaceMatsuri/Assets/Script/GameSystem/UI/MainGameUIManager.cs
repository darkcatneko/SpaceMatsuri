using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class MainGameUIManager : MonoBehaviour
{
    #region FeverTimeUseUI
    //[SerializeField] UIBarScript TensionBarUI;
    [SerializeField] Sprite FeverImage_Base;
    [SerializeField] Sprite FeverImage_Fever;
    [SerializeField] GameObject FeverTimerObject;
    //[SerializeField] GameObject FeverTimeEndPosition;
    [SerializeField] Image FeverTimeUIImage;
    [SerializeField] Image FeverTimeTimerCircleImage;
    //private Vector3 FeverTimeStartPosition;
    private float feverTimeActivateTime_ = 0;
    [Header("Combo")]
    [SerializeField] GameObject ComboObject;
    [SerializeField] GameObject ComboEndPosition;
    private Vector3 ComboStartPosition;
    [SerializeField] private TextMeshProUGUI ComboText;
    [SerializeField] private Text ComboTextShadow;
    private int monsterKilledInFeverTime;
    #endregion
    #region UpgrateItemUsedUI
    [Header("UpgrateUI")]
    [SerializeField] GameObject upgrateUIS;
    [SerializeField] UpgrateButtonBehavior[] upgrateButtonBehavior_;
    [SerializeField]
    Image[] WeaponImages;
    [SerializeField]
    Image[] BuffItemImages;
    #endregion
    [Header("PlayerLevelBar")]
    [SerializeField] Slider playerLevelBar_;
    [SerializeField] TextMeshProUGUI PlayerLevelText;
    private void Start()
    {
        GameManager.Instance.M_MainGameEvent.TensionBarChangeEvent.AddListener(updateTenshinBar);
        GameManager.Instance.M_MainGameEvent.EnterFeverTimeEvent.AddListener(enterFeverTimeUIEvent);
        GameManager.Instance.M_MainGameEvent.FeverTimeOnUpdateEvent.AddListener(updateFeverTimeUIEvent);
        GameManager.Instance.M_MainGameEvent.ExitFeverTimeEvent.AddListener(exitFeverTimeUIEvent);
        GameManager.Instance.M_MainGameEvent.MonsterBeenKillByFireworkEvent.AddListener(updateComboText);
        GameManager.Instance.M_MainGameEvent.GameInitEvent.AddListener(initTensionBar);
        GameManager.Instance.M_MainGameEvent.CallFireworkSpawnEvent.AddListener(comboFireFeedBack);
        GameManager.Instance.M_MainGameEvent.PlayerLevelUpEvent.AddListener(updateLevelText);
        GameManager.Instance.M_MainGameEvent.PlayerLevelUpEvent.AddListener(callActivateUpgrateUI);
        GameManager.Instance.M_MainGameEvent.PlayerUpgrateEvent.AddListener(updateWeaponPackImageAndBuffItemImage);
        GameManager.Instance.M_MainGameEvent.PlayerUpgrateEvent.AddListener(callDisActiveUpgrateUI);
    }
    private void Update()
    {
        playerLevelBar_.value = GameManager.Instance.NowPlayerLevelPercentage;
    }
    private void initTensionBar()
    {
        //TensionBarUI.UpdateValue(0, 100);
        FeverTimeTimerCircleImage.fillAmount = 0;
    }
    private void updateTenshinBar(float result)
    {
        //TensionBarUI.UpdateValue( Mathf.RoundToInt(result), 100);
        FeverTimeTimerCircleImage.fillAmount = result / (100 + 100 * GameManager.Instance.FeverCount);
    }
    private void enterFeverTimeUIEvent()
    {
        feverTimeEnter();
        comboEnter();
    }
    private void feverTimeEnter()
    {
        //FeverTimeStartPosition = FeverTimerObject.transform.position;
        //FeverTimerObject.transform.DOMoveY(FeverTimeEndPosition.transform.position.y, 0.35f);
        FeverTimeUIImage.sprite = FeverImage_Fever;
        FeverTimeTimerCircleImage.fillAmount = 1;
        feverTimeActivateTime_ = GameManager.Instance.IngamePlayerData.FeverTimeLastTime;
    }
    private void comboEnter()
    {
        ComboStartPosition = ComboObject.transform.position;
        ComboObject.transform.DOMove(ComboEndPosition.transform.position, 0.35f);
        monsterKilledInFeverTime = 0;
        ComboText.text = monsterKilledInFeverTime.ToString();
        ComboTextShadow.text = monsterKilledInFeverTime.ToString();
    }
    private void updateComboText()
    {
        monsterKilledInFeverTime += 1;
        ComboText.text = monsterKilledInFeverTime.ToString();
        ComboTextShadow.text = monsterKilledInFeverTime.ToString();
    }
    private void comboFireFeedBack()
    {
        ComboObject.transform.DOScale(new Vector3(1, 1, 1), 0.1f);
        ComboObject.transform.DOPunchScale(new Vector3(0.15f, 0.15f, 1), 0.1f);
    }
    private void updateFeverTimeUIEvent()
    {
        feverTimeActivateTime_ -= Time.deltaTime;
        FeverTimeTimerCircleImage.fillAmount = feverTimeActivateTime_ / GameManager.Instance.IngamePlayerData.FeverTimeLastTime;
    }
    private void exitFeverTimeUIEvent()
    {
        FeverTimeTimerCircleImage.fillAmount = 0;
        FeverTimeUIImage.sprite = FeverImage_Base;
        //FeverTimerObject.transform.DOMoveY(FeverTimeStartPosition.y, 0.35f);
        ComboObject.transform.DOScale(new Vector3(1, 1, 1), 0.1f);
        ComboObject.transform.DOMove(ComboStartPosition, 0.35f);
    }
    private void updateLevelText()
    {
        PlayerLevelText.text = "LeveL:" + GameManager.Instance.IngamePlayerData.PlayerLevel;
    }
    private void callActivateUpgrateUI()
    {
        upgrateUIS.SetActive(true);
        Time.timeScale = 0;
        var levelUpItems = RandomUpgrateGenerater.RandomThreeUpgrateItem();
        for (int i = 0; i < upgrateButtonBehavior_.Length; i++)
        {
            upgrateButtonBehavior_[i].UpdateThisUpgrateButton(levelUpItems[i]);
        }
    }
    public void callDisActiveUpgrateUI()
    {
        upgrateUIS.SetActive(false);
        Time.timeScale = 1;
    }
    private void updateWeaponPackImageAndBuffItemImage()
    {
        for (int i = 0; i < GameManager.Instance.M_PlayerDataManager.WeaponPacks.Count; i++)
        {
            WeaponImages[i].sprite = GameManager.Instance.M_PlayerDataManager.WeaponPacks[i].WeaponSprite;
        }
        for (int i = 0; i < GameManager.Instance.M_PlayerDataManager.UpgrateItems.Count; i++)
        {
            BuffItemImages[i].sprite = GameManager.Instance.M_PlayerDataManager.UpgrateItems[i].ThisUpgrateItemSprite;
        }
    }
    
}
