using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public MeleeWeaponData meleeWeaponData;
    [SerializeField] BoxCollider coll;
    private Player player;
    

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {          
            player.TakeDamage(meleeWeaponData.damage,this.transform,meleeWeaponData.knockBackForce);            
        }
    }
}
