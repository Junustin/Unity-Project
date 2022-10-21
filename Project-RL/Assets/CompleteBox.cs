using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.ReloadCurrentScene();
        }
    }
}
