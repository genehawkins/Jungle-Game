using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Enemy")) {
            enemy.gameObject.GetComponent<EnemyMovement>().pointIndex = 0;
        }
    }
}
