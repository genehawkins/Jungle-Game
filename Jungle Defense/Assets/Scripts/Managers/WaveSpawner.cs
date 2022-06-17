using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    private int waveNum;
    [SerializeField] private float spawnCooldown = 0.2f;
    [SerializeField][NonReorderable] public Wave[] waves;
    private bool canStart;

    public int GetWaveNumber()
    {
        return waveNum;
    }

    private void Awake()
    {
        GameManager.SetupPhase.AddListener(SetupNextWave);
        GameManager.SetupPhase?.Invoke();
    }

    private void SetupNextWave()
    {
        canStart = true;
        ++waveNum;
        if (waveNum > waves.Length) GameManager.GameOver(true); // player beat the level
    }

    public void StartWave()
    {
        if (!canStart) return;
        canStart = false;
        GameManager.GamePhase?.Invoke();
        GameManager.inSetupPhase = false;
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        var waveHolder = new GameObject("Wave " + waveNum);
        var currentWave = waves[waveNum-1];
        
        // Count Number of enemies for Wave and add to Enemy Tracker
        foreach (var enemyType in currentWave.list)
        {
            GameManager.instance.enemyTracker.EnemiesSpawned(enemyType.numToSpawn);
        }
        
        // Spawn All Enemies
        foreach (var enemyType in currentWave.list)
        {
            for (var j = 0; j < enemyType.numToSpawn; ++j)
            {
                Instantiate(enemyType.prefab, spawnPoint.transform.position, Quaternion.identity, waveHolder.transform);
                yield return new WaitForSeconds(spawnCooldown);
            }
        }
    }
}

[System.Serializable] public class Wave
{
    [Space(5)][NonReorderable]
    public Enemy[] list;
}

[System.Serializable] public class Enemy
{
    public GameObject prefab;
    public int numToSpawn;
}