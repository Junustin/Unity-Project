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

    private void FixedUpdate()
    {
        navMeshAgent.destination = playerRef.transform.position;//Move to player        
    }

    public override void TakeDamage(float Damage)
    {
        base.TakeDamage(Damage);        
        Vector3 knockBackDir = (transform.position - playerRef.transform.position).normalized;
        rb.AddForce(knockBackDir * 10, ForceMode.Impulse);
        StartCoroutine("KnockBackTimer", 0.1f);

        
    }
    IEnumerator KnockBackTimer(float time)
    {
        yield return new WaitForSeconds(time);
        rb.velocity = Vector3.zero;
    }

    public override void Die()
    {
        base.Die();
    }
}
