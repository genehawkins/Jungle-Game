using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    [SerializeField] private float damage = 3f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        HasHealth hh = col.GetComponent<HasHealth>();
        if (hh) {
            hh.TakeDamage(damage);
        }
    }
}
