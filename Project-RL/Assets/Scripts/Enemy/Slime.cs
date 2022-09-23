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
        //Get component
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        //-------------
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        navMeshAgent.destination = playerRef.transform.position;//Move to player
        
    }

    public override void TakeDamage(float Damage)
    {
        base.TakeDamage(Damage);
        //Slime take damage animation
    }

    public override void Attack()
    {
        //No attack
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerRef.TakeDamage(damage);
        }
        //Slime Hit effect
    }

    public override void Die()
    {
        base.Die();
        //Slime death animation
    }
}
