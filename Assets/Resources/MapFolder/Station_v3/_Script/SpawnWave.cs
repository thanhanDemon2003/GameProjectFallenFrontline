using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public GameObject[] enemies;
    public bool isInWaves;
    public bool isNearEnd;

    private Transform player;

    [Header("Properties")]
    [SerializeField] Transform[] spawnPoint;
    [SerializeField] GameObject[] normalZombie;
    [SerializeField] GameObject[] specialZombie;

    [Header("Attribute")]
    public float timeBetweenSpawn = 7f;
    public float count;
    public int enemyIndex;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        count = timeBetweenSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCountDown();
    }

    private void SpawnCountDown()
    {
        enemies = GameObject.FindGameObjectsWithTag("Zombie");
        enemyIndex = enemies.Length;

        if (enemies.Length < 7)
        {
            count -= Time.deltaTime;
        }

        if (count < 0)
        {
            count = timeBetweenSpawn;
            SpawnZombie();
        }
    }

    private void SpawnZombie()
    {
        Instantiate(RandomNorZombie(), RandomSpawnPoint().position, Quaternion.identity);
    }


    private Transform RandomSpawnPoint()
    {
        float FurthestDistance = 0;
        Transform FurthestPoint = null;

        foreach (Transform point in spawnPoint)
        {
            float ObjectDistance = Vector3.Distance(player.position, point.position);

            if (ObjectDistance > FurthestDistance)
            {
                FurthestPoint = point;
                FurthestDistance = ObjectDistance;
            }
        }
        Debug.DrawLine(player.position,FurthestPoint.position, Color.red);
        return FurthestPoint;
    }

    private GameObject RandomNorZombie()
    {
        return normalZombie[Random.Range(0, normalZombie.Length)];
    }

}
