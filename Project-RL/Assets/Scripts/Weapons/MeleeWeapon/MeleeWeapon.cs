using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] MeleeWeaponData meleeWeaponData;
    [SerializeField] GameObject coll;
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
        player.animator.SetTrigger("SickleAttack_1");
    }

    public void StartAttack()
    {         
         coll.SetActive(true);
    }

    public void AttackEnded()
    {
        coll.SetActive(false);
    }

    IEnumerator AttackSpeed()
    {
        canAttack = false;
        yield return new WaitForSeconds(meleeWeaponData.attackSpeed);
        canAttack = true;
    }
}
