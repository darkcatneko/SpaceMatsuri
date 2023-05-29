using System.Collections;
using System.Collections.Generic;
using System.Net;
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
    public void TargetLock(Transform monster)
    {
        IsBeenRelease = false;
        FowardDirection = (monster.position - this.gameObject.transform.position).normalized;
    }
    private void Update()
    {
        ThisObjectMove(FowardDirection, ThisProjectileData.MovementSpeed);
    }

    // 在場景中繪製圓形範圍以進行視覺化
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
