using UnityEngine.Audio;
using System;
using UnityEngine;

// Thanks Brackeys

// ----- How to Use -----
// Copy Paste the code below and place anywhere
// FindObjectOfType<AudioManager>().Play("ZaWarudo");

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this; // I survive...
        else
        {
            Destroy(gameObject); // There can only be one...
            return;
        }

        DontDestroyOnLoad(gameObject); // Join the Singleton Gang

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start ()
    {
        //Play("ZaWarudo"); <--- Example, Use this to play the Theme or something
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
