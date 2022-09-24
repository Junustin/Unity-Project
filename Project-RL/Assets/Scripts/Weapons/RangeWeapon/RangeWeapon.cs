using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : MonoBehaviour
{
    [SerializeField] RangeWeaponData rangeWeaponData;
    [SerializeField] GameObject firePoint;
    private bool canShoot=true;    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&&canShoot)
        {
            Shoot();
            StartCoroutine("FireRate");
        }
    }
    public void Shoot()
    {        
        Instantiate(rangeWeaponData.projectile, firePoint.transform.position, firePoint.transform.rotation);                        
    }

    IEnumerator FireRate()
    {
        canShoot = false;
        yield return new WaitForSeconds(rangeWeaponData.fireRate);
        canShoot = true;
    }
}
