using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    Rigidbody rb;
    public override void Awake()
    {
        base.Awake();    
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public override void TakeDamage(float Damage)
    {
        base.TakeDamage(Damage);
    }

    public override void Attack()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerRef.TakeDamage(damage);
        }    
    }

    public override void Die()
    {
        base.Die();
    }
}
