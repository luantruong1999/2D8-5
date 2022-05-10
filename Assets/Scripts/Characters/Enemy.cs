using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class Enemy : Character
{
    public enum State
    {
        Idle,
        Chase,
        Attack
    }

    protected State curState;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float chaseDistance;
    [SerializeField] protected ItemsData[] dropItems;
    [SerializeField] protected GameObject dropPrefab;
    
    
     protected GameObject target;
     protected float targetDistance;
     protected float lastAttackTime;

     [Header(("Compoments"))] 
     [SerializeField] protected SpriteRenderer _spriteRenderer;
     

    private void Start()
    {
        target = FindObjectOfType<Player>().gameObject;
    }

    protected virtual void Update()
    {
        targetDistance = Vector2.Distance(target.transform.position, transform.position);
        _spriteRenderer.flipX = GetTargetDirection().x > 0;
        switch (curState)
        {
            case State.Idle : IdleUpdate();
                break;
            case State.Chase: ChaseUpdate();
                break;
            case State.Attack: AttackUpdate();
                break;
        }
    }

    void IdleUpdate()
    {
        if (targetDistance <= chaseDistance)
        {
            ChangeState(State.Chase);
        }
    }

    void ChaseUpdate()
    {
        if (InAttackRange())
        {
            ChangeState(State.Attack);
        }
        else
        {
            if (targetDistance>=chaseDistance)
            {
                ChangeState(State.Idle);
            }
        }
        transform.position =
            Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        
    }

    void AttackUpdate()
    {
        if (targetDistance > chaseDistance)
        {
            ChangeState(State.Idle);
        }
        else
        {
            if (!InAttackRange())
            {
                ChangeState(State.Chase);
            }
        }

        if (CanAttack())
        {
            lastAttackTime = Time.time;
            AttackTarget();
        }
    }

    protected virtual void AttackTarget()
    {
        
    }

    void ChangeState(State state)
    {
        curState = state;
    }

    protected virtual bool InAttackRange()
    {
        return false;
    }

    protected virtual bool CanAttack()
    {
        return false;
    }

    public override void Die()
    {
        DropIteam();
        Destroy(gameObject);
    }

    protected void DropIteam()
    {
        for (int i = 0; i < dropItems.Length; i++)
        {
            GameObject obj = Instantiate(dropPrefab, transform.position, quaternion.identity);
            obj.GetComponent<WorldItem>().SetItem(dropItems[i]);
            
        }
    }

    protected  Vector2 GetTargetDirection()
    {
        return (target.transform.position - transform.position).normalized;
    }
}
