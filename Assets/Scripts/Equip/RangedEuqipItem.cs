using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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

        if (Inventory.Instance.HasItem(i.ProjectileData) == false)
        {
            return;
        }
        i.Fire(muzzle.position,muzzle.rotation,Character.Team.player );
        Inventory.Instance.RemoveItem(i.ProjectileData);
        AudioManager.Instance.PlayPlayerAudio(shootSFX);

        lastAttackTime = Time.time;
    }
}
