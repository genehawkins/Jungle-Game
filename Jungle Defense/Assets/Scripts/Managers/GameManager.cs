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
    public MoneyManager moneyManager;

    // unity event that announces the start of setup phase
    public readonly UnityEvent SetupPhase = new UnityEvent();
    // unity event that announces the start of game phase
    public readonly UnityEvent GamePhase = new UnityEvent();
    // bool to check whether currently in setup phase
    public bool inSetupPhase { get; private set; } = false;

    [SerializeField] private AudioClip setupPhaseSound;
    [SerializeField] private AudioClip gamePhaseSound;
    [SerializeField] private AudioClip errorSound;
    
    private void Awake()
    {
        instance = this;
        SetupPhase.AddListener(PlaySetupPhaseSound);
        GamePhase.AddListener(PlayGamePhaseSound);
    }

    public void GameOver(bool playerWon)
    {
        var status = playerWon ? "won." : "lost.";
        // Debug.Log("Game Over, player " + status);
        YouWinOrLose.playerWon = playerWon;
        SceneManager.LoadScene("_EndScreen");
    }

    public void LevelComplete()
    {
        var activeScene = SceneManager.GetActiveScene();
        if (activeScene.name == "Scene11")
        {
            GameOver(true);
        }
        SceneManager.LoadScene(activeScene.buildIndex + 1);
    }

    private void PlaySetupPhaseSound()
    {
        Debug.Log("Start Setup Phase");
        inSetupPhase = true;
        AudioManager.instance.PlayFX(setupPhaseSound);
    }

    private void PlayGamePhaseSound()
    {
        Debug.Log("Start Game Phase");
        inSetupPhase = false;
        if (AudioManager.instance) AudioManager.instance.PlayFX(gamePhaseSound);
    }

    public void PlayErrorSound()
    {
        if (AudioManager.instance) AudioManager.instance.PlayFX(errorSound);
    }
}
