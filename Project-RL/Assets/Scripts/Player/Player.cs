using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    //Health var
    public float maxHealth = 100f;
    public float currentHealth;
    //----------
    //IFrame var
    private bool canTakeDamage = true;
    public float invisibleFrameTime = 1f;
    //----------

    private void Start()
    {
        currentHealth = maxHealth;//Set current healh to max health when spawn            
    }

    public void TakeDamage(float damage)//Take damage function
    {
        if (!canTakeDamage)//Check if can take damage if not return
            return;
        canTakeDamage = false;
        currentHealth -= damage;        
        Debug.Log(currentHealth);
        if(currentHealth <= 0)
        {                        
            //Die animation
            Destroy(gameObject);
        }
        StartCoroutine(InvisibleFrame(invisibleFrameTime));//Set timer for IFrame to deactivate
    }

    IEnumerator InvisibleFrame(float IFrameTime)//IFrame timer
    {        
        yield return new WaitForSeconds(IFrameTime);
        canTakeDamage = true;        
    }
}
