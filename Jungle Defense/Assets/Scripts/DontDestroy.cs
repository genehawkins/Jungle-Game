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
        foreach (var dontDestroy in dontDestroyList)
        {
            if (dontDestroy != this && dontDestroy.id == id)
            {
                Destroy(gameObject);
                return;
            }
        }

        transform.parent = null;
        DontDestroyOnLoad(this);
    }
}
