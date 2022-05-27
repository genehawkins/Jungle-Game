using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    //Speed for the enemies to travel at
    public float pace = 13f;

    //Making this private because it will only be in the enemy script
    private Transform target;
    private int wayPointIndex = 0;

    void Start(){
        
        /*This is referencing the points array inside the waypoint script, and starting at the point
        with the index of 0*/
        target = waypoint.points[0];
    }

    void Update (){

        //Getting a vector that are 3 numbers for x,y,x
        //The way to get a direction vector point from one point to another is to subtract them 
        Vector3 dir = target.position - transform.position;

        //To move with the vector
        /*translate means moves the transform in the direction and distance of translation and the 
        translation is given by a vector*/
        /*Use dir.normalized to make sure that this is always going to have the same length, fixed 
        speed, and so that the only thing controlling the speed will be the speed*/
        //multiply by speed to get the actually speed
        //Time.deltaTime will make sure the speed is not dependent on the frame rate
        transform.Translate(dir.normalized * pace * Time.deltaTime, Space.World);

        //Switching waypoints
        if(Vector3.Distance(transform.position, target.position) <= 0.3f){

            GetNextwaypoint();
        }
    }

    void GetNextwaypoint(){

        if(wayPointIndex >= waypoint.points.Length - 1){

            Destroy(gameObject);
            return;
        }

        wayPointIndex++; //increasing by 1
        target = waypoint.points[wayPointIndex];
    }
}
