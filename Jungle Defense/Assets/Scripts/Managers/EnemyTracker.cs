using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    private int enemiesAlive = 0;
    public GameManager gm;
    public GameObject cardManager;

    public void EnemyDestroyed()
    {
        enemiesAlive--;
        if (enemiesAlive == 0) {
            WaveSpawner.WaveEnd?.Invoke();
            gm.setupPhase = true;
            cardManager.GetComponent<CardSystem>().DrawNewHand();
        }
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
