using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; 

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.SetupPhase.AddListener(PlaySetupSound);
        

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

        Play("StartSetup");
    }

    private void PlaySetupSound()
    {
        Play("StartSetup");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
