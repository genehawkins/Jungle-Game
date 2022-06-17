using UnityEngine;

public class CameraPos : MonoBehaviour
{
    [SerializeField] private KeyCode key = KeyCode.S;
    [SerializeField] private Transform tableCameraPos;
    [SerializeField] private Transform shopCameraPos;
    private bool _atTable = true;

    private void Update()
    {
        if (!GameManager.inSetupPhase)
        {
            if (!_atTable)
            {
                var newPos = tableCameraPos.position;
                newPos.z = -10;
                transform.position = newPos;
                _atTable = true;
            }
            return;
        }
        
        if (Input.GetKeyDown(key) && _atTable)
        {
            var newPos = shopCameraPos.position;
            newPos.z = -10;
            transform.position = newPos;
            _atTable = false;
        }
        else if (Input.GetKeyDown(key) && !_atTable)
        {
            var newPos = tableCameraPos.position;
            newPos.z = -10;
            transform.position = newPos;
            _atTable = true;
        }
    }
}
