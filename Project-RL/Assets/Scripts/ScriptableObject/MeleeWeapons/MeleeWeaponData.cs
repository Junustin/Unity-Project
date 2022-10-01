using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Melee Weapon", menuName = "Weapon/Melee weapon")]
public class MeleeWeaponData : ScriptableObject
{
    public new string name;
    public float damage;
    public float attackSpeed;
}
