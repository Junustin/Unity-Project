using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Range Weapon", menuName = "Weapon/Range weapon")]
public class RangeWeaponData : ScriptableObject
{
    public new string name;
    public float damage;
    public float fireRate;
    public GameObject projectile;
    
}
