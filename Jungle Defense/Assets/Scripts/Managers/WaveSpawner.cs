using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    private int waveNum;
    [SerializeField] private float spawnCooldown = 0.2f;
    [SerializeField][NonReorderable] public Wave[] waves;
    private bool canStart;
    public AudioManager audioManager;

    public int GetWaveNumber()
    {
        return waveNum;
    }

    private void Awake()
    {
        GameManager.SetupPhase.AddListener(SetupNextWave);
        GameManager.SetupPhase?.Invoke();
    }

    private int numEnemiesToSpawn;

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
        if (audioManager) audioManager.Play("StartWave");
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        var waveHolder = new GameObject("Wave " + waveNum);
        var currentWave = waves[waveNum-1];
        for (var i = 0; i < currentWave.list.Length; ++i)
        {
            for (var j = 0; j < currentWave.list[i].numToSpawn; ++j)
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
    public Enemy[] list;
}

[System.Serializable] public class Enemy
{
    public GameObject prefab;
    public int numToSpawn;
}