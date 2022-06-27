using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    private int enemiesAlive = 0;

    public void EnemyDestroyed()
    {
        enemiesAlive--;
        if (enemiesAlive == 0 && !GameManager.instance.inSetupPhase)
        {
            GameManager.instance.SetupPhase?.Invoke();
        }
    }

    public void EnemiesSpawned(int num)
    {
        enemiesAlive += num;
    }

    public int GetNumEnemies()
    {
        return enemiesAlive;
    }
}
