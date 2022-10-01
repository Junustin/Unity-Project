using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] MeleeWeaponData meleeWeaponData;
    [SerializeField] Collider coll;
    private bool canAttack;

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

    IEnumerator AttackSpeed()
    {
        canAttack = false;
        yield return new WaitForSeconds(meleeWeaponData.attackSpeed);
        canAttack = true;
    }
}
