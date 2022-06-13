using System;
using System.Collections;
using UnityEngine;

public class VineWall : MonoBehaviour
{
    [Header("Attributes")]
    public float slowRate = 2;
    public float timeToRegen = 2;

    [Header("Unity Setup")]
    public GameObject[] vines;
    
    private int numUses;
    private bool canReset;
    private float timer;

    private void Awake()
    {
        numUses = vines.Length;
        GameManager.SetupPhase.AddListener(ResetVines);
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        SlowEnemy(c2d);
    }

    // Slows the move speed of an Enemy
    private void SlowEnemy(Collider2D enemy)
    {
        // Do not slow if target is not an enemy or there are no more uses.
        if (!enemy.CompareTag("Enemy") || numUses <= 0) return;
        
        // Slow the enemy
        enemy.GetComponent<EnemyMovement>().speed /= slowRate;
        
        // Removes vine graphics as trap is used up
        var vineNum = vines.Length - numUses;
        vines[vineNum].SetActive(false);
        
        // Reduce the number of uses
        numUses--;

        if (numUses <= 0)
        {
            canReset = true;
            timer = timeToRegen;
        }
    }

    private void FixedUpdate()
    {
        if (!canReset) return;
        
        timer -= Time.fixedDeltaTime;
        
        if (timer <= 0)
        {
            canReset = false;
            ResetVines();
        }
    }

    private void ResetVines()
    {
        numUses = vines.Length;
        foreach (var vine in vines)
        {
            vine.SetActive(true);
        }
    }
}
