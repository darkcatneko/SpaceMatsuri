using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class MainGameEvent
{
    public UnityEvent GameInitEvent = new UnityEvent();
    public UnityEvent GameStartEvent = new UnityEvent();
    public UnityEvent<Vector3, float> PlayerMovement = new UnityEvent<Vector3, float>();

    public UnityEvent MonsterBeenReleaseEvent = new UnityEvent();

    public UnityEvent FreeGamePlayUpdateEvent = new UnityEvent();

    public UnityEvent FeverTimeOnUpdateEvent = new UnityEvent();

    public UnityEvent CallFireworkSpawnEvent = new UnityEvent();

    public UnityEvent EnterFeverTimeEvent = new UnityEvent();

    public UnityEvent ExitFeverTimeEvent = new UnityEvent();

    public UnityEvent<Weapon> CallWeaponSpawn = new UnityEvent<Weapon>();

    public UnityEvent<float> TensionBarChangeEvent = new UnityEvent<float>();

    public UnityEvent MonsterBeenKillByFireworkEvent = new UnityEvent();
    public UnityEvent PlayerGetAttackEvent = new UnityEvent();
    public UnityEvent<Vector3> CallSpawnDropItem = new UnityEvent<Vector3>();
    public UnityEvent PlayerLevelUpEvent = new UnityEvent();
    public UnityEvent PlayerUpgrateEvent = new UnityEvent();
}
