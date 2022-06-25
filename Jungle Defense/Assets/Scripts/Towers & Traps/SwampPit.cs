using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampPit : MonoBehaviour
{
    private float stuckTime = 1.0f;
    private System.Random rng;

    private void Start()
    {
        rng = new System.Random();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Enemy")) return;

        var next = rng.Next(0, 99);
        Debug.Log(next);
        if (next < 25)
        {
            StartCoroutine(StuckInMud(col));
        }
    }

    private IEnumerator StuckInMud(Collider2D col)
    {
        EnemyMovement enemyMovement = col.GetComponent<EnemyMovement>();
        
        float oldSpeed = enemyMovement.speed;
        
        enemyMovement.speed = 0f;
        
        yield return new WaitForSeconds(stuckTime);
        
        enemyMovement.speed = oldSpeed;
    }
}
