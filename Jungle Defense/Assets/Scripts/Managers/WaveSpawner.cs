using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform spawnPoint;
    private int waveNum = 0;
    [SerializeField] private float spawnCooldown = 0.2f;

    public int GetWaveNumber()
    {
        return waveNum;
    }

    public static readonly UnityEvent WaveStart = new UnityEvent();
    public static readonly UnityEvent WaveEnd = new UnityEvent();

    private void Start()
    {
        WaveEnd.AddListener(SetupNextWave);
        SetupNextWave();
    }

    private int numEnemiesToSpawn;

    private void SetupNextWave()
    {
        ++waveNum;
        numEnemiesToSpawn = waveNum; // TODO: change from waveNum
        
        GameManager.instance.enemyTracker.SetNumEnemies(numEnemiesToSpawn);
        canStart = true;
    }

    private bool canStart = false;
    
    public void StartWave()
    {
        if (!canStart) return;
        canStart = false;
        
        WaveStart?.Invoke();
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        var waveHolder = new GameObject("Wave " + waveNum);
        for (int i = 0; i < numEnemiesToSpawn; ++i)
        {
            Instantiate(enemyPrefabs[0], spawnPoint.transform.position, Quaternion.identity, waveHolder.transform);
            yield return new WaitForSeconds(spawnCooldown);
        }
    }
}