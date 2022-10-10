using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Class of all enemy 
public class Enemy : MonoBehaviour,IDamagable
{
    public float health,damage,knockBackAmount;
    public Player playerRef;
    public GameObject deadParticle;

    
    public virtual void Awake()
    {
        playerRef = FindObjectOfType<Player>();//Get player ref
    }

    public virtual void TakeDamage(float Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Attack()
    {

    }
    public virtual void Die()
    {
        
        Instantiate(deadParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
   
}
