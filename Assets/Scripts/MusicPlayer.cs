using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Variable for storing Audio Source
    AudioSource audioSource;

    void Start()
    {
        // Assigns audio source and sets its volume
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    // Function for setting the volume
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
