using System;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    [SerializeField] private KeyCode key = KeyCode.F12;
    private readonly string directoryName = "Screenshots";

    public void TakeScreenshot()
    {
        string datetime = DateTime.Now.ToString("dd-MM-yyyy HHmmss");
        ScreenCapture.CaptureScreenshot("Screenshot " + datetime + ".png");
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            TakeScreenshot();
        }
    }
}
