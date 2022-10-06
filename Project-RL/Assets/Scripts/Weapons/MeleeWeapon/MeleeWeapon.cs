using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] MeleeWeaponData meleeWeaponData;
    [SerializeField] BoxCollider coll;
    private PlayerController player;
    private bool canAttack = true;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&&canAttack)
        {
            Attack();
            StartCoroutine("AttackSpeed");
        }
    }

    private void Attack()
    {        
        
    }

    public void StartAttack()
    {         
         coll.enabled = true;
    }

    public void AttackEnded()
    {
        coll.enabled = false;
    }



    IEnumerator AttackSpeed()
    {
        canAttack = false;
        yield return new WaitForSeconds(meleeWeaponData.attackSpeed);
        canAttack = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {            
            damagable.TakeDamage(meleeWeaponData.damage);
        }
    }
}
