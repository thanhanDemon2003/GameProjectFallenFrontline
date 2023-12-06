using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDocCase : MonoBehaviour
{
    public GameObject docCasePrefab; 
    public GameObject[] spawnPoints; 
    public int numberOfDocCasesToSpawn = 5;

    void Start()
    {
        RandomCase(spawnPoints);
        SpawnDocCase();
    }

    void SpawnDocCase()
    {
   
        int numDocCases = Mathf.Min(numberOfDocCasesToSpawn, spawnPoints.Length);

        for (int i = 0; i < numDocCases; i++)
        {
            GameObject spawnPoint = spawnPoints[i];
            Instantiate(docCasePrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }

    void RandomCase(GameObject[] array)
    {
        int n = array.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
