using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPits : MonoBehaviour
{
    [SerializeField] float time= 5f, damage = 10f;
    [SerializeField] bool TakeDamage = true;

    private void OnTriggerStay(collide other)
    {
        if (other.GetComponent<Health>())
        {
            Health health = other.GetComponent<Health>();
            StartCoroutine(TakeDamage(time, health));
        }
    }

    IEnumerator TakeDamage(float time, Health health)
    {
        if(TakeDamage)
        {
            health.TakeDamage(damage);
            TakeDamage = !TakeDamage;
            yield return new WaitForSeconds(time);
            TakeDamage = !TakeDamage;
        }
    }
}
