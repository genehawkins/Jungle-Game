using System;
using UnityEditor;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    [SerializeField] private KeyCode key = KeyCode.F12;
    public int superSize = 2;
    
    public void TakeScreenshot()
    {
        string datetime = DateTime.Now.ToString("dd-MM-yyyy-HHmmss");
        ScreenCapture.CaptureScreenshot("Screenshot_" + datetime + ".png", superSize);
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            TakeScreenshot();
        }
    }
}
