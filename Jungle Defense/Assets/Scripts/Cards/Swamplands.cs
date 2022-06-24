using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swamplands : ScriptableObject
{
    public float totalTime = 0f;

    void OnTriggerStay2D(Collider2D other)
    {
        totalTime += Time.deltaTime;

        if(totalTime > 1)
        {
            health -= 2;
            totalTime = 0f;
        }
    }
}
