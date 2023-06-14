using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    public Transform spawnPoint;

    private float spawnRange = 9f;

    [SerializeField]private int enemyCount;
    public int waveNumber = 1;
    void Start()
    {
        SpawnEnemy(waveNumber);
        Instantiate(powerupPrefab, SpawnPosition(), powerupPrefab.transform.rotation);
    }

    
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemy(waveNumber);
            Instantiate(powerupPrefab, SpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
    void SpawnEnemy(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, SpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    private Vector3 SpawnPosition()
    {
        float spawnPosX = Random.Range(spawnRange, -spawnRange);
        float spawnPosZ = Random.Range(spawnRange, -spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }
}
