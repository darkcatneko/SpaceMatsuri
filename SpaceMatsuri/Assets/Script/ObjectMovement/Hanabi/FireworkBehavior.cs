using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class FireworkBehavior : WeaponBehaviorBase
{
    public float radius = 5f;

    public LayerMask monsterLayer;
    public List<GameObject> monsters;
    public List<GameObject> FindMonsters()
    {
        List<GameObject> monsters = new List<GameObject>();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, monsterLayer);

        foreach (Collider2D collider in colliders)
        {
            GameObject monster = collider.gameObject;
            monsters.Add(monster);
        }

        return monsters;
    }
    [SerializeField] private GameObject Hanabi;
    public ObjectPoolClass HanabiParticalPool;
    public void TargetLock(Transform monster)
    {
        IsBeenRelease = false;
        gameObject.transform.DetachChildren();
        FowardDirection = (monster.position - this.gameObject.transform.position).normalized;
    }
    private void Update()
    {
        ThisObjectMove(FowardDirection, ThisProjectileData.MovementSpeed);
    }
    public override void ReleaseThisObject()
    {
        playHanabiAnimation();
        //找到所有怪物 然後扁他
           var monsterInRange = FindMonsters();
        foreach (var monster in monsterInRange)
        {
            monster.GetComponent<MonsterBehavior>().ThisObjectBeenAttack(9999,true);
        }
        base.ReleaseThisObject();
    }
    public void playHanabiAnimation()
    {
        var hanabiPartical = HanabiParticalPool.GetGameObject(Hanabi, gameObject.transform.position, Quaternion.identity);
        hanabiPartical.GetComponent<ParticleSystem>().Play();
        var destroyer = hanabiPartical.GetComponent<PoolObjectDestroyer>();
        destroyer.StartDestroyTimer(1.5f);
    }
    // 在場景中繪製圓形範圍以進行視覺化
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
