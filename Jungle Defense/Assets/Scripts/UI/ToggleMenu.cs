using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleMenu : MonoBehaviour
{
    public KeyCode toggleKey;
    [SerializeField] private Canvas canvas;
    public bool active { get; private set; }

    public void ToggleActive()
    {
        active = !active;
        canvas.enabled = active;
        Time.timeScale = (active) ? 0f : 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleActive();
        }
    }
}
