using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    private int enemiesAlive = 0;

    public void EnemyDestroyed()
    {
        enemiesAlive--;
        if (enemiesAlive == 0) WaveSpawner.WaveEnd?.Invoke();
    }

    public void EnemySpawned()
    {
        enemiesAlive++;
    }

    public int GetNumEnemies()
    {
        return enemiesAlive;
    }
}
