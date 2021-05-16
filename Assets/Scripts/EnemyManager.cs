using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zone.Core.Utils;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float timeBtwSpawn = 5f;
    [SerializeField] private float spawnRange = 10f;
    [SerializeField] private int planetMax = 10;

    private Timer timer;
    private Vector3 playerPos;

    public int planetCount { get; set; }

    private void Start() 
    {
        timer = new Timer(timeBtwSpawn);
        timer.OnTimerEnd += Spawn;

        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        planetCount = 0;
    }

    private void FixedUpdate() 
    {
        timer.Tick(Time.deltaTime);
    }

    private void Spawn()
    {
        Vector3 spawnPos;
        do
        {
            spawnPos = playerPos + Random.insideUnitSphere * spawnRange;
            
        } 
        while (Vector3.Distance(playerPos, spawnPos) < 5f);
        spawnPos.y = 0f;

        GameObject chosenEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        if (planetCount <= planetMax)
        {
            Instantiate(chosenEnemy, spawnPos, Quaternion.identity);
            planetCount++;
        }
        timer.Reset();
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(playerPos, spawnRange);    
    }
}
