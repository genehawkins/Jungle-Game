using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSpawner : MonoBehaviour
{
    public GameManager gm;
    public Transform spawnPoint;
    private int waveNum = 0;
    [SerializeField] private float spawnCooldown = 0.2f;
    [SerializeField][NonReorderable] public List<Wave> waves;

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
        canStart = true;
    }

    private bool canStart = false;
    
    public void StartWave()
    {
        if (!canStart) return;
        canStart = false;
        gm.setupPhase = false;
        
        WaveStart?.Invoke();
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        var waveHolder = new GameObject("Wave " + waveNum);
        var currentWave = waves[waveNum-1];
        for (var i = 0; i < currentWave.list.Count; ++i)
        {
            for (int j = 0; j < currentWave.list[i].numToSpawn; ++j)
            {
                GameManager.instance.enemyTracker.EnemySpawned();
                Instantiate(currentWave.list[i].prefab, spawnPoint.transform.position, Quaternion.identity, waveHolder.transform);
                yield return new WaitForSeconds(spawnCooldown);
            }
        }
        /*for (int i = 0; i < numEnemiesToSpawn; ++i)
        {
            Instantiate(new GameObject(), spawnPoint.transform.position, Quaternion.identity, waveHolder.transform);
            yield return new WaitForSeconds(spawnCooldown);
        }*/
    }
}

[System.Serializable] public class Wave
{
    [Space(5)][NonReorderable]
    public List<Enemy> list;
}

[System.Serializable] public class Enemy
{
    public GameObject prefab;
    public int numToSpawn;
}