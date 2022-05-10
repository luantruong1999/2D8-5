using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : MonoBehaviour
{
    [SerializeField] private int dame;
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;

    private Character.Team team;
    private Rigidbody2D rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject,lifeTime);
    }

    private void FixedUpdate()
    {
        rig.velocity = transform.up * speed;
    }

    public void SetTeam(Character.Team t)
    {
        team = t;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        IDamegeable damegeable = col.gameObject.GetComponent<IDamegeable>();
        if (damegeable != null && damegeable.GetTeam()!=team)
        {
            damegeable.TakenDame(dame);
            Destroy(gameObject);
        }
    }
    
}
