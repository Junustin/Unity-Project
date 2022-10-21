using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningEffect : MonoBehaviour
{
    float timeBetweenTrigger = 0;
    [SerializeField] float maxTimeBetweenTrigger, minTimeBetweenTrigger;
    [SerializeField] Light lightSource;
    [SerializeField] float triggerTime;
    void Awake()
    {
        timeBetweenTrigger = Random.Range(minTimeBetweenTrigger, maxTimeBetweenTrigger);
    }

    private void Update()
    {
        timeBetweenTrigger -= Time.deltaTime;
        if(timeBetweenTrigger <=0)
        {
            StartCoroutine(TriggerEffect());
            timeBetweenTrigger = Random.Range(minTimeBetweenTrigger,maxTimeBetweenTrigger);
        }
    }
    IEnumerator TriggerEffect()
    {
        lightSource.enabled = true;
        yield return new WaitForSeconds(triggerTime);
        lightSource.enabled = false;
    }
}
