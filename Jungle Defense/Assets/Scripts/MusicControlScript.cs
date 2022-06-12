using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControlScript : MonoBehaviour
{
    public static MusicControlScript instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
}
