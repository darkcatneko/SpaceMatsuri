using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgrateButtonBehavior : MonoBehaviour
{
    public UpgrateStruct ThisUpgrateStruct;

    [SerializeField] Image thisUpgrateButtonImage;
    [SerializeField] TextMeshProUGUI thisUpgrateItemName;
    [SerializeField] TextMeshProUGUI thisUpgrateItemLevel;
    [SerializeField] TextMeshProUGUI thisUpgrateItemEffect;

    public void ActivateThisUpgrate()
    {
        if (ThisUpgrateStruct.UpgrateType == UpgrateType.Weapon)
        {

        }
    }
    public void UpdateThisUpgrateButton(UpgrateStruct thisUpgrate)
    {
        if (thisUpgrate.UpgrateType == UpgrateType.Weapon)
        {
            var thisweaponUpgrate = DataBaseCenter.Instance.WeaponDataBase.GetWeaponByID(thisUpgrate.ThisUpgrateId);
            ThisUpgrateStruct = thisUpgrate;
            thisUpgrateButtonImage.sprite = thisweaponUpgrate.WeaponSprite;
            thisUpgrateItemName.text = thisweaponUpgrate.Name;
            if (GameManager.Instance.M_PlayerDataManager.GetWeaponInPackById(thisUpgrate.ThisUpgrateId)!=null)
            {
                thisUpgrateItemLevel.text = (thisweaponUpgrate.NowLevel + 1).ToString();
                if (GameManager.Instance.M_PlayerDataManager.GetWeaponInPackById(thisUpgrate.ThisUpgrateId).NowLevel<=5)
                {
                    thisUpgrateItemEffect.text = "+1 projectile\r\n+5 damage";
                }
                else
                {
                    thisUpgrateItemEffect.text = "+10% scale\r\n+10 damage";
                }
            }
            else
            {
                thisUpgrateItemLevel.text = "NEW";
                thisUpgrateItemEffect.text = "+1 projectile\r\n+5 damage";
            }
            
        }
        else
        {
            var thisBuffItemUpgrate = DataBaseCenter.Instance.UpgrateItemDataBase.GetUpgrateItemDataByID(thisUpgrate.ThisUpgrateId);
            thisUpgrateButtonImage.sprite = thisBuffItemUpgrate.ThisUpgrateItemSprite;
            thisUpgrateItemName.text = thisBuffItemUpgrate.Name;
            thisUpgrateItemEffect.text = thisBuffItemUpgrate.MainEffectString;
            if (GameManager.Instance.M_PlayerDataManager.GetUpgrateItemInPackById(thisUpgrate.ThisUpgrateId) != null)
            {
                thisUpgrateItemLevel.text = (thisBuffItemUpgrate.NowLevel + 1).ToString();
            }
            else
            {
                thisUpgrateItemLevel.text = "NEW";
            }
        }
    }
}
