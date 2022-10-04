using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Player playerRef;
    public static LevelManager instance = null;
    //Player bonus stats in gameplay
    public float bonusDamage = 0;
    public float bonusMoveSpeed = 0;
    public float bonusProjectileSize = 1;
    public float bonusProjectileSpeed = 1;
    public float bonusArmor = 0;
    public float bonusMaxHealth = 0;
    //------------------------------
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        playerRef = FindObjectOfType<Player>();
    }
}
