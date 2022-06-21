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
        StartCoroutine(Co_SlowEnemyForTime(enemy));
    }

    private IEnumerator Co_SlowEnemyForTime(Collider2D enemy)
    {
        if (enemy) enemy.GetComponent<EnemyMovement>().speed /= slowRate;
        yield return new WaitForSeconds(effectTime);
        if (enemy) enemy.GetComponent<EnemyMovement>().speed *= slowRate;
    }
}
