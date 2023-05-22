using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : ObjectMovementAbstract
{
    protected override void ThisObjectStartInit()
    {
        GameManager.Instance.M_MainGameEvent.PlayerMovement.AddListener(ThisObjectMove);
    }
}
