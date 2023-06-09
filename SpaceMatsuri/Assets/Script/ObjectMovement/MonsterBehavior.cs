using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MonsterBehavior : ObjectMovementAbstract
{
    [SerializeField]
    private BasicMonsterDataTemplete ThisMonsterData;
    public bool BeenRelease = false;
    public bool Faceleft = true;
    private Vector3 getMonsterMoveDirection()
    {
        var direction = GameManager.Instance.PlayerObject.transform.position - this.gameObject.transform.position  ;
        direction.Normalize();
        return direction;
    }
    private void Update()
    {
        ThisObjectMove(getMonsterMoveDirection(), ThisMonsterData.MonsterMovementSpeed);
        flip();
        var thisPosition = this.gameObject.transform.position;
        var playerPosition = GameManager.Instance.PlayerObject.transform.position;
        var distance = (thisPosition - playerPosition).magnitude;
        if (distance>50f)
        {
            releaseThisObject();
        }
    }
    private void flip()
    {
        var velocityX = thisRigidbody_.velocity.x;
        if (Faceleft && velocityX>0)
        {
            thisObject_.transform.localScale =new Vector3(thisObject_.transform.localScale.x*-1, thisObject_.transform.localScale.y,1);
            Faceleft = false;
        }
        else if (!Faceleft && velocityX<0)
        {           
            thisObject_.transform.localScale = new Vector3(thisObject_.transform.localScale.x * -1, thisObject_.transform.localScale.y, 1);
            Faceleft = true;
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
        beHitEffect();
        //Debug.Log("Left  " + ThisMonsterData.Now_MonsterHealthPoint);
        if (ThisMonsterData.Now_MonsterHealthPoint <= 0)
        {
            thisMonsterBeenKill(canDropLoot);
        }
    }
    private async void beHitEffect()
    {
        thisObject_.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 1);
        await Task.Delay(100);
        if (thisObject_!=null)
        {
            thisObject_.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 0);
        }
    }
    private void thisMonsterBeenKill(bool canDropLoot)
    {
        var resultFeverBarValue = GameManager.Instance.IngamePlayerData.Now_TensionBar + 1 * GameManager.Instance.IngamePlayerData.MatsuriTenshenChargeSpeed;
        GameManager.Instance.ChangePlayerTension(resultFeverBarValue);
        if (canDropLoot)
        {
            GameManager.Instance.CallSpawnDropItem(gameObject.transform.position,ThisMonsterData.DropChance);
        }
        releaseThisObject();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            var weaponAttackPower = collision.GetComponent<WeaponBehaviorBase>().ThisProjectileData.BasicAttack;
            var totalAttackPower = weaponAttackPower + GameManager.Instance.IngamePlayerData.PlayerAttack;
            collision.GetComponent<WeaponBehaviorBase>().ReleaseThisObject();
            ThisObjectBeenAttack(totalAttackPower, true);
            //Debug.Log("BeHit  " + attackPower);
        }
        if (collision.gameObject.CompareTag("Hanabi"))
        {
            collision.GetComponent<FireworkBehavior>().ReleaseThisObject();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PlayerBeHit  " + ThisMonsterData.MonsterAttack);
            GameManager.Instance.PlayerGetDamage(ThisMonsterData.MonsterAttack);
            ThisObjectBeenAttack(ThisMonsterData.MaxHealthPoint, true);
            //ThisObjectBeenAttack(ThisMonsterData.Now_MonsterHealthPoint, true);
        }
    }
    public void InitMonsterData(BasicMonsterDataTemplete target)
    {
        BeenRelease = false;
        ThisMonsterData = target;
    }
}
