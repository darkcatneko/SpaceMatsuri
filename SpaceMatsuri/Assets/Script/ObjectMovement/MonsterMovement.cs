using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : ObjectMovementAbstract
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
    }

}
