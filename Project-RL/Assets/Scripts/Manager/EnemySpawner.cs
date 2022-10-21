using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] BoxCollider boxTrigger;
    [SerializeField] Transform[] spawnPoint;

    [SerializeField] GameObject batonEnemyPrefab;

    [SerializeField] float batonEnemyInterval;
    [SerializeField] int numberToSpawn;
    int currentSpawned;

    [SerializeField] GameObject wall01;
    [SerializeField] GameObject wall02;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            wall01.SetActive(true);
            wall02.SetActive(true);
            StartCoroutine(SpawnEnemy(batonEnemyPrefab, batonEnemyInterval));
            Destroy(boxTrigger);
        }
    }

    IEnumerator SpawnEnemy(GameObject enemy,float interval)
    {
        if(currentSpawned < numberToSpawn)
        {
            yield return new WaitForSeconds(interval);            
            Instantiate(enemy, spawnPoint[Random.Range(0, spawnPoint.Length)].position, Quaternion.identity);
            currentSpawned++;
            StartCoroutine(SpawnEnemy(enemy, interval));
        }
        else
        {
            StopAllCoroutines();
            wall01.SetActive(false);
            wall02.SetActive(false);
        }
    }


}
