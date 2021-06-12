using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    // Public = Trigger from Slider || Void = Don't return anything

    public AudioMixer audioMixer;
    
    public void SetVolume (float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }
}
