using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWaveButton : MonoBehaviour
{
    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
        GameManager.SetupPhase.AddListener(EnableBtn);
        GameManager.GamePhase.AddListener(DisableBtn);
    }

    private void EnableBtn() => btn.interactable = true;

    private void DisableBtn() => btn.interactable = false;

    public void StartWave() => GameManager.instance.waveSpawner.StartWave();
}
