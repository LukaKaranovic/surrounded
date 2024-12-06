using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{   
    private static AudioManager instance;
    public bool isGoofy = false;
    public Toggle myToggle;

    void Update(){
        isGoofy = myToggle.isOn ? true : false;
    }

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
    public void Play(string NameOfSound, float Volume)
    {
        GameObject audioObject = new GameObject("FireAudio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();

        // Set audio properties
        if(isGoofy){
        audioSource.clip = Resources.Load<AudioClip>($"Sounds/Goofy Ahh {NameOfSound}");
        } else{
            audioSource.clip = Resources.Load<AudioClip>($"Sounds/{NameOfSound}");
        }
        audioSource.volume = Volume;
        audioSource.Play();

        // Destroy the audio object after the clip finishes
        Destroy(audioObject, audioSource.clip.length);
    }
}
