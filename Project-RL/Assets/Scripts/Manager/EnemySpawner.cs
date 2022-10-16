using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] BoxCollider boxTrigger;
    [SerializeField] Transform[] spawnPoint;

    [SerializeField] GameObject batonEnemyPrefab;

    [SerializeField] float batonEnemyInterval;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(SpawnEnemy(batonEnemyPrefab, batonEnemyInterval));
        Destroy(boxTrigger);
    }

    IEnumerator SpawnEnemy(GameObject enemy,float interval)
    {
        yield return new WaitForSeconds(interval);
        Instantiate(enemy, spawnPoint[Random.Range(0, spawnPoint.Length)].position, Quaternion.identity);
        StartCoroutine(SpawnEnemy(enemy, interval));
    }


}
