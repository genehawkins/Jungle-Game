using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Speed that the enemies move.
    public float speed = 13f;
    
    // Tracks the index in the array of WayPoints that the enemy is moving towards.
    private int pointIndex = 0;

    private void Update()
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
            Destroy(gameObject);
            return;
        }

        pointIndex++;
    }
}
