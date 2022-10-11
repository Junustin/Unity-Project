using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] MeleeWeaponData meleeWeaponData;
    [SerializeField] BoxCollider coll;
    private Player player;
    private bool canAttack = true;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void Update()
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
        if (other.gameObject.tag == "Player")
        {          
            player.TakeDamage(meleeWeaponData.damage);
            player.KnockBackOnHit(this.transform, 100f);
        }
    }
}
