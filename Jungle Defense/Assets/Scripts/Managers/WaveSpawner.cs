using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    private int waveNum = 0;
    public Transform spawnPoint;

    public int GetWaveNumber()
    {
        return waveNum;
    }
}
