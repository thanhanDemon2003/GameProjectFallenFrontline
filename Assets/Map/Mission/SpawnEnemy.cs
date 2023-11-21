using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public GameObject player;
    public Transform[] spawnPoints;
    public int radius;
    public int maxEnemies;

    void Update()
    {
        SpawnEnemyInPoint();
    }

    public void SpawnEnemyInPoint()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < radius)
            {
                if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
                {
                    Transform spawnPoint = GetRandomSpawnPoint();
                    Instantiate(enemyPrefabs, spawnPoint.position, spawnPoint.rotation);
                  
                }
            }
        }
    }

    Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
    
}
