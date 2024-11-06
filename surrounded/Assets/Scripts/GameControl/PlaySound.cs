using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    private static AudioManager instance;

    // Ensure there's only one instance of AudioManager
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject); // Keep AudioManager across scenes
    }
    public void Play(string NameOfSound)
    {
        GameObject audioObject = new GameObject("FireAudio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();

        // Set audio properties
        audioSource.clip = Resources.Load<AudioClip>($"Sounds/{NameOfSound}");
        audioSource.Play();

        // Destroy the audio object after the clip finishes
        Destroy(audioObject, audioSource.clip.length);
    }
}
