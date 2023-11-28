using System.Collections;
using UnityEngine;

public class RandomEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 2;
    public Transform[] spawnPoints;


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