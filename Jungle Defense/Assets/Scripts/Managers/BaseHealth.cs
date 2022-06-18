using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    private float health = 20.0f;
    private float maxHealth = 20f;
    public bool isImmune = false;
    public int immuneCount = 0;

    void Update()
    {
        isImmune = immuneCount > 0;
    }

    public void DamageBase(float amount = 1.0f)
    {
        if (isImmune) {
            immuneCount--;
        } else {
            health -= amount;
            if (health <= 0f) DestroyBase();
        }
    }

    public void HealBase(float amount = 1f)
    {
        health += amount;
        if (health > maxHealth) {
            health = maxHealth;
        }
    }

    private void DestroyBase()
    {
        Debug.Log("Base Destroyed!");
        GameManager.GameOver(false);
    }

    public float GetBaseHealth()
    {
        return health;
    }

}