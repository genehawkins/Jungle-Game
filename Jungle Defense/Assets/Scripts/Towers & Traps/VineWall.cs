using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineWall : Trap
{
    [Tooltip("Amount that the slowing effect slows the enemy.")]
    public float slowRate = 2;
    [Tooltip("Time that the slowing effect lasts for.")]
    public float effectTime = 2.0f;

    protected override void TrapEffect(Collider2D enemy)
    {
        var enemyMovement = enemy.GetComponent<EnemyMovement>();
        StartCoroutine(Co_SlowEnemyForTime(enemyMovement));
    }

    private IEnumerator Co_SlowEnemyForTime(EnemyMovement enemyMovement)
    {
        if (enemyMovement) enemyMovement.speed /= slowRate;
        yield return new WaitForSeconds(effectTime);
        if (enemyMovement) enemyMovement.speed *= slowRate;
    }
}
