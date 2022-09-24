using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] RangeWeaponData pairWeaponData;
    
    private void Start()
    {
        //GetComponent
        rb = GetComponent<Rigidbody>();
        //------------
        rb.AddForce(transform.forward * 20 ,ForceMode.VelocityChange);//Add force        
        Destroy(gameObject, 10);//Auto destroy after spawn for 10 sec
    }
    private void OnTriggerEnter(Collider other)
    {        
        IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            Debug.Log("Deal damage");
            damagable.TakeDamage(pairWeaponData.damage);
        }
        if (other.gameObject.tag != "Player") 
        {
            Destroy(gameObject);
        }
    }
    

}
