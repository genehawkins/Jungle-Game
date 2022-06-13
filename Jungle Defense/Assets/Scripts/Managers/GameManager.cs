using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public WaveSpawner waveSpawner;
    public BaseHealth baseHealth;
    public EnemyTracker enemyTracker;
    public CardSystem cardSystem;
    public BuildManager buildManager;
    public ShopManager shopManager;

    // unity event that announces the start of setup phase
    public static readonly UnityEvent SetupPhase = new UnityEvent();
    // unity event that announces the start of game phase
    public static readonly UnityEvent GamePhase = new UnityEvent();
    // bool to check whether currently in setup phase
    public static bool inSetupPhase = true;

    [SerializeField] private AudioClip setupPhaseSound;
    [SerializeField] private AudioClip gamePhaseSound;
    [SerializeField] private AudioClip errorSound;
    
    private void Awake()
    {
        instance = this;
        SetupPhase.AddListener(PlaySetupPhaseSound);
        GamePhase.AddListener(PlayGamePhaseSound);
    }

    public static void GameOver(bool playerWon)
    {
        var status = playerWon ? "won." : "lost.";
        // Debug.Log("Game Over, player " + status);
        YouWinOrLose.playerWon = playerWon;
        SceneManager.LoadScene("_EndScreen");
    }

    private void PlaySetupPhaseSound()
    {
        AudioManager.instance.PlayFX(setupPhaseSound);
    }

    private void PlayGamePhaseSound()
    {
        if (AudioManager.instance) AudioManager.instance.PlayFX(gamePhaseSound);
    }

    public void PlayErrorSound()
    {
        if (AudioManager.instance) AudioManager.instance.PlayFX(errorSound);
    }
}
