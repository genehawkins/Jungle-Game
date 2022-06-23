using System;
using UnityEngine;

public class HasHealth : MonoBehaviour
{
    [Tooltip("This is the amount of damage the enemies can take before being destroyed.")]
    [SerializeField] private float health = 1f;
    //public GameObject Shop;
    [SerializeField] private int coinsOnDeath = 5;
    [SerializeField] private HealthBar hpBar;
    
    private void Start()
    {
        hpBar.SetMaxHealth(health);
    }

    public void TakeDamage(float amount = 1f)
    {
        health -= amount;
        hpBar.UpdateHealth(health);
        if (health <= 0f) Death();
    }

    private void Death()
    {
        GameManager.instance.enemyTracker.EnemyDestroyed();
        GameManager.instance.moneyManager.AddCoins(coinsOnDeath);
        Destroy(gameObject);
    }

    public float GetRemainingHealth()
    {
        return health;
    }
}
