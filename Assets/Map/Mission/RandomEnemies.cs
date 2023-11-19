using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int initialEnemyCount = 5;
    public int maxEnemies = 8; 
    public Transform[] spawnPoints;

    private void Start()
    {
        InitializeEnemies();
    }

    void InitializeEnemies()
    {
        for (int i = 0; i < initialEnemyCount; i++)
        {
            Transform spawnPoint = GetRandomSpawnPoint();
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            Transform spawnPoint = GetRandomSpawnPoint();
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}
