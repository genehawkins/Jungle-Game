using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Speed that the enemies move.
    public float speed = 13f;
    
    // Tracks the index in the array of WayPoints that the enemy is moving towards.
    public int pointIndex = 0;
    
    private SpriteRenderer spr;
    private Animator anim;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // The enemy moves from its current position to the waypoint at pointIndex at a rate of Time.deltaTime * speed.
        var target = WayPoint.points[pointIndex].position;
        var curPos = transform.position;
        
        transform.position = Vector2.MoveTowards(curPos, target,
            Time.deltaTime * speed);
        
        // handle sprite flipping in left/right direction
        spr.flipX = ((target.x - curPos.x) < 0);

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
