using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;


//Class of all enemy 
public class Enemy : MonoBehaviour,IDamagable
{
    public float health,damage,knockBackAmount;
    public Player playerRef;
    public VisualEffect spawnEffect;
    public VisualEffect deatheffect;
    

    
    public virtual void Awake()
    {
        playerRef = FindObjectOfType<Player>();//Get player ref
        Instantiate(spawnEffect, transform.position, transform.rotation);
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
        Instantiate(deatheffect,transform.position,transform.rotation);     
        Destroy(gameObject);
    }
   
}
