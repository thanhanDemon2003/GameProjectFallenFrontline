using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour {
    GameObject[] spawnPoint;
    public GameObject zombie;
    public float minSpawnTime = 3f;
    public float maxSpawnTime = 7f;
    private float lastSpawnTime = 0;
    private float spawnTime = 0;
    // Use this for initialization
    void Start()
    {
        UpdateSpawnTime();
    }

    void UpdateSpawnTime()
    {
        spawnPoint = GameObject.FindGameObjectsWithTag("Respawn");
        lastSpawnTime = Time.time;
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Spawn()
    {
        int point = Random.Range(0, spawnPoint.Length);
        Instantiate(zombie, spawnPoint[point].transform.position, Quaternion.identity);
        UpdateSpawnTime();
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastSpawnTime + spawnTime)
        {
            Spawn();
        }
    }
}
