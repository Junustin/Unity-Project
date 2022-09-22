using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : Enemy
{
    NavMeshAgent navMeshAgent;
    Rigidbody rb;

    public override void Awake()
    {
        base.Awake();
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        navMeshAgent.destination = playerRef.transform.position;
        
    }

    public override void TakeDamage(float Damage)
    {
        base.TakeDamage(Damage);
    }

    public override void Attack()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerRef.TakeDamage(damage);
        }    
    }

    public override void Die()
    {
        base.Die();
    }
}
