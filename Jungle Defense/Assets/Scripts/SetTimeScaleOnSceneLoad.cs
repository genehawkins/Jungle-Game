using UnityEngine;
public class SetTimeScaleOnSceneLoad : MonoBehaviour
{
    [SerializeField] private float scale = 1.0f;
    private void Start()
    {
        Time.timeScale = scale;
    }
}
