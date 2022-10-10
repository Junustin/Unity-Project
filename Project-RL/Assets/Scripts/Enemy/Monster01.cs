using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Monster01 : Enemy,IDamagable
{
    NavMeshAgent navMeshAgent;
    Rigidbody rb;

    public override void Awake()
    {
        base.Awake();
        navMeshAgent=GetComponent<NavMeshAgent>();
        rb=GetComponent<Rigidbody>();
    }
}
