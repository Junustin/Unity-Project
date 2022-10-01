using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;
    public float money;

    private void Awake()
    {
        instance = this;
    }
}
