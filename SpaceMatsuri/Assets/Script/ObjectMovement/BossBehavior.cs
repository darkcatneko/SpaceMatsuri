using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BossBehavior : ObjectMovementAbstract
{
    [SerializeField]
    private BasicMonsterDataTemplete ThisMonsterData;
    public bool BeenRelease = false;
    public bool Faceleft = true;
    private Vector3 getMonsterMoveDirection()
    {
        var direction = GameManager.Instance.PlayerObject.transform.position - this.gameObject.transform.position;
        direction.Normalize();
        return direction;
    }
    private void Update()
    {
        ThisObjectMove(getMonsterMoveDirection(), ThisMonsterData.MonsterMovementSpeed);
        flip();
        var thisPosition = this.gameObject.transform.position;
        var playerpPosition = GameManager.Instance.PlayerObject.transform.position;     
    }
    private void flip()
    {
        var velocityX = thisRigidbody_.velocity.x;
        if (Faceleft && velocityX > 0)
        {
            thisObject_.transform.localScale = new Vector3(thisObject_.transform.localScale.x * -1, thisObject_.transform.localScale.y, 1);
            Faceleft = false;
        }
        else if (!Faceleft && velocityX < 0)
        {
            thisObject_.transform.localScale = new Vector3(thisObject_.transform.localScale.x * -1, thisObject_.transform.localScale.y, 1);
            Faceleft = true;
        }
    }
    public override void ThisObjectBeenAttack(float damage, bool canDropLoot)
    {
        ThisMonsterData.Now_MonsterHealthPoint = ThisMonsterData.Now_MonsterHealthPoint - damage;
        //Debug.Log("Left  " + ThisMonsterData.Now_MonsterHealthPoint);
        beHitEffect();
        var percentage = ThisMonsterData.Now_MonsterHealthPoint / ThisMonsterData.MaxHealthPoint;
        GameManager.Instance.BossGetHurt(percentage);
        if (ThisMonsterData.Now_MonsterHealthPoint <= 0)
        {
            GameManager.Instance.M_StageManager.TransitionState(State_Enum.Game_Over_State,StageData.GetGameOverStageData(true));
            Debug.Log("BossKilled!!");
        }
    }
    private async void beHitEffect()
    {
        thisObject_.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 1);
        await Task.Delay(100);
        thisObject_.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 0);
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PlayerBeHit  " + ThisMonsterData.MonsterAttack);
            GameManager.Instance.PlayerGetDamage(ThisMonsterData.MonsterAttack);
            ThisObjectBeenAttack(ThisMonsterData.MonsterAttack, true);
            //ThisObjectBeenAttack(ThisMonsterData.Now_MonsterHealthPoint, true);
        }
    }

    public void InitMonsterData(BasicMonsterDataTemplete target)
    {
        BeenRelease = false;
        ThisMonsterData = target;
    }
}
