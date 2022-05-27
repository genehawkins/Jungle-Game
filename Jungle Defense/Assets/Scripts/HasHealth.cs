using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasHealth : MonoBehaviour
{
    [SerializeField] private float health = 1f;
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
