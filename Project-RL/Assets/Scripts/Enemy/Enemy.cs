using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamagable
{
    public float health;

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
        Destroy(gameObject);
    }
    
}
