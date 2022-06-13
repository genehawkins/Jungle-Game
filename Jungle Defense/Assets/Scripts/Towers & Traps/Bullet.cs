using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Enemy")) return;
        
        // Debug.Log($"hit: {col.name}");
        
        HasHealth hh = col.GetComponent<HasHealth>();
        if (hh)
        {
            // Debug.Log($"dealing {damage} damage to: {col.name}");
            hh.TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
