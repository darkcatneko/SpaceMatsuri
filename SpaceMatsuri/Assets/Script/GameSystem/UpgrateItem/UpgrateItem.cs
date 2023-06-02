using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgrateItem
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int Id { get; private set; }
    [field: SerializeField] public int NowLevel { get; set; }
    [field:SerializeField] public Sprite ThisUpgrateItemSprite { get; private set; }
    public UpgrateItem Clone()
    {
        var clone = new UpgrateItem()
        {
            Name = Name,
            Id = Id,
            NowLevel = NowLevel,
            ThisUpgrateItemSprite = ThisUpgrateItemSprite,
        };
        return clone;
    }
    public UpgrateItem()
    {

    }
}
