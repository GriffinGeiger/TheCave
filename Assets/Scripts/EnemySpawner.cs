using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    public float ySpawnLowBound;
    [SerializeField]
    public  float ySpawnHighBound;
    [SerializeField]
    public  float xSpawnRange;
    [SerializeField]
    public  GameObject enemyPrefab;
    [SerializeField]
    public GameObject player;
    public float spawnPeriod = 10f;
    static System.Random rand = new System.Random();
    void Awake()
    {
        StartCoroutine("SpawnPeriodically");
    }
    public void SpawnEnemy(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            float xSpawnLowBound = player.transform.position.x - xSpawnRange;
            float xSpawnHighBound = player.transform.position.x + xSpawnRange;
            float ySpawn = ySpawnLowBound + (float)(rand.NextDouble() * (ySpawnHighBound - ySpawnLowBound));
            float xSpawn = xSpawnLowBound + (float)(rand.NextDouble() * (xSpawnHighBound - xSpawnLowBound));
            GameObject.Instantiate(enemyPrefab, new Vector3(xSpawn, ySpawn, 0.4132823f), Quaternion.identity);
        }
    }

    IEnumerator SpawnPeriodically()
    {
        for(;;)
        {
            SpawnEnemy(1);
            yield return new WaitForSeconds(spawnPeriod);
        }
    }
}
