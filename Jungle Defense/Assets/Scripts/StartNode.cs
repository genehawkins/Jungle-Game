using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : MonoBehaviour
{
    private void Start()
    {
        WaveSpawner.instance.spawnPoint = transform;
    }
}
