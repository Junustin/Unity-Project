using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;


public class Monster01 : Enemy, IDamagable
{
    [SerializeField] EnemyWeapon weapon;
    
    
    Animator animator;
    
    
    public override void Awake()
    {
        base.Awake();                        
        weapon = GetComponentInChildren<EnemyWeapon>();
        animator = GetComponent<Animator>();
    }

    public override void Start()
    {
        base.Start();
    }
    
    private void FixedUpdate()
    {
                                                                
    }

    public override void TakeDamage(float Damage)
    {
        base.TakeDamage(Damage);
        CameraShake.Instance.ShakeCam(1f, .1f);
    }
    

    private void Update()
    {
        CheckIfPlayerInAttackRange();
        if(rb.velocity != Vector3.zero)
        {
            
            animator.SetBool("IsRunning", true);
        }
        else
        {
            
            animator.SetBool("IsRunning", false);
        }
        
    }

    public override void MoveToPlayer()
    {
        base.MoveToPlayer();
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
        CameraShake.Instance.ShakeCam(5f, .1f);
    }
}
