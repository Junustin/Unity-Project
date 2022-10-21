using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;


//Class of all enemy 
public class Enemy : MonoBehaviour,IDamagable
{
    public float health,damage,contactDamageKnockBackAmount,knockBackWhenHitAmount;
    public Player playerRef;
    public Rigidbody rb;
    public NavMeshAgent navMeshAgent;
    public VisualEffect spawnEffect;
    public VisualEffect deatheffect;

    public float attackRange;
    public LayerMask playerMask;
    public bool playerInAttackRange;
    public bool canAttack = true;



    public virtual void Awake()
    {
        playerRef = FindObjectOfType<Player>();//Get player ref
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();        
    }

    public virtual void Start()
    {
        Instantiate(spawnEffect, transform.position, transform.rotation);
    }

    public virtual void TakeDamage(float Damage)
    {
        health -= Damage;
        KnockBackOnHit();
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void KnockBackOnHit()
    {
        Vector3 knockBackDir = (transform.position - playerRef.transform.position).normalized;
        rb.AddForce(knockBackDir * knockBackWhenHitAmount, ForceMode.Impulse);
        StartCoroutine("KnockBackTimer", 0.1f);
    }

    IEnumerator KnockBackTimer(float time)
    {
        yield return new WaitForSeconds(time);
        rb.velocity = Vector3.zero;
    }

    public virtual void CheckIfPlayerInAttackRange()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if (playerInAttackRange && canAttack)
        {
            Attack();
        }
        else if (!playerInAttackRange)
        {
            MoveToPlayer();
        }
    }

    public virtual void MoveToPlayer()
    {
        navMeshAgent.SetDestination(playerRef.transform.position);
    }

    public virtual void Attack()
    {

    }
    public virtual void Die()
    {
        Instantiate(deatheffect,transform.position,transform.rotation);     
        Destroy(gameObject);
    }
   
}
