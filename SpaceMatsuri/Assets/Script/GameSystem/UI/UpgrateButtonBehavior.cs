using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgrateButtonBehavior : MonoBehaviour
{
    [SerializeField] Image thisUpgrateButtonImage;
    [SerializeField] TextMeshProUGUI thisUpgrateItemName;
    [SerializeField] TextMeshProUGUI thisUpgrateItemLevel;

    public void UpdateThisUpgrateButton(UpgrateStruct thisUpgrate)
    {
        if (thisUpgrate.UpgrateType == UpgrateType.Weapon)
        {
            var thisweaponUpgrate = DataBaseCenter.Instance.WeaponDataBase.GetWeaponByID(thisUpgrate.ThisUpgrateId);
            thisUpgrateButtonImage.sprite = thisweaponUpgrate.WeaponSprite;
            thisUpgrateItemName.text = thisweaponUpgrate.Name;
            if (GameManager.Instance.M_PlayerDataManager.GetWeaponInPackById(thisUpgrate.ThisUpgrateId)!=null)
            {
                thisUpgrateItemLevel.text = (thisweaponUpgrate.NowLevel + 1).ToString();
            }
            else
            {
                thisUpgrateItemLevel.text = "NEW";
            }
        }
        else
        {
            var thisBuffItemUpgrate = DataBaseCenter.Instance.UpgrateItemDataBase.GetUpgrateItemDataByID(thisUpgrate.ThisUpgrateId);
            thisUpgrateButtonImage.sprite = thisBuffItemUpgrate.ThisUpgrateItemSprite;
            thisUpgrateItemName.text = thisBuffItemUpgrate.Name;
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