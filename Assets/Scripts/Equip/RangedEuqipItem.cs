using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEuqipItem : EquipItem
{
    [SerializeField] private Transform muzzle;
    [SerializeField] private AudioClip shootSFX;
    private float lastAttackTime;

    public override void OnUse()
    {
        RangeItemData i=item as RangeItemData;
        if (Time.time - lastAttackTime<i.FireRate)
        {
            return;
        }

        lastAttackTime = Time.time;
    }
}
