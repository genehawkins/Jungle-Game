using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    private bool hasHit = false;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (hasHit || !col.CompareTag("Enemy")) return;
        hasHit = true; // to stop bullets from hitting multiple enemies.
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
