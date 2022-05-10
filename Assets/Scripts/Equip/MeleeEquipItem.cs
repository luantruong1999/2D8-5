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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, i.Range, hitLayerMask);
        if (hit.collider != null)
        {
            IDamegeable damegeable = hit.collider.GetComponent<IDamegeable>();
            if (damegeable != null)
            {
                damegeable.TakenDame(i.Damege);
            }
        }
        //if we hit anything,dame it

    }
}
