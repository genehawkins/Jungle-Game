using UnityEngine;
using Random = UnityEngine.Random;

public class Mushroom : MonoBehaviour
{
    [SerializeField][Range(0f, 1f)] private float chanceToConfuse = 0.25f;
    
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (!enemy.CompareTag("Enemy")) return;
            
        //Debug.Log("Mushroom Hit Enemy");

        if (Random.value < chanceToConfuse) // 25% chance to confuse an enemy
        {
            enemy.GetComponent<EnemyMovement>().pointIndex = 0;
        }
    }
}
