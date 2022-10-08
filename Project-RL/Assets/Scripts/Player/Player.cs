using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Health var
    public float maxHealth = 100f;
    public float currentHealth;
    //----------
    public float armor = 0f;
    //IFrame var
    private bool canTakeDamage = true;
    public float invisibleFrameTime = 1f;
    //----------
    [SerializeField] Transform weaponSocket;
    //Testing
    public GameObject weapon;
    private MeleeWeapon meleeWeapon;
    //-------

    private void Awake()
    {
        EquipWeapon(weapon);
        meleeWeapon = GetComponentInChildren<MeleeWeapon>();
    }
    private void Start()
    {
        currentHealth = maxHealth;//Set current healh to max health when spawn            
        
    }

    public void TakeDamage(float damage)//Take damage function
    {
        damage -= armor;
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

    public void EquipWeapon(GameObject _weapon)
    {
        Instantiate(_weapon, weaponSocket.position,weaponSocket.rotation,weaponSocket);
    }

    public void Heal(float _healAmount)//Call when heal
    {
        if(currentHealth < maxHealth)
            currentHealth += _healAmount;
        if(currentHealth >maxHealth)
            currentHealth = maxHealth;
    }

    public void EnableAttackHitbox()
    {
        meleeWeapon.StartAttack();
    }

    public void DisableAttackHitbox()
    {
        meleeWeapon.AttackEnded();
    }
}
