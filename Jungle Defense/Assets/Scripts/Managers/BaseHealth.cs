using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    private float health = 20.0f;

    public void DamageBase(float amount = 1.0f)
    {
        health -= amount;
        if (health <= 0f) DestroyBase();
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