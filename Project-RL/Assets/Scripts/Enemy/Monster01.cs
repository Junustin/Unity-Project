using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Monster01 : Enemy,IDamagable
{
    NavMeshAgent navMeshAgent;
    Rigidbody rb;
    EnemyWeapon weapon;
    [SerializeField] bool playerInAttackRange;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask playerMask;

    public override void Awake()
    {
        base.Awake();
        navMeshAgent=GetComponent<NavMeshAgent>();
        rb=GetComponent<Rigidbody>();
        weapon = GetComponentInChildren<EnemyWeapon>();
    }

    private void FixedUpdate()
    {
        navMeshAgent.destination = playerRef.transform.position;                                                        
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

    private void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);
        if (playerInAttackRange) Attack();
    }

    public override void Attack()
    {
        base.Attack();
        navMeshAgent.SetDestination(transform.position);
        transform.LookAt(playerRef.transform);
        //Set anim
    }
    //Event will call on attack animation play
    public void EnableAttackHitbox()
    {
        weapon.StartAttack();
    }
    
    public void DisableAttackHitbox()
    {
        weapon.AttackEnded();
    }
    //----------------------------------------
    public override void Die()
    {
        base.Die();
    }
}
