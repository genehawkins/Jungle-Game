using UnityEngine;

public class HasHealth : MonoBehaviour
{
    [Tooltip("This is the amount of damage the enemies can take before being destroyed.")]
    [SerializeField] private float health = 1f;
    //public GameObject Shop;

    public void TakeDamage(float amount = 1f)
    {
        health -= amount;
        if (health <= 0f) Death();
    }

    private void Death()
    {
        GameManager.instance.enemyTracker.EnemyDestroyed();
        GameManager.instance.shopManager.AddCoins();
        Destroy(gameObject);
    }

    public float GetRemainingHealth()
    {
        return health;
    }
}
