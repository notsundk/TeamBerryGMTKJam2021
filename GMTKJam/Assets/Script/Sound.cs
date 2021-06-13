using UnityEngine.Audio;
using UnityEngine;

//Sound Class

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;
    
    //We don't need to see this shit because it's in Awake
    [HideInInspector] 
    public AudioSource source;
}
