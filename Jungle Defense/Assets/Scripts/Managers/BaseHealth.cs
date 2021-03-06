using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    private float health = 20.0f;
    private float maxHealth = 20f;
    public int immuneCount = 0;
    private bool isImmune = false;
    [SerializeField] private EndNode endNode;

    void Update()
    {
        isImmune = immuneCount > 0;
        endNode.ToggleFog(isImmune);
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
        GameManager.instance.GameOver(false);
    }

    public float GetBaseHealth()
    {
        return health;
    }

}