using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject oneZombiePrefab;
    [SerializeField]
    private GameObject threeZombiePrefab;

    [SerializeField]
    private float spawnerIntervalOne = 3.5f;

    [SerializeField]
    private float spawnerIntervalThree = 10f;

    void Start()
    {
        StartCoroutine(spawnEnemy(spawnerIntervalOne, oneZombiePrefab));
        StartCoroutine(spawnEnemy(spawnerIntervalThree, threeZombiePrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}