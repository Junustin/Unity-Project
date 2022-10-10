using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : Enemy,IDamagable
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
        Debug.Log(health);
        
        Vector3 knockBackDir = (transform.position - playerRef.transform.position).normalized;
        rb.AddForce( knockBackDir * 10,ForceMode.Impulse);
        StartCoroutine("KnockBackTimer",0.1f);
        
        //Slime take damage animation
    }

    IEnumerator KnockBackTimer(float time)
    {
        yield return new WaitForSeconds(time);
        rb.velocity = Vector3.zero;
    }
    public override void Attack()
    {
        //No attack
    }

    private void OnCollisionEnter(Collision collision)
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerRef.TakeDamage(damage);
            playerRef.KnockBackOnHit(this.transform,knockBackAmount);
        }
        //Slime Hit effect                
    }

    public override void Die()
    {
        
        base.Die();
        //Slime death animation
    }
}
