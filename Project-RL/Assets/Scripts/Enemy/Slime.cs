using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    private void Start()
    {
        health = 20f;
    }

    public override void TakeDamage(float Damage)
    {
        base.TakeDamage(Damage);
    }

    public override void Attack()
    {
        
    }

    public override void Die()
    {
        base.Die();
    }
}
