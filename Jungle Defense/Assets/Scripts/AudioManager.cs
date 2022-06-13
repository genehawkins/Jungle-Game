using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; 

    // Awake is called before the first frame update
    void Awake()
    {   
        //Creates accessible array of sound clips that were manually entered in Unity
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

        GameManager.SetupPhase.AddListener(PlaySetupSound);  //Sets up listener and plays chime during Unity Setup event

        PlaySetupSound();
    }

    //Setup sound reference for event listener
    private void PlaySetupSound()
    {
        Play("StartSetup");
    }

    //Plays audio clip based on file name
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;

        s.source.Play();
    }
}
