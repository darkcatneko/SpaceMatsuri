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
            if (GameManager.Instance.M_PlayerDataManager.GetWeaponInPackById(ThisUpgrateStruct.ThisUpgrateId) != null)
            {
                GameManager.Instance.M_PlayerDataManager.GetWeaponInPackById(ThisUpgrateStruct.ThisUpgrateId).ThisWeaponLevelUp();
            }
            else
            {
                GameManager.Instance.M_PlayerDataManager.WeaponPacks.Add(DataBaseCenter.Instance.WeaponDataBase.GetWeaponByID(ThisUpgrateStruct.ThisUpgrateId).Clone());
            }
            GameManager.Instance.PlayerUpgrate();
        }
        else
        {
            var thisBuffItemData = DataBaseCenter.Instance.UpgrateItemDataBase.GetUpgrateItemDataByID(ThisUpgrateStruct.ThisUpgrateId).Clone();
            gainBuff(thisBuffItemData.WhichBuff, thisBuffItemData.BuffAmount);
            if (GameManager.Instance.M_PlayerDataManager.GetUpgrateItemInPackById(ThisUpgrateStruct.ThisUpgrateId)!=null)
            {
                GameManager.Instance.M_PlayerDataManager.GetUpgrateItemInPackById(ThisUpgrateStruct.ThisUpgrateId).NowLevel++;
            }
            else
            {
                GameManager.Instance.M_PlayerDataManager.UpgrateItems.Add(thisBuffItemData);
            }
            GameManager.Instance.PlayerUpgrate();
        }
    }
    private void gainBuff(string buffType, float amount)
    {
        switch (buffType)
        {
            case "MovementSpeed":
                GameManager.Instance.IngamePlayerData.PlayerMovementSpeed += amount;
                break;
            case "Health":
                GameManager.Instance.IngamePlayerData.MaxHealthPoint += amount;
                GameManager.Instance.IngamePlayerData.Now_PlayerHealthPoint += amount;
                break;
            case "FeverTimeLastTime":
                GameManager.Instance.IngamePlayerData.FeverTimeLastTime += amount;
                break;
            case "Attack":
                GameManager.Instance.IngamePlayerData.PlayerAttack += amount;
                break;
            case "FeverTimeChargeSpeed":
                GameManager.Instance.IngamePlayerData.MatsuriTenshenChargeSpeed += amount;
                break;
            case "ProjectileScale":
                GameManager.Instance.IngamePlayerData.AttackProjectileScale += amount;
                break;
            case "ProjectileCount":
                GameManager.Instance.IngamePlayerData.AttackProjectileBasicCount += (int)amount;
                break;
            case "AttackSpeed":
                GameManager.Instance.IngamePlayerData.AttackFrequence += amount;
                break;
        }
    }
    public void UpdateThisUpgrateButton(UpgrateStruct thisUpgrate)
    {
        ThisUpgrateStruct = thisUpgrate;
        if (thisUpgrate.UpgrateType == UpgrateType.Weapon)
        {
            var thisweaponUpgrate = DataBaseCenter.Instance.WeaponDataBase.GetWeaponByID(thisUpgrate.ThisUpgrateId);
            thisUpgrateButtonImage.sprite = thisweaponUpgrate.WeaponSprite;
            thisUpgrateItemName.text = thisweaponUpgrate.Name;
            if (GameManager.Instance.M_PlayerDataManager.GetWeaponInPackById(thisUpgrate.ThisUpgrateId) != null)
            {
                thisUpgrateItemLevel.text ="LV:"+ (GameManager.Instance.M_PlayerDataManager.GetWeaponInPackById(thisUpgrate.ThisUpgrateId).NowLevel + 1).ToString();
                if (GameManager.Instance.M_PlayerDataManager.GetWeaponInPackById(thisUpgrate.ThisUpgrateId).NowLevel <= 5)
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
                thisUpgrateItemLevel.text = "LV:" + (GameManager.Instance.M_PlayerDataManager.GetUpgrateItemInPackById(thisUpgrate.ThisUpgrateId).NowLevel + 1).ToString();
            }
            else
            {
                thisUpgrateItemLevel.text = "NEW";
            }
        }
    }
}
