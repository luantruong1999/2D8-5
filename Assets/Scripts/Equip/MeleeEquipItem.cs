using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEquipItem : EquipItem
{
    [SerializeField] private LayerMask hitLayerMask;
    [SerializeField] private Animator animator;
    private float lastAttackTime;
    [SerializeField] private AudioClip swingSFX;

    public override void OnUse()
    {
        MeleeItemData i=item as MeleeItemData;
        if (Time.time - lastAttackTime<i.AttackRate)
        {
            return;
        }

        lastAttackTime = Time.time;
        
        animator.SetTrigger("Attack");
        //shot raycast
        //if we hit anything,dame it
        
    }
}
