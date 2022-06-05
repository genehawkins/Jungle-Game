using System;
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
        // TODO
    }

    public float GetBaseHealth()
    {
        return health;
    }

}