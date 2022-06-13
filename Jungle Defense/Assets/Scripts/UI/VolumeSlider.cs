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
}
