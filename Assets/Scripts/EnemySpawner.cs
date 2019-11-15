using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public float secondsBetweenSpawns = 3f;
    [SerializeField] Transform parent;
    [SerializeField] EnemyMovement enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWait()
    {
        while (true)
        {
            print("Spawning...");
            yield return new WaitForSeconds(secondsBetweenSpawns);
            yield return StartCoroutine(SpawnEnemy());
        }
        
    }

    IEnumerator SpawnEnemy()
    {
        GameObject spawnedEnemy = Instantiate(enemy.gameObject, transform.position, Quaternion.identity);
        spawnedEnemy.transform.parent = parent;
        yield return null;
    }
}
