using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;
    //Player bonus stats in gameplay
    public float bonusDamage = 0;
    public float bonusMoveSpeed = 0;
    public float bonusProjectileSize = 1;
    public float bonusProjectileSpeed = 1;
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
    }
}
