using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [Header("Sounds")]
    [SerializeField] private AudioClip gameMusic;
    //[SerializeField] private AudioClip setupPhaseSound;

    [Header("Volume")] 
    [SerializeField] private float musicVol = 0.5f; 
    [SerializeField] private float fxVol = 0.5f;

    [Header("Unity Setup")] 
    private AudioSource musicSrc;
    private AudioSource fxSource;

    void Awake()
    {   
        // Create A Singleton Instance:
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }

        musicSrc = gameObject.AddComponent<AudioSource>();
        fxSource = gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {
        StartMusic();
        fxSource.volume = fxVol;
    }

    private void StartMusic()
    {
        musicSrc.clip = gameMusic;
        musicSrc.volume = musicVol;
        musicSrc.loop = true;
        musicSrc.Play();
    }

    public void SetMusicVol(float newVol)
    {
        musicVol = newVol;
        musicSrc.volume = newVol;
    }

    //Plays audio clip based on file name
    public void PlayFX(AudioClip clip)
    {
        fxSource.PlayOneShot(clip);
    }
    
    public void SetFXVol(float newVol)
    {
        fxVol = newVol;
        fxSource.volume = newVol;
    }
}
