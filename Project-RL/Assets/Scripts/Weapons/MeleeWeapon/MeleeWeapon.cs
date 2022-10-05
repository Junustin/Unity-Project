using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] MeleeWeaponData meleeWeaponData;
    [SerializeField] GameObject coll;
    private bool canAttack;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&&canAttack)
        {
            StartAttack();
            StartCoroutine("AttackSpeed");
        }
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
