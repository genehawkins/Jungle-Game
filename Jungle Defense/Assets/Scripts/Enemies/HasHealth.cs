using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasHealth : MonoBehaviour
{
    [Tooltip("This is the amount of damage the enemies can take before being destroyed.")]
    [SerializeField] private float health = 1f;
    [Tooltip("This will be added to the GameManager score when this enemy is killed.")]
    [SerializeField] private float scoreAddedWhenKilled = 10f;

    public void TakeDamage(float amount = 1f)
    {
        health -= amount;

        if (health <= 0f)
        {
            // Death
            if (GameManager.instance) GameManager.instance.AddToScore(scoreAddedWhenKilled);
            Destroy(this);
        }
    }
}
