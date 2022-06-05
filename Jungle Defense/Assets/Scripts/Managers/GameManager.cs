using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public WaveSpawner waveSpawner;
    public BaseHealth baseHealth;
    public EnemyTracker enemyTracker;
    
    private void Awake()
    {
        instance = this;
    }
}
