using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Powerup",menuName = "Powerup")]
public class Powerups : ScriptableObject
{
    [SerializeField] float damageToAdd;
    [SerializeField] float moveSpeedToAdd;
    [SerializeField] float maxHealthToAdd;
    
    public void onClick()
    {
        LevelManager.instance.bonusMoveSpeed += moveSpeedToAdd;
        LevelManager.instance.bonusDamage += damageToAdd;
        LevelManager.instance.playerRef.maxHealth += maxHealthToAdd;
    }
}
