using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; 

    public static AudioManager instance;

    // Awake is called before the first frame update
    void Awake()
    {   
        
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        

        //Creates accessible array of sound clips that were manually entered in Unity
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        GameManager.SetupPhase.AddListener(PlaySetupSound);  //Sets up listener and plays chime during Unity Setup event

        Play("GameTheme");
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
        if (s == null) {
            Debug.Log($"{name} NOT FOUND");
            return;
        } else {
            s.source.Play();  //THROWS ERROR WHEN PLAYING "DRAWCARD" FROM DrawNewHand() (CardSystem line 82)
        }
    }
}
