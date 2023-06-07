using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;
public class PlayerMovementManager : ObjectMovementAbstract
{
    [SerializeField] Image healthBarImage_;

    protected override void ThisObjectStartInit()
    {
        GameManager.Instance.M_MainGameEvent.PlayerMovement.AddListener(ThisObjectMove);
        GameManager.Instance.M_MainGameEvent.PlayerGetAttackEvent.AddListener(updateHealthUIImage);
        GameManager.Instance.M_MainGameEvent.PlayerUpgrateEvent.AddListener(updateHealthUIImage);
        GameManager.Instance.M_MainGameEvent.PlayerGetAttackEvent.AddListener(beHitEffect);
    }
    private void updateHealthUIImage()
    {
        healthBarImage_.fillAmount = GameManager.Instance.IngamePlayerData.Now_PlayerHealthPoint / GameManager.Instance.IngamePlayerData.MaxHealthPoint;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DropItem"))
        {
            collision.GetComponent<DropItemBaseClass>().ActivateDropItemSkill();
        }
    }
    private async void beHitEffect()
    {
        thisObject_.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 1);
        await Task.Delay(100);
        if (thisObject_ != null)
        {
            thisObject_.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 0);
        }
    }
}
