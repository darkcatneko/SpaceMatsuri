using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : ObjectMovementAbstract
{
    private BasicMonsterDataTemplete ThisMonsterData;
    public bool BeenRelease = false;
    private Vector3 getMonsterMoveDirection()
    {
        var direction = GameManager.Instance.PlayerObject.transform.position - this.gameObject.transform.position  ;
        direction.Normalize();
        return direction;
    }
    private void Update()
    {
        ThisObjectMove(getMonsterMoveDirection(), ThisMonsterData.MonsterMovementSpeed);
        var thisPosition = this.gameObject.transform.position;
        var playerpPosition = GameManager.Instance.PlayerObject.transform.position;
        var distance = (thisPosition - playerpPosition).magnitude;
        if (distance>50f)
        {
            releaseThisObject();
        }
    }
    private void releaseThisObject()
    {
        if (!BeenRelease)
        {
            var destroyer = this.gameObject.GetComponent<PoolObjectDestroyer>();
            destroyer.ReleaseThisObject();
            BeenRelease = true;
            GameManager.Instance.ReleaseMonster();
        }
       
    }
    public override void ThisObjectBeenAttack(float damage,bool canDropLoot)
    {
        ThisMonsterData.Now_MonsterHealthPoint = ThisMonsterData.Now_MonsterHealthPoint - damage;
        Debug.Log("Left  " + ThisMonsterData.Now_MonsterHealthPoint);
        if (ThisMonsterData.Now_MonsterHealthPoint <= 0)
        {
            thisMonsterBeenKill(canDropLoot);
        }
    }
    private void thisMonsterBeenKill(bool canDropLoot)
    {
        var resultFeverBarValue = GameManager.Instance.IngamePlayerData.Now_TensionBar + 1 * GameManager.Instance.IngamePlayerData.MatsuriTenshenChargeSpeed;
        GameManager.Instance.ChangePlayerTension(resultFeverBarValue);
        releaseThisObject();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            var attackPower = collision.GetComponent<WeaponBehaviorBase>().ThisProjectileData.BasicAttack;
            collision.GetComponent<WeaponBehaviorBase>().ReleaseThisObject();
            ThisObjectBeenAttack(attackPower,true);
            Debug.Log("BeHit  " + attackPower);
        }
        if (collision.gameObject.CompareTag("Hanabi"))
        {
            collision.GetComponent<FireworkBehavior>().ReleaseThisObject();
        }
    }
    public void InitMonsterData(BasicMonsterDataTemplete target)
    {
        BeenRelease = false;
        ThisMonsterData = target;
    }
}
