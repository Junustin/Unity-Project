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
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        EquipWeapon(weapon);
        meleeWeapon = GetComponentInChildren<MeleeWeapon>();
    }
    private void Start()
    {
        currentHealth = maxHealth;//Set current healh to max health when spawn            
        
    }
    private void OnDestroy()
    {
        GameManager.instance.ReloadCurrentScene();
    }

    public void TakeDamage(float damage,Transform enemyTransform,float knockBackForce)//Take damage function
    {
        damage -= armor;
        if (!canTakeDamage)//Check if can take damage if not return
            return;
        canTakeDamage = false;
        currentHealth -= damage;
        CameraShake.Instance.ShakeCam(5f,.1f);
        Debug.Log(currentHealth);
        if(currentHealth <= 0)
        {                        
            //Die animation
            Destroy(gameObject);
        }
        KnockBackOnHit(enemyTransform, knockBackForce);
        StartCoroutine(InvisibleFrame(invisibleFrameTime));//Set timer for IFrame to deactivate
        //KnockBack
    }

    IEnumerator InvisibleFrame(float IFrameTime)//IFrame timer
    {        
        yield return new WaitForSeconds(IFrameTime);
        canTakeDamage = true;        
    }


    public void KnockBackOnHit(Transform enemyTransfrom,float knockBackForce)
    {
        Vector3 hitDir = (transform.position - enemyTransfrom.position).normalized;
        hitDir.y = 0;
        rb.AddForce(hitDir * knockBackForce, ForceMode.Impulse);
        StartCoroutine("KnockBackTimer",1f);
    }
    IEnumerator KnockBackTimer(float time)
    {
        yield return new WaitForSeconds(time);
        rb.velocity = Vector3.zero;
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
