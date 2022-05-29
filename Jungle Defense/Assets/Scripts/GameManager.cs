using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float score = 0f;
    public float health = 20f;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        instance = this;
    }

    public void AddToScore(float amount)
    {
        score += amount;
    }

    public void EnemyReachedEnd()
    {
        health--;
    }
}
