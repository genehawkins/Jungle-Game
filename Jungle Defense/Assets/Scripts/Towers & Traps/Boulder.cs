using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    private List<int> hits = new List<int>();

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Enemy")) return;
        
        // avoid hitting the same enemy twice:
        int id = col.GetInstanceID(); 
        if (hits.Contains(id)) return;
        hits.Add(id);

        // deal damage to the enemy:
        HasHealth hh = col.GetComponent<HasHealth>();
        if (hh) {
            hh.TakeDamage(damage);
        }
    }
}
