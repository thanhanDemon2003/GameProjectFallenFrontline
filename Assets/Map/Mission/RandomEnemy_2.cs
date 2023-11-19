using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemy_2 : MonoBehaviour
{
    public GameObject[] SpawmPoint;
    public GameObject enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            RandomEnemy();
        }
    }
    public void RandomEnemy()
    {
        int index = Random.Range(0, SpawmPoint.Length);
        Instantiate(enemyPrefabs, SpawmPoint[index].transform.position, Quaternion.identity);
    }
}
