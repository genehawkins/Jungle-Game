using UnityEngine;

public class WayPoint : MonoBehaviour
{
    // Want to find all the points and add them to the array
    public static Transform[] points;

    private void Start()
    {
        // resize points array to fit all children.
        points = new Transform[transform.childCount];
        
        // loop through all children and add them to the points array.
        for(int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
