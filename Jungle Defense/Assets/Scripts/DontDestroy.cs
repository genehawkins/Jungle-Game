using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    [HideInInspector] public string id;

    private void Awake()
    {
        id = name + transform.position.ToString();
    }

    private void Start()
    {
        DontDestroy[] dontDestroyList = FindObjectsOfType<DontDestroy>();
        for (int i = 0; i < dontDestroyList.Length; ++i)
        {
            if (dontDestroyList[i] != this && dontDestroyList[i].id == id)
            {
                Destroy(gameObject);
                return;
            }
        }
        DontDestroyOnLoad(this);
    }
}
