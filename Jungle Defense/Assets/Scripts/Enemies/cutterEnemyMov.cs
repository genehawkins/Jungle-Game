using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutterEnemyMov : MonoBehaviour
{
    //Speed that the enemies move.
    public float speed = 14f;

    // Tracks the index in the array of WayPoints that the enemy is moving towards.
    private int pointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // The enemy moves from its current position to the waypoint at pointIndex at a rate of Time.deltaTime * speed.
        transform.position = Vector2.MoveTowards(transform.position, WayPoint.points[pointIndex].position,
            Time.deltaTime * speed);

            // If the enemy reaches the waypoint, get the next waypoint to move towards.
        if(Vector2.Distance(transform.position, WayPoint.points[pointIndex].position) < 0.1f){
            GetNextPoint();
        }
    }

    void GetNextPoint()
    {
        if(pointIndex >= WayPoint.points.Length - 1)
        {
            // Enemy reached the end
            var hh = GetComponent<HasHealth>();
            GameManager.instance.baseHealth.DamageBase(hh.GetRemainingHealth());
            GameManager.instance.enemyTracker.EnemyDestroyed();
            Destroy(gameObject);
            return;
        }

        pointIndex++;
    }
}
