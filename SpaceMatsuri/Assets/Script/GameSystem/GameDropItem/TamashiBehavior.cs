using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamashiBehavior : DropItemBaseClass
{
    [field:SerializeField] public float ExpirienceCanGain { get; private set; }
    [SerializeField] private PoolObjectDestroyer objectDestroyer_;
    public override void ActivateDropItemSkill()
    {
       // Debug.Log("TamashiBehavior!");
        GameManager.Instance.PlayerGainExperience(ExpirienceCanGain);
        objectDestroyer_.ReleaseThisObject();
    }
}
