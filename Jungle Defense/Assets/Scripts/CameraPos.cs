using UnityEngine;

public class CameraPos : MonoBehaviour
{
    [SerializeField] private KeyCode key = KeyCode.S;
    [SerializeField] private Transform tableCameraPos;
    [SerializeField] private Transform shopCameraPos;
    [SerializeField] private GameObject shopGameObject;
    private bool _atTable = true;

    private void Update()
    {
        if (!GameManager.inSetupPhase)
        {
            if (!_atTable)
            {
                GoToTable();
            }
            return;
        }
        
        if (Input.GetKeyDown(key) && _atTable)
        {
            GoToShop();
        }
        else if (Input.GetKeyDown(key) && !_atTable)
        {
            GoToTable();
        }
    }

    private void GoToShop()
    {
        var newPos = shopCameraPos.position;
        newPos.z = -10;
        transform.position = newPos;
        _atTable = false;
        shopGameObject.SetActive(true);
    }

    private void GoToTable()
    {
        
        var newPos = tableCameraPos.position;
        newPos.z = -10;
        transform.position = newPos;
        _atTable = true;
        shopGameObject.SetActive(false);
    }
}
