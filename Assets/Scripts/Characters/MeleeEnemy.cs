using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private int damege;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackRate;

    protected override void AttackTarget()
    {
        IDamegeable damegeable = target.GetComponent<IDamegeable>();
        if (damegeable != null)
        {
            damegeable.TakenDame(damege);
        }
    }

    protected override bool CanAttack()
    {
        return Time.time - lastAttackTime>attackRate;
    }

    protected override bool InAttackRange()
    {
        return targetDistance <= attackRange;
    }
}
