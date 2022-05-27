using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    //Spawn enemies 
    public Transform enemyPre;
    public Transform spawnPoint;

    [Tooltip("Time in between waves.")] public float waveTimer = 10f; // time in between each of the waves
    private float countDown = 3f;
    private int waveNum = 0;

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
             yield return new WaitForSeconds(0.5f);
         }
    }
}
