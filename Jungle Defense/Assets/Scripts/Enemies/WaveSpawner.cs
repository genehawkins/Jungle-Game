using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    //Spawn enemies 
    public Transform enemyPre;
    public Transform spawnPoint;

    [Tooltip("Time in between waves.")][SerializeField]
    private float waveTimer = 10f; // time in between each of the waves
    [Tooltip("Time in between individual enemies spawning.")] [SerializeField]
    private float enemySpawnTime = 0.5f;
    
    private float countDown = 3f;
    [NonSerialized] public int waveNum = 0;

    private void Update()
    {
        if (countDown <= 0f)
        {
            waveNum++;
            Debug.Log($"Spawning wave #: {waveNum}");
            StartCoroutine(SpawnWave());
            countDown = waveTimer;
        }

        countDown -= Time.deltaTime;
    }

    private IEnumerator SpawnWave(){
         // TODO: Adjust code below later for different enemies and all that
         
         var waveGO = new GameObject($"Wave {waveNum}"); // parent gameobject to hold that wave of enemies
         
         for(int i = 0; i < waveNum; i++)
         {
             // Instantiate new enemy at spawnpoint with parent of waveGO.transform
             Instantiate(enemyPre, spawnPoint.position, spawnPoint.rotation, waveGO.transform);
             yield return new WaitForSeconds(enemySpawnTime);
         }
    }
}
