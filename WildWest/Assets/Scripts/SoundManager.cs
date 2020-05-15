using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;

    public static SoundManager instance;

    private float volLow = 0.6f;
    private float volHigh = 1.3f;
    private float pitchLow = 0.95f;
    private float pitchHigh = 1.05f;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixer;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)   //metoden som kallas på när man vill att ett ljudclip ska spelas
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("No sound found for this file");
            return;
        }

        s.source.Play();

    }

    public void Playvaryingsound(string name)   // Metod som ska ge ett ljudclip som ska spelas flera gånger en viss variation i pitch och volym
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("No sound found for this file");
            return;
        }

        s.source.pitch = UnityEngine.Random.Range(pitchLow, pitchHigh);
        float vol = UnityEngine.Random.Range(volLow, volHigh);
        s.source.PlayOneShot(s.clip, vol);
    }
}
