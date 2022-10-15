using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Monster01 : Enemy, IDamagable
{
    NavMeshAgent navMeshAgent;
    Rigidbody rb;
    [SerializeField] EnemyWeapon weapon;
    [SerializeField] bool playerInAttackRange;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask playerMask;
    Animator animator;
    bool canAttack = true;
    

    public override void Awake()
    {
        base.Awake();
        navMeshAgent=GetComponent<NavMeshAgent>();
        rb=GetComponent<Rigidbody>(); 
        weapon=GetComponentInChildren<EnemyWeapon>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
                                                                
    }

    public override void TakeDamage(float Damage)
    {
        base.TakeDamage(Damage);
        CameraShake.Instance.ShakeCam(2f, .1f);
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

        if (playerInAttackRange&&canAttack)
        {
            Attack();
        }
        else if (!playerInAttackRange)
        {
            MoveToPlayer();
        }

        if(rb.velocity != Vector3.zero)
        {
            
            animator.SetBool("IsRunning", true);
        }
        else
        {
            
            animator.SetBool("IsRunning", false);
        }
    }

    private void MoveToPlayer()
    {
        navMeshAgent.SetDestination(playerRef.transform.position);
    }

    public override void Attack()
    {
        canAttack = false;
        navMeshAgent.SetDestination(transform.position); 
        transform.LookAt(playerRef.transform);
        animator.SetTrigger("Attack");
        StartCoroutine(AttackSpeed());     
    }

    IEnumerator AttackSpeed()
    {        
        yield return new WaitForSeconds(weapon.meleeWeaponData.attackSpeed);
        canAttack = true;
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
