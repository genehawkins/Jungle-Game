using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasHealth : MonoBehaviour
{
    [Tooltip("This is the amount of damage the enemies can take before being destroyed.")]
    [SerializeField] private float health = 1f;

    public void TakeDamage(float amount = 1f)
    {
        health -= amount;
        if (health <= 0f) Death();
    }

    private void Death()
    {
        GameManager.instance.enemyTracker.EnemyDestroyed();
        Destroy(gameObject);
    }

    public float GetRemainingHealth()
    {
        return health;
    }
}
