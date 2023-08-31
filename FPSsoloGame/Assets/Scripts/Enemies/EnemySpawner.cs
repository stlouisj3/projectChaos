using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool hasEntered = false;

    [SerializeField]
    private int enemiesToSpawn;

    [SerializeField]
    private int initalEnemies;

    [SerializeField]
    private List<Transform> spawnPoints;

    [SerializeField]
    private GameObject door;

    private int pointToSpawn;
    private int maxPoints;

    private ObjectPool pool;

    private void Start()
    {
        maxPoints = spawnPoints.Count;
        pool = ObjectPool.Instance;
        hasEntered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasEntered)
        {
            Debug.Log("Start It");
            StartCoroutine(spawnEnemies());
            hasEntered = true;

        }
           
    }

    IEnumerator spawnEnemies()
    {
        for(int i = 0; i < initalEnemies; i++)
        {
            //pointToSpawn = Random.Range(0, maxPoints);
            pool.SpawnFromPool("Enemy", spawnPoints[i].position, Quaternion.identity);

        }

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            pointToSpawn = Random.Range(0, maxPoints);
            pool.SpawnFromPool("Enemy", spawnPoints[pointToSpawn].position, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }

        door.SetActive(false);

    }

}
