using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum VolType
{
    Music,
    FX
}

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private VolType volType;

    private void OnEnable()
    {
        //Debug.Log("Enable");
        SetSlider();
    }

    public void SetVolume()
    {
        switch(volType)
        {
            case VolType.Music:
                AudioManager.instance.SetMusicVol(slider.value);
                return;
            
            case VolType.FX:
                AudioManager.instance.SetFXVol(slider.value);
                return;
        }
    }

    private void SetSlider()
    {
        switch(volType)
        {
            case VolType.Music:
                slider.value = AudioManager.instance.musicVol;
                return;
            
            case VolType.FX:
                slider.value = AudioManager.instance.fxVol;
                return;
        }
    }
}
