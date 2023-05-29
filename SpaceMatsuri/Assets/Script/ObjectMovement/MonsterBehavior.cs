using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : ObjectMovementAbstract
{
    public BasicMonsterDataTemplete ThisMonsterData;
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
        var destroyer = this.gameObject.GetComponent<PoolObjectDestroyer>();
        destroyer.ReleaseThisObject();
        GameManager.Instance.ReleaseMonster();
    }
    protected override void ThisObjectBeenAttack()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            var attackPower = collision.GetComponent<WeaponBehaviorBase>().ThisProjectileData;
            Debug.Log("BeHit  " + attackPower);
        }
    }
}
