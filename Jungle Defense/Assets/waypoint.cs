using UnityEngine;

public class waypoint : MonoBehaviour
{
    //Want to find all the points and add them to the array
    public static Transform[] points;

    void Startup()
    {   
        points = new Transform[transform.childCount];//This is the number of children currently in WayPoint
        for(int i = 0; i < points.Length; i++){ //Using a for loop to iterate
            
            points[i] = transform.GetChild(i);//Pushing it in the i slot
        }
    }
}
